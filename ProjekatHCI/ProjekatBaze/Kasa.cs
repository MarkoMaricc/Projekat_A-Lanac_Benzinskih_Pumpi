using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    internal class Kasa
    {
        public string id { get; set; }
        public string NacinPlacanja { get; private set; }
        public string Vrsta { get; set; }
        public string idStanice { get; set; }


        public Kasa(string pid,string pNp,string pV,string pidS) {
        this.id = pid;
            this.NacinPlacanja = pNp;
            this.Vrsta = pV;
            this.idStanice = pidS;
        
        }   
    }
}
