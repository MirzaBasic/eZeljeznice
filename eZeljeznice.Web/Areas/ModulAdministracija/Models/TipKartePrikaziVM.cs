using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class TipKartePrikaziVM
    {
        public class TipKarteInfo
        {

            public int Id { get; set; }


            public string Naziv { get; set; }

           

            public int Popust { get; set; }
        }

        public List<TipKarteInfo> TipoviKarte { get;set;}
    }
}