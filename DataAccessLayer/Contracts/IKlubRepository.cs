using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Contracts
{
    public interface IKlubRepository
    {
        Task CreateAsync(Klub klub);
        Task UpdateAsync(Klub klub);
        Task DeleteAsync(Klub klub);
        Task<List<Klub>> GetAllAsync();

        Task<Klub> GetByIdAsync (int id);

        Task<Klub> GetByEmailAsync ( string email);
        Task<List<Klub>> GetByImeKlubaAsync (string searchQuery);
        Task<List<Klub>> GetByGradAsync(string searchQuery);
        Task<List<Klub>> GetByDrzavaAsync(string searchQuery);
    }
}
