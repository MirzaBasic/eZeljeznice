using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class TipVagonaUrediVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }

        public string Opis { get; set; }
    }
}