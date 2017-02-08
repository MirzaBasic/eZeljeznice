using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class LokomotivaUrediVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Validator), "ValidateDate")]
        public DateTime DatumProizvodnje { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string SerijskiBroj { get; set; }
        public bool Aktivan { get; set; }
        public int TipLokomotiveId { get; set; }



        public List<SelectListItem> tipoviLokomotivaStavke { get; set; }
    }
}