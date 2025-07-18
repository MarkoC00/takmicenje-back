using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Contracts
{
    public interface IEkipnoBorbeRepository
    {
        Task Create(EkipnoBorbe ekipa);

        Task Delete (EkipnoBorbe ekipa);

        Task Update (EkipnoBorbe ekipa);

        Task<EkipnoBorbe> GetById (int id);

        Task<List<EkipnoBorbe>> GetAll();

        Task<EkipnoBorbe> GetByImeEkipe(string imeEkipe);

        Task<List<EkipnoBorbe>> GetByKlub (int klub);

        Task<List<EkipnoBorbe>> GetByKlasa (string pol, string uzrast);

        
    }
}
