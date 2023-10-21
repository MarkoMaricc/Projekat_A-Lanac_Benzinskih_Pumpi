using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    class Proizvod
    {
        public string Vrsta { get; set; }
        public string Cena { get; set; }
        public string idSkladista { get; set; }

        public Proizvod(string pVrsta, string pCena, string pIdSkladista)
        {
            this.Vrsta = pVrsta;
            this.Cena = pCena;
            this.idSkladista = pIdSkladista;
        }

    }
}
