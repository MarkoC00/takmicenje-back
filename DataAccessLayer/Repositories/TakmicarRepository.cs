using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TakmicarRepository : ITakmicarRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TakmicarRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task CreateAsync(Takmicar takmicar)
        {
            if (takmicar == null)
            {
                throw new ArgumentNullException(nameof(takmicar));  
            }

            bool isEmpty = !await _dbContext.Takmicari.AnyAsync();
            if (isEmpty)
            {
                await _dbContext.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('dbo.takmicar', RESEED, 0);");
            }

            await _dbContext.Takmicari.AddAsync(takmicar);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Takmicar takmicar)
        {
            if (takmicar == null)
            {
                throw new ArgumentNullException(nameof(takmicar));
            }

            var postojeciTakmicar = await _dbContext.Takmicari.FindAsync(takmicar.Id);

            if(postojeciTakmicar != null)
            {
                _dbContext.Takmicari.Remove(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task UpdateAsync(Takmicar takmicar)
        {
            if  (takmicar == null)
            {
                throw new ArgumentNullException(nameof(takmicar));
            }

            var postojeciTakmicar = await _dbContext.Takmicari.FindAsync(takmicar.Id);
            if (postojeciTakmicar != null)
            {
                postojeciTakmicar.IdKluba = takmicar.IdKluba;
                postojeciTakmicar.Ime = takmicar.Ime;
                postojeciTakmicar.Prezime = takmicar.Prezime;
                postojeciTakmicar.Pol = takmicar.Pol;
                postojeciTakmicar.Godiste = takmicar.Godiste;
                postojeciTakmicar.Pojas = takmicar.Pojas;

                _dbContext.Takmicari.Update(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Takmicar>> GetAllAsync()
        {
            return await _dbContext.Takmicari.ToListAsync();  
        }

        public async Task<Takmicar> GetByIdAsync(int id)
        {
            return await _dbContext.Takmicari.FindAsync(id);
        }

        public async Task<Takmicar> GetByImeIPrezimeAsync(string ime, string prezime)
        {
            return await _dbContext.Takmicari.FirstOrDefaultAsync(t => t.Ime == ime && t.Prezime == prezime);
        }

    }
}
