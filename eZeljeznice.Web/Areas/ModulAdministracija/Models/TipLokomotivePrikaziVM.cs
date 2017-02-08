using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class TipLokomotivePrikaziVM
    {
        public class TipLokomotiveInfo
        {

            public int Id { get; set; }


            public string Naziv { get; set; }

            public string Opis { get; set; }
        }

        public List<TipLokomotiveInfo> TipoviLokomotiva { get;set;}
    }
}