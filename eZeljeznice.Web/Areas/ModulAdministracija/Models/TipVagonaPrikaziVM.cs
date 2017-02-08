using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class TipVagonaPrikaziVM
    {
        public class TipVagonaInfo
        {

            public int Id { get; set; }


            public string Naziv { get; set; }

            public string Opis { get; set; }
        }

        public List<TipVagonaInfo> TipoviVagona { get;set;}
    }
}