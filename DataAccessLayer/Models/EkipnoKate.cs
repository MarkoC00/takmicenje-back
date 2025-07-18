using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class EkipnoKate
    {
        public int Id { get; set; }
        public int IdKLuba { get; set; }
        public string ImeEkipe { get; set; }
        public string Uzrast {  get; set; }
        public string Pol {  get; set; }

    }
}
