using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBaze
{
    internal class BenzinskeStanice
    {
        public string id { get; set; }
        public string Adresa { get;  set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Telefon { get; set; }
        public string email { get; set; }
        public string brojParkingMjesta { get; set; }
        public string Naziv { get; set; }
       
        public BenzinskeStanice(string pid,string pAdresa,string pGrad,string pD,string pT,string pem,string brP,string Naziv) {
        
        this.id = pid;
            this.Adresa = pAdresa;
            this.Grad = pGrad;
         this.Drzava = pD;
            this.Telefon = pT;
             this.email = pem;
            this.brojParkingMjesta = brP;
            this.Naziv = Naziv;
        }
    }
}
