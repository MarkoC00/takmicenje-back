using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PrijavaTakmicaraBorbe
    {

        public int Id { get; set; }

        public int IdTakmicara { get; set; }
        public int IdEkipe { get; set; }
        public string Kilaza { get; set; }

        public string Pol {  get; set; }

        public string Godiste { get; set; }

        public bool Individualno { get; set; }

        public bool Ekipno { get; set; }

        
    }
}
