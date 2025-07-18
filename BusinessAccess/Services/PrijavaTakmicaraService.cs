using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessAccess.Contracts;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccess.Services
{
    public class PrijavaTakmicaraService : IPrijavaTakmicaraService
    {

        private readonly IPrijavaTakmicaraRepository _prijavaTakmicaraRepository;

        public PrijavaTakmicaraService(IPrijavaTakmicaraRepository prijavaTakmicaraRepository)
        {
            _prijavaTakmicaraRepository = prijavaTakmicaraRepository;
        }
        public async Task CreateAsync(Takmicar takmicara)
        {
            await _prijavaTakmicaraRepository.CreateAsync(takmicara);
        }

        public async Task UpdateAsync(PrijavaTakmicara prijavaTakmicara)
        {
           await _prijavaTakmicaraRepository.UpdateAsync(prijavaTakmicara);
        }
        public async Task DeleteAsync(PrijavaTakmicara prijavaTakmicara)
        {
            await _prijavaTakmicaraRepository.DeleteAsync(prijavaTakmicara);
        }
        
        public async Task<List<PrijavaTakmicara>> GetAllAsync()
        {
            return await _prijavaTakmicaraRepository.GetAllAsync();
        }

        public async Task<PrijavaTakmicara> GetByImeIPrezimeAsync(string ime, string prezime)
        {
            return await _prijavaTakmicaraRepository.GetByImeIPrezimeAsync(ime, prezime);
        }


        public async Task<List<PrijavaTakmicara>> GetByKategorija(string pol, string godiste, string klasa)
        {
            return await _prijavaTakmicaraRepository.GetByKategorija(pol,godiste,klasa);
        }

        public async Task<PrijavaTakmicara> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaKateId)
        {
            return await _prijavaTakmicaraRepository.PrijavaTakmicaraUTimAsync(prijavaTakmicara, ekipaKateId);
        }

    }
}
