using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Contracts
{
    public interface IPrijavaTakmicaraRepository
    {
        Task CreateAsync (Takmicar takmicara);

        Task UpdateAsync(PrijavaTakmicara prijavaTakmicara);
        Task DeleteAsync(PrijavaTakmicara prijavaTakmicara);
        Task<List<PrijavaTakmicara>> GetAllAsync();

        Task<PrijavaTakmicara> GetByImeIPrezimeAsync(string ime, string prezime);
        
        Task<List<PrijavaTakmicara>> GetByKategorija(string pol, string godiste, string klasa);

        Task<PrijavaTakmicara> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaKateId);

    }
}
