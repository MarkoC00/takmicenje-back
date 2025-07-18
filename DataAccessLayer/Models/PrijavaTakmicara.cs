using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class PrijavaTakmicara
    {
        public int Id { get; set; } 
        public int IdTakmicara { get; set; }

        public int? IdEkipe { get; set; }
        public string GodisteTakmicara { get; set; }
        public string KlasaTakmicara { get; set; }
        public bool Klasa { get; set; }
        public bool Apsolutni { get; set; }
        public bool Ekipno { get; set; }
        public string PolTakmicara { get; set; }

    }
}
