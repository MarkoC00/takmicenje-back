using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccess.Contracts;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccess.Services
{
    public class EkipnoKateService : IEkipnoKateService
    {

        private readonly IEkipnoKateRepository _ekipnoKateRepository;

        public EkipnoKateService(IEkipnoKateRepository ekipnoKateRepository)
        {
            _ekipnoKateRepository = ekipnoKateRepository;
        }

        public async Task CreateAsync(EkipnoKate ekipa)
        {
            await _ekipnoKateRepository.CreateAsync(ekipa);
        }
        public async Task UpdateAsync(EkipnoKate ekipa)
        {
            await _ekipnoKateRepository.UpdateAsync(ekipa);
        }
        public async Task DeleteAsync(EkipnoKate ekipa)
        {
            await _ekipnoKateRepository.DeleteAsync(ekipa);
        }
        public async Task<List<EkipnoKate>> GetAllAsync()
        {
           return await _ekipnoKateRepository.GetAllAsync();
        }

        public async Task<EkipnoKate> GetByIdAsync(int id)
        {
            return await _ekipnoKateRepository.GetByIdAsync(id);
        }

        public async Task<EkipnoKate> GetByImeEkipeAsync(string imeEkipe)
        {
            return await _ekipnoKateRepository.GetByImeEkipeAsync(imeEkipe);
        }

        public async Task<List<EkipnoKate>> GetAllByPoliUzrast(string pol, string uzrast)
        {
            return await _ekipnoKateRepository.GetAllByPoliUzrast(pol, uzrast);
        }

        public async Task<List<EkipnoKate>> GetAllByKlub(int idKluba)
        {
            return await _ekipnoKateRepository.GetAllByKlub(idKluba);
        }
    }
}
