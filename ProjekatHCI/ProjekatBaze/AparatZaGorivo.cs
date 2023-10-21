using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    internal class AparatZaGorivo
    {
        public string idTocilice { get; set; }
        public string Vrsta { get; private set; }
        public string Materijal { get; set; }
        public string Proizvodjac { get; set; }
        public string idStanice { get; set; }

        public AparatZaGorivo(string id,string vr,string ma,string pr,string idS) { 
        this.idTocilice = id;
            this.Vrsta = vr;
            this.Materijal = ma;
            this.Proizvodjac = pr;
            this.idStanice = idS;
        }
    }
}
