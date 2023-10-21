using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    class Racun
    {
        public string idRacune { get; set; }
        public string Datum { get; set; }
        public string Cena { get; set; }
        public string idKlase { get; set; }

        public Racun(string idR, string dat, string cen, string idK)
        {

            this.idRacune = idR;
            this.Datum = dat;
            this.Cena = cen;
            this.idKlase = idK;
        }
    }
}
