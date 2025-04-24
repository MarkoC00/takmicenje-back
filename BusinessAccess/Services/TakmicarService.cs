using BusinessAccess.Contracts;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess.Services 
{
    public class TakmicarService : ITakmicarService
    {
        private readonly ITakmicarRepository _takmicarRepository;

        public TakmicarService(ITakmicarRepository takmicarRepository)
        {
            _takmicarRepository = takmicarRepository;

        }

        public async Task CreateAsync(Takmicar takmicar)
        {
            await _takmicarRepository.CreateAsync(takmicar);
        }

        public  async Task UpdateAsync(Takmicar takmicar)
        {
            await _takmicarRepository.UpdateAsync(takmicar);
        }

        public  async Task<Takmicar> GetByIdAsync(int id)
        {
            return await _takmicarRepository.GetByIdAsync(id);
        }

         public async Task<Takmicar> GetByImeIPrezimeAsync(string ime, string prezime)
        {
           return await _takmicarRepository.GetByImeIPrezimeAsync(ime, prezime);
        }

        public async Task<List<Takmicar>> GetAllAsync()
        {
            return await _takmicarRepository.GetAllAsync();
        }

        public async Task DeleteAsync(Takmicar takmicar)
        {
            await _takmicarRepository.DeleteAsync(takmicar);
        }

    }
}
