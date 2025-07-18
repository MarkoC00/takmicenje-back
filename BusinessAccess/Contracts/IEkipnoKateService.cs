using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccess.Services;
using DataAccessLayer.Models;

namespace BusinessAccess.Contracts
{
    public interface IEkipnoKateService
    {
        
        Task CreateAsync(EkipnoKate ekipa);
        Task UpdateAsync(EkipnoKate ekipa);
        Task DeleteAsync(EkipnoKate ekipa);
        Task<List<EkipnoKate>> GetAllAsync();

        Task<EkipnoKate> GetByIdAsync(int id);

        Task<EkipnoKate> GetByImeEkipeAsync(string imeEkipe);

        Task<List<EkipnoKate>> GetAllByPoliUzrast(string pol, string uzrast);

        Task<List<EkipnoKate>> GetAllByKlub(int idKluba);
    }
}
