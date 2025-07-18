using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Takmicar
    {
        public int Id { get; set; }
        public int IdKluba { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Godiste { get; set; }
        public string Pojas { get; set; }

    }
    public enum Pol {MUŠKO,ŽENSKO}
}
