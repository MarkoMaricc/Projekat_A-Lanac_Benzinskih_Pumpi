using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
   
    internal class Radnik
    {
        public string id { get; set; }
        public string JMBG { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string Uloga { get; set; }
        public string Plata { get; set; }
        public string PlatniTroskovi { get; set;}
        public string BrojLicneKarte{ get;set; }
        public string DatumRodjenja { get; set; }
        public string idStanice { get;set; }

        public Radnik(string id,string jmbg,string pr,string ime,string ul,string pl,string pt,string blk,string dr,string idS) { 
        this.JMBG=jmbg;
            this.Prezime=pr;
            this.Ime=ime;
                      this.Uloga=ul;
            this.Plata=pl;
            this.DatumRodjenja=dr;
            this.PlatniTroskovi = pt;
            this.BrojLicneKarte=blk;
            this.idStanice = idS;
                this.id=id;
        }




    }
}
