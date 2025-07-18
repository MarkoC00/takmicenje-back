using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Klub 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashSifra { get; set; }
        public string ImeKluba { get; set; }
        public string Grad { get; set; }
        public string Zip { get; set; }
        public string Drzava { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
    }
}
