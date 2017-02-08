using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Karta:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

      public string SerijskiBroj { get; set; }
      public DateTime VrijemePolaska { get; set; }
      public decimal CijenaSaPDV { get; set; }
      public decimal CijenaBezPDV { get; set; }
      public decimal Popust { get; set; }
      public int Kolicina { get; set; }
      public int BrojSjedista { get; set; }
      public DateTime DatumKupovine { get; set; }
      public DateTime DatumIstekaKarte { get; set; }
      
        public virtual TipKarte TipKarte { get; set;}
        public int TipKarteId { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public int ZaposlenikId { get; set; }

        public virtual LinijaVoznje LinijaVoznje { get; set; }
        public int LinijaVoznjeId { get; set; }

        public virtual Rezervacija Rezervacija { get; set; }
        public int? RezervacijaId { get; set; }
    }
}