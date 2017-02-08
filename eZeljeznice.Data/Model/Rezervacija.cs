using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Rezervacija:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DatumRezervacije { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

        public virtual LinijaVoznje LinijaVoznje { get; set; }
        public int LinijaVoznjeId{get;set;}
    }
}