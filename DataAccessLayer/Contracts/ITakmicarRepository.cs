using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface ITakmicarRepository
    {
        Task CreateAsync (Takmicar takmicar);   

        Task UpdateAsync (Takmicar takmicar);

        Task<Takmicar> GetByIdAsync (int id);

        Task<Takmicar> GetByImeIPrezimeAsync(string ime, string prezime);

        Task<List<Takmicar>> GetAllAsync();

        Task DeleteAsync (Takmicar takmicar);


        
    }
}
