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
    public class EkipnoBorbeService : IEkipnoBorbeService
    {
        private readonly IEkipnoBorbeRepository _repository;

        public EkipnoBorbeService (IEkipnoBorbeRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(EkipnoBorbe ekipa)
        {
            await _repository.Create(ekipa);
        }

        public async Task Delete(EkipnoBorbe ekipa)
        {
           await  _repository.Delete(ekipa);
        }

        public async Task Update(EkipnoBorbe ekipa)
        {
            await _repository.Update(ekipa);
        }

        public async Task<EkipnoBorbe> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<EkipnoBorbe>> GetAll()
        {
            return await  _repository.GetAll();
        }

        public async Task<EkipnoBorbe> GetByImeEkipe(string imeEkipe)
        {
            return await _repository.GetByImeEkipe(imeEkipe);
        }

        public async Task<List<EkipnoBorbe>> GetByKlub(int klub)
        {
            return await _repository.GetByKlub(klub);
        }

        public async Task<List<EkipnoBorbe>> GetByKlasa(string pol, string uzrast)
        {
            return await _repository.GetByKlasa(pol, uzrast);

        }
    }
}
