using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{



    internal class Skladiste
    {

        public string id { get; set; }
        public string BrojProizvoda { get; private set; }
        public string ProtivPozarniSistem { get; set; }
        public string Kapacitet { get; set; }
        public string Vrsta { get; set; }
        public string Status{ get; set; }
        public string idStanice { get; set; }

        public Skladiste(string pid,string pbP,string ppS,string ka,string vr,string st,string idS) {
        this.id = pid;
            this.BrojProizvoda = pbP;
            this.ProtivPozarniSistem = ppS;
            this.Kapacitet = ka;
            this.Vrsta = vr;
            this.Status = st;
            this.idStanice = idS;
        }
    }
}
