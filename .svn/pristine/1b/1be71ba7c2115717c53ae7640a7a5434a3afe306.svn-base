using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eZeljeznice.Data.Model;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class ZaposlenikPrikaziVM
    {
        public class ZaposlenikInfo
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string JMBG { get; set; }
            public string BrojKreditenKartice { get; set; }
            public string KorisnickoIme { get; set; }
            public bool Aktivan { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string TipZaposljenja { get; set; }
            public int Id { get; set; }
            public string Adresa { get; set; }
            public string Grad { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string Fax { get; set; }

            public byte[] Slika { get; set; }

        }


        public List<ZaposlenikInfo> zaposlenici; 
        public int gradId { get; set; }
        public List<SelectListItem> gradoviStavke { get; set; }
        public int tipZaposlenikaId { get; set; }
        public List<SelectListItem> tipoviZaposlenikaStavke { get; set; }


       
    }
}