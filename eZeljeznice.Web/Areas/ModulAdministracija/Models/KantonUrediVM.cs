using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class KantonUrediVM
    {


        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Oznaka { get; set; }
        public int DrzavaId { get; set; }

        public List<SelectListItem> Drzave { get; set; }
    }
}