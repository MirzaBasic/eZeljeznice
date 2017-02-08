
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
   
    public class VagonUrediVM
    {

        protected string dateMax = DateTime.Now.ToString("dd/MM/yyyy");
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string SerijskiBroj { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Validator), "ValidateDate")]
        public DateTime DatumProizvodnje { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [Range(0,100,ErrorMessage ="Mora biti izmedju 0 i 100 sjedista")]
        public int BrojSjedista { get; set; }
        public bool Aktivan { get; set; }

        public int TipVagonaId { get; set; }

   

        public List<SelectListItem> tipoviVagonaStavke { get; set; }
    }
   

}