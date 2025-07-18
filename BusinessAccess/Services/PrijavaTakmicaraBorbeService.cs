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
    public class PrijavaTakmicaraBorbeService : IPrijaveTakmicaraBorbeService
    {
        private readonly IPrijavaTakmicaraBorbeRepository _repository ;

        public PrijavaTakmicaraBorbeService (IPrijavaTakmicaraBorbeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Takmicar takmicara)
        {
            await _repository.CreateAsync(takmicara);
        }

        public async Task UpdateAsync(PrijavaTakmicaraBorbe prijavaTakmicara)
        {
            await _repository.UpdateAsync(prijavaTakmicara);
        }

        public async Task<PrijavaTakmicaraBorbe> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaBorbeId)
        {
            return await _repository.PrijavaTakmicaraUTimAsync(prijavaTakmicara, ekipaBorbeId);
          }
        public async Task DeleteAsync(PrijavaTakmicaraBorbe prijavaTakmicara)
        {
            await _repository.DeleteAsync(prijavaTakmicara);
        }

        public async Task<PrijavaTakmicaraBorbe> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<List<PrijavaTakmicaraBorbe>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }


        public async Task<PrijavaTakmicaraBorbe> GetByImeIPrezimeAsync(string ime, string prezime)
        {
           return await _repository.GetByImeIPrezimeAsync(ime,prezime);
        }

        public async Task<List<PrijavaTakmicaraBorbe>> GetByKategorija(string pol, string godiste, string kilaza)
        {
            return await _repository.GetByKategorija(pol, godiste, kilaza);
        }

        //Task<PrijavaTakmicaraBorbe> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaBorbeId);
    }
}
