using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class GradPrikaziVM
    {

        public class GradInfo
        {

            public int Id { get; set; }
            public string Naziv { get; set; }
            public int PostanskiBroj { get; set; }
           
        }

        public List<GradInfo> Gradovi { get; set; }
        public int KantonId { get; set; }
        public string Kanton { get; set; }
    }
}