using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class LokomotivaPrikaziVM
    {
        public class LokomotivaInfo
        {

            public int Id { get; set; }
           

            public string Naziv { get; set; }
            public DateTime DatumProizvodnje { get; set; }
            public string SerijskiBroj { get; set; }
            public bool Aktivan { get; set; }
            public string TipLokomotive { get; set; }

        


        }

        public List<LokomotivaInfo> lokomotive { get; set; }
        public int TipLokomotiveId { get; set; }
        public List<SelectListItem> tipoviLokomotivaStavke { get; set; }


    }
}