using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class TipZaposlenikaPrikaziVM
    {
        public class TipZaposlenikaInfo
        {

            public int Id { get; set; }


            public string Naziv { get; set; }

            public string Opis { get; set; }
        }

        public List<TipZaposlenikaInfo> TipoviZaposlenika {get;set;}
    }
}