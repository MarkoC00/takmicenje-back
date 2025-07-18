using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessAccess.Contracts
{
    public interface IPrijaveTakmicaraBorbeService
    {
        Task CreateAsync(Takmicar takmicara);

        Task UpdateAsync(PrijavaTakmicaraBorbe prijavaTakmicara);
        Task DeleteAsync(PrijavaTakmicaraBorbe prijavaTakmicara);
        Task<PrijavaTakmicaraBorbe> GetById(int id);
        Task<List<PrijavaTakmicaraBorbe>> GetAllAsync();

        Task<PrijavaTakmicaraBorbe> GetByImeIPrezimeAsync(string ime, string prezime);

        Task<List<PrijavaTakmicaraBorbe>> GetByKategorija(string pol, string godiste, string kilaza);

        Task<PrijavaTakmicaraBorbe> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaBorbeId);
    }
}
