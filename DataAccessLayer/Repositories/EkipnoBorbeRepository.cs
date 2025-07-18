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
    public class EkipnoBorbeRepository : IEkipnoBorbeRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public EkipnoBorbeRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(EkipnoBorbe ekipa)
        {
            if(ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            await _dbContext.EkipnoBorbe.AddAsync(ekipa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(EkipnoBorbe ekipa)
        {
            if (ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            var postojecaEkipa = await _dbContext.EkipnoBorbe.FindAsync(ekipa.Id);

            if (postojecaEkipa != null)
            {
               _dbContext.EkipnoBorbe.Remove(ekipa);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(EkipnoBorbe ekipa)
        {
            if(ekipa == null)
            {
                throw new ArgumentNullException(nameof(ekipa));
            }

            var postojecaEkipa = await _dbContext.EkipnoBorbe.FindAsync(ekipa.Id);

            if(postojecaEkipa != null)
            {
                postojecaEkipa.IdKLuba = ekipa.IdKLuba;
                postojecaEkipa.ImeEkipe = ekipa.ImeEkipe;
                postojecaEkipa.Pol = ekipa.Pol;
                postojecaEkipa.Uzrast= ekipa.Uzrast;

                _dbContext.EkipnoBorbe.Update(postojecaEkipa);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<EkipnoBorbe> GetById(int id)
        {
            return await _dbContext.EkipnoBorbe.FindAsync(id); 
        }

        public async Task<List<EkipnoBorbe>> GetAll()
        {
            return await _dbContext.EkipnoBorbe.ToListAsync();
        }

        public async Task<EkipnoBorbe> GetByImeEkipe(string imeEkipe)
        {
            return await _dbContext.EkipnoBorbe.FirstOrDefaultAsync(e => e.ImeEkipe == imeEkipe);
        }

        public async Task<List<EkipnoBorbe>> GetByKlub(int klub)
        {

            return await _dbContext.EkipnoBorbe.Where(e => e.IdKLuba == klub).ToListAsync();
        }

        public async Task<List<EkipnoBorbe>> GetByKlasa(string pol, string uzrast)
        {
            return await _dbContext.EkipnoBorbe.Where(e => e.Pol == pol && e.Uzrast == uzrast).ToListAsync();
        }
    }
}
