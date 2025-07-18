using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessAccess.Contracts
{
    public interface IKlubService
    {
        Task CreateAsync(Klub klub);
        Task UpdateAsync(Klub klub);
        Task DeleteAsync(Klub klub);
        Task<List<Klub>> GetAllAsync();

        Task<Klub> GetByIdAsync(int id);
        Task<List<Klub>> GetByImeKlubaAsync(string searchQuery);
        Task<List<Klub>> GetByGradAsync(string searchQuery);
        Task<List<Klub>> GetByDrzavaAsync(string searchQuery);
    }
}
