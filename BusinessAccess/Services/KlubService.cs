using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessAccess.Contracts;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccess.Services
{
    public class KlubService : IKlubService
    {
        private readonly IKlubRepository _klubRepository;

        public KlubService (IKlubRepository klubRepository)
        {
            this._klubRepository = klubRepository;
        }

        public async Task CreateAsync(Klub klub)
        {
            if (string.IsNullOrEmpty(klub.Email) || !Regex.IsMatch(klub.Email, @"^[^@\s]+@[^@\s]+.[^@\s]+$"))
            {
                throw new ArgumentException("Nevažeći format mejla.");
            }

            var postojeciKlub = await _klubRepository.GetByEmailAsync(klub.Email);

            if(postojeciKlub != null)
            {
                throw new ArgumentException("Postoji korisnik sa istim mejlom.");
            }

            var postojeceImeKluba = await _klubRepository.GetByImeKlubaAsync(klub.ImeKluba);

            if (postojeciKlub != null)
            {
                throw new ArgumentException("Postoji korisnik sa istim imenom.");
            }

            if (!string.IsNullOrEmpty(klub.HashSifra) && klub.HashSifra.Length < 8)
            {
                throw new ArgumentException("Šifra nema dovoljno karaktera!");
            }

            if (!Regex.IsMatch(klub.HashSifra, @"^(?=.*[A-Z])(?=.*\d).+$"))
            {
                throw new ArgumentException("Nevažeći format mejla.");
            }

            await _klubRepository.CreateAsync(klub);
        }
        public async Task UpdateAsync(Klub klub)
        {
            await _klubRepository.UpdateAsync(klub);
        }
        public async Task DeleteAsync(Klub klub)
        {
            await _klubRepository.DeleteAsync(klub);
        }
        public async Task<List<Klub>> GetAllAsync()
        {
            return await _klubRepository.GetAllAsync();
        }

        public async Task<Klub> GetByIdAsync(int id)
        {
            return await _klubRepository.GetByIdAsync(id);
        }
        public async Task<List<Klub>> GetByImeKlubaAsync(string searchQuery)
        {
             return await _klubRepository.GetByImeKlubaAsync(searchQuery);
        }

        public async Task<List<Klub>> GetByGradAsync(string searchQuery)
        {
            return await _klubRepository.GetByGradAsync(searchQuery);
        }
        public async Task<List<Klub>> GetByDrzavaAsync(string searchQuery)
        {
            return await _klubRepository.GetByDrzavaAsync(searchQuery);
        }
    }
}
