using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    class Stavka
    {
        public string idStavke { get; set; }
        public string Kolicina { get; set; }
        public string Cena { get; set; }
        public string idRacuna { get; set; }
        public string ProizvodVrsta { get; set; }

        public Stavka(string idS, string kol, string cen, string idR, string prV)
        {
            this.idStavke = idS;
            this.Kolicina = kol;
            this.Cena = cen;
            this.idRacuna = idR;
            this.ProizvodVrsta = prV;

        }
    }
}
