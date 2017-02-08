using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class VagonPrikaziVM
    {
        public class VagonInfo {


            public int Id { get; set; }
            

            public string Naziv { get; set; }
            public string SerijskiBroj { get; set; }
            public DateTime DatumProizvodnje { get; set; }
            public string BrojSjedista { get; set; }
            public bool Aktivan { get; set; }

            public string TipVagona { get; set; }
       
        }

        public List<VagonInfo> vagoni { get;set; }

        public List<SelectListItem> tipoviVagonaStake { get; set; }
        public int tipVagonaId { get; set; }

    }
}