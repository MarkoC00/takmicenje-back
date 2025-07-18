using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class EkipnoKateRepository : IEkipnoKateRepository
    {

       private readonly ApplicationDBContext _dbContext;

        public EkipnoKateRepository(ApplicationDBContext dbContext) { _dbContext = dbContext; }
        
        public async Task CreateAsync(EkipnoKate ekipa){
            if(ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            var postoji = await _dbContext.EkipnoKate.AnyAsync(e => e.ImeEkipe == ekipa.ImeEkipe);

            if(postoji != null)
            {
                throw new InvalidOperationException("Ekipa sa istim imenom ve' postoji");
            }

            _dbContext.EkipnoKate.Add(ekipa);
            
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(EkipnoKate ekipa)
        {
            if (ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            var postojecaEkipa = await _dbContext.EkipnoKate.FindAsync(ekipa.Id);

            if(postojecaEkipa != null)
            {
                postojecaEkipa.IdKLuba = ekipa.IdKLuba;
                postojecaEkipa.ImeEkipe = ekipa.ImeEkipe;
                postojecaEkipa.Uzrast = ekipa.Uzrast;
                postojecaEkipa.Pol = ekipa.Pol;

                _dbContext.EkipnoKate.Update(postojecaEkipa);

                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(EkipnoKate ekipa)
        {
            if(ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            var postojecaEkipa = await _dbContext.EkipnoKate.FindAsync(ekipa.Id);

            if( postojecaEkipa != null)
            {
                _dbContext.EkipnoKate.Remove(postojecaEkipa);
                
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<EkipnoKate>> GetAllAsync()
        {
            return await _dbContext.EkipnoKate.ToListAsync();
        }

        public async Task<EkipnoKate> GetByIdAsync(int id)
        {
            return await _dbContext.EkipnoKate.FindAsync(id);
        }

        public async Task<EkipnoKate> GetByImeEkipeAsync(string imeEkipe)
        {
            return await _dbContext.EkipnoKate.FirstOrDefaultAsync(e => e.ImeEkipe == imeEkipe);
        }

        
        public async  Task<List<EkipnoKate>> GetAllByPoliUzrast(string pol, string uzrast) 
        { 
          return await _dbContext.EkipnoKate.Where(e => e.Pol == pol && e.Uzrast == uzrast).ToListAsync();
        }

        public async Task<List<EkipnoKate>> GetAllByKlub(int idKluba)
        {
            return await _dbContext.EkipnoKate.Where(e => e.IdKLuba == idKluba).ToListAsync();
        }
    }
}
