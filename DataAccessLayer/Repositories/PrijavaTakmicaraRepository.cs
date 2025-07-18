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
    public class PrijavaTakmicaraRepository : IPrijavaTakmicaraRepository 
    {

        private readonly ApplicationDBContext _dbContext;

        public PrijavaTakmicaraRepository (ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task CreateAsync(Takmicar takmicar)
        {
            if (takmicar == null)
            {
                throw new ArgumentNullException(nameof(takmicar));
            }

            PrijavaTakmicara prijava = new PrijavaTakmicara();
            prijava.IdTakmicara = takmicar.Id;
            prijava.GodisteTakmicara = takmicar.Godiste;
            prijava.PolTakmicara = takmicar.Pol.ToString();
            prijava.KlasaTakmicara = RacunanjeKlase(takmicar.Godiste, takmicar.Pojas);
            prijava.Apsolutni = false;
            prijava.Klasa = false; 
            prijava.Ekipno = false;
            prijava.IdEkipe = null;

            await _dbContext.PrijavaTakmicaras.AddAsync(prijava);
            await _dbContext.SaveChangesAsync();
        }



        private string RacunanjeKlase(string godiste, string pojas)
        {
            int trenutnaGodina = DateTime.Now.Year;

            //2016+
            if (int.Parse(godiste) >= trenutnaGodina-9)
            {
                if (pojas == "Zuti")
                    return "E";

                if (pojas == "Narandzasti")
                    return "D";

                if (pojas == "Zeleni")
                    return "C";
            }

            //2015
            if (int.Parse(godiste) == trenutnaGodina - 10)
            {
                if (pojas == "Zuti")
                    return "E";

                if (pojas == "Narandzasti")
                    return "D";

                if (pojas == "Zeleni")
                    return "C";
            }

            //2014
            if (int.Parse(godiste) == trenutnaGodina - 11)
            {
                if (pojas == "Zuti")
                    return "E";

                if (pojas == "Narandzasti")
                    return "E";

                if (pojas == "Zeleni")
                    return "C";

                if (pojas == "Plavi")
                    return "C";

            }

            //2013
            if (int.Parse(godiste) == trenutnaGodina - 12)
            {
                if (pojas == "Zuti")
                    return "E";

                if (pojas == "Narandzasti")
                    return "E";

                if (pojas == "Zeleni")
                    return "C";

                if (pojas == "Plavi")
                    return "C";

            }

            //2012
            if (int.Parse(godiste) == trenutnaGodina - 13)
            {
                if (pojas == "Zuti")
                    return "E";

                if (pojas == "Narandzasti")
                    return "E";

                if (pojas == "Zeleni")
                    return "C";

                if (pojas == "Plavi")
                    return "C";

            }

            //2011
            if (int.Parse(godiste) == trenutnaGodina - 14)
            {
                if (pojas == "Zuti")
                    return "EC";

                if (pojas == "Narandzasti")
                    return "EC";

                if (pojas == "Zeleni")
                    return "CB";

                if (pojas == "Plavi")
                    return "CB";

            }

            //KADETI 2010,
            if (int.Parse(godiste) == trenutnaGodina - 15 )
            {
                if (pojas == "Zuti")
                    return "C";

                if (pojas == "Narandzasti")
                    return "C";

                if (pojas == "Zeleni")
                    return "B";

                if (pojas == "Plavi")
                    return "B";

            }

            //2009
            if (int.Parse(godiste) == trenutnaGodina - 16)
            {
                if (pojas == "Zuti")
                    return "C0";

                if (pojas == "Narandzasti")
                    return "C0";

                if (pojas == "Zeleni")
                    return "B0";

                if (pojas == "Plavi")
                    return "B0";

            }

            //2008 2007
            if (int.Parse(godiste) == trenutnaGodina - 17 || int.Parse(godiste) == trenutnaGodina - 18)
            {
                    return "0A";
            }

            // 2006 I STARIJE
            if ( int.Parse(godiste) <= trenutnaGodina - 19)
            {
                return "A";

            }

            return "X";

        }
       public async Task UpdateAsync(PrijavaTakmicara takmicar)
        {
            if (takmicar == null)
            {
                throw new ArgumentNullException (nameof(takmicar));
            }

            var postojeciTakmicar = await _dbContext.PrijavaTakmicaras.FindAsync(takmicar.Id);

            if ( postojeciTakmicar != null )
            {
                postojeciTakmicar.Apsolutni = takmicar.Apsolutni;
                postojeciTakmicar.Klasa = takmicar.Klasa;

                _dbContext.PrijavaTakmicaras.Update(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PrijavaTakmicara> GetByIdAsync(int id)
        {
            return await _dbContext.PrijavaTakmicaras.FindAsync(id);
        }

        public async Task<PrijavaTakmicara> GetByImeIPrezimeAsync(string ime, string prezime)
        {
            var takmicar =  await _dbContext.Takmicari.FirstOrDefaultAsync(t => t.Ime == ime && t.Prezime == prezime);

            if (takmicar == null)
                return null;

            return await _dbContext.PrijavaTakmicaras
                .FirstOrDefaultAsync(p => p.IdTakmicara == takmicar.Id);
        }

        public async Task<List<PrijavaTakmicara>> GetByKategorija(string pol, string godiste, string klasa)
        {
            return await _dbContext.PrijavaTakmicaras.Where(p => p.PolTakmicara == pol && p.GodisteTakmicara == godiste && p.KlasaTakmicara == klasa).ToListAsync();
        }

        public async Task<List<PrijavaTakmicara>> GetAllAsync()
        {
            return await _dbContext.PrijavaTakmicaras.ToListAsync();
        }

        public async Task DeleteAsync(PrijavaTakmicara takmicar)
        {
            if(takmicar == null)
            {
                throw new ArgumentNullException(nameof(takmicar));
            }

            var postojeciTakmicar = await _dbContext.PrijavaTakmicaras.FindAsync(takmicar.Id);

            if (postojeciTakmicar != null)
            {
                _dbContext.PrijavaTakmicaras.Remove(postojeciTakmicar);
                await _dbContext.SaveChangesAsync();
            }
;       }

        public async Task<PrijavaTakmicara> PrijavaTakmicaraUTimAsync(int prijavaTakmicara, int ekipaKateId)
        {
            var prijava = await _dbContext.PrijavaTakmicaras.FindAsync(prijavaTakmicara);

            if (prijava == null) return null;
            
            prijava.IdEkipe = ekipaKateId;

            await _dbContext.SaveChangesAsync();
            return prijava;

        }
    }
}
