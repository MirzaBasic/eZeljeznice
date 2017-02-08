using eZeljeznice.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class UlogaPrikaziVM
    {
        public class UlogaInfo
        {
            public int Id { get; set; }


            public string Naziv { get; set; }

            public string Opis { get; set; }

        }

        public List<UlogaInfo> Uloge { get; set; }
    }
}