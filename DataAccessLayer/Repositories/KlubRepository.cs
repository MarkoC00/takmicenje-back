using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories
{
    public class KlubRepository : IKlubRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public KlubRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task CreateAsync(Klub klub)
        {
            if(klub == null)
            {
                throw new ArgumentNullException(nameof(klub));
            }

            bool isEmpty = !await _dbContext.Klub.AnyAsync();
            if (isEmpty) {
                await _dbContext.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT('dbo.klub', RESEED, 0);");
            }

            await _dbContext.Klub.AddAsync(klub);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Klub klub)
        {
            if (klub == null)
            {
                throw new ArgumentNullException(nameof(klub));
            }

            var postojeciKlub = await _dbContext.Klub.FindAsync(klub.Id);

            if (postojeciKlub != null)
            {
                postojeciKlub.Email = klub.Email;
                postojeciKlub.HashSifra = klub.HashSifra;
                postojeciKlub.ImeKluba = klub.ImeKluba;
                postojeciKlub.Grad = klub.Grad;
                postojeciKlub.Zip = klub.Zip;
                postojeciKlub.Drzava = klub.Drzava;
                postojeciKlub.Adresa = klub.Adresa;
                postojeciKlub.BrojTelefona = klub.BrojTelefona;

                _dbContext.Klub.Update(postojeciKlub);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(Klub klub)
        {
            if (klub == null)
            {
                throw new ArgumentNullException(nameof(klub));
            }

            var postojeciKlub = await _dbContext.Klub.FindAsync(klub.Id);

            if(postojeciKlub != null)
            {
                _dbContext.Klub.Remove(postojeciKlub);
                await _dbContext.SaveChangesAsync();
            }

        }
        public async Task<List<Klub>> GetAllAsync()
        {
            return await _dbContext.Klub.ToListAsync();
        }

        public async Task<Klub> GetByIdAsync(int id)
        {
            return await _dbContext.Klub.FindAsync(id);
        }

        public async Task<Klub> GetByEmailAsync(string email)
        {
            var klub = await _dbContext.Klub.FirstOrDefaultAsync(x => x.Email == email);

            return klub;
        }
        public async Task<List<Klub>> GetByImeKlubaAsync(string searchQuery = "")
        {
            return await _dbContext.Klub
                .Where(klub => klub.ImeKluba.StartsWith(searchQuery))
                .ToListAsync();
        }
        public async Task<List<Klub>> GetByGradAsync(string searchQuery)
        {
            return await _dbContext.Klub
                .Where(klub => klub.Grad.StartsWith(searchQuery))
                .ToListAsync();
        }
        
        public async Task<List<Klub>> GetByDrzavaAsync(string searchQuery)
        {
            return await _dbContext.Klub
                .Where(klub => klub.Drzava.StartsWith(searchQuery))
                .ToListAsync();
        }
    }
}
