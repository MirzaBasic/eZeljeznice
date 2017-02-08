using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class GradUrediVM
    {


        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public int PostanskiBroj { get; set; }
        public int KantonId { get; set; }

        public List<SelectListItem> Kantoni { get; set; }
    }
}
