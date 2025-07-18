using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    
    public class PrijavaTakmicaraBorbeRepository : IPrijavaTakmicaraBorbeRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public PrijavaTakmicaraBorbeRepository (ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Takmicar takmicar)
        {
            if (takmicar == null)
            {
               throw new ArgumentNullException(nameof(takmicar));
            }

            PrijavaTakmicaraBorbe prijava =  new PrijavaTakmicaraBorbe();

            prijava.IdTakmicara = takmicar.Id;
            prijava.Kilaza = "0";
            prijava.Pol = takmicar.Pol.ToString();
            prijava.Godiste= takmicar.Godiste;
            prijava.Individualno=false;
            prijava.Ekipno=false;

            await _dbContext.PrijavaTakmicaraBorbes.AddAsync(prijava);
            await _dbContext.SaveChangesAsync();

        }

       public async Task UpdateAsync(PrijavaTakmicaraBorbe prijavaTakmicaraBorbe)
        {
            if(prijavaTakmicaraBorbe == null)
            {
                throw new ArgumentNullException (nameof(prijavaTakmicaraBorbe));

            }

            var postojecaPrijava = await _dbContext.PrijavaTakmicaraBorbes.FindAsync(prijavaTakmicaraBorbe.Id);

            if (postojecaPrijava != null)
            {
                postojecaPrijava.IdTakmicara=prijavaTakmicaraBorbe.IdTakmicara;
                postojecaPrijava.Kilaza = prijavaTakmicaraBorbe.Kilaza;
                postojecaPrijava.Pol= prijavaTakmicaraBorbe.Pol;
                postojecaPrijava.Godiste= prijavaTakmicaraBorbe.Godiste;
                postojecaPrijava.Individualno=prijavaTakmicaraBorbe.Individualno;
                postojecaPrijava.Ekipno=prijavaTakmicaraBorbe.Ekipno;

                _dbContext.PrijavaTakmicaraBorbes.Update(postojecaPrijava);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<PrijavaTakmicaraBorbe> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaBorbeId)
        {
            var postojeciTakmicar = await _dbContext.PrijavaTakmicaraBorbes.FindAsync(prijavaTakmicara);

            if(postojeciTakmicar != null)
            {
                postojeciTakmicar.IdEkipe = ekipaBorbeId;

                _dbContext.PrijavaTakmicaraBorbes.Update(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
                return postojeciTakmicar;
            }
            else
            {
                throw new ArgumentException("Takmicar nije pronadjen");
            }
        }
        public async Task DeleteAsync(PrijavaTakmicaraBorbe prijavaTakmicara)
        {
            if (prijavaTakmicara == null)
            {
                throw new ArgumentNullException(nameof(prijavaTakmicara));
            }

            var postojeciTakmicar = await _dbContext.PrijavaTakmicaraBorbes.FindAsync(prijavaTakmicara.Id);

            if (postojeciTakmicar != null)
            {
                _dbContext.PrijavaTakmicaraBorbes.Remove(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<PrijavaTakmicaraBorbe> GetById(int id)
        {
            return await _dbContext.PrijavaTakmicaraBorbes.FindAsync(id);
        }
        public async Task<List<PrijavaTakmicaraBorbe>> GetAllAsync()
        {
            return await _dbContext.PrijavaTakmicaraBorbes.ToListAsync();
        }

        public async Task<PrijavaTakmicaraBorbe> GetByImeIPrezimeAsync(string ime, string prezime)
        {
            var takmicar = await _dbContext.Takmicari.FirstOrDefaultAsync(t => t.Ime == ime && t.Prezime == prezime);

            if (takmicar == null)
                return null;

            return await _dbContext.PrijavaTakmicaraBorbes
                .FirstOrDefaultAsync(p => p.IdTakmicara == takmicar.Id);
        }

        public async Task<List<PrijavaTakmicaraBorbe>> GetByKategorija(string pol, string godiste, string kilaza)
        {
            return await _dbContext.PrijavaTakmicaraBorbes.Where(p => p.Pol == pol && p.Godiste == godiste && p.Kilaza == kilaza).ToListAsync();
        }
    }
}
