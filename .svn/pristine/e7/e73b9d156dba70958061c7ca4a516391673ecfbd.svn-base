using eZeljeznice.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class KorisnikUrediVM
    {
        [Required(ErrorMessage ="Obavezno polje")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }
   
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Mora imati 13 brojeva")]
        public string JMBG { get; set; }

        [StringLength(19, MinimumLength = 13, ErrorMessage = "Mora imati izmdju 13 i 19 brojeva")]
        public string BrojKreditenKartice { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Mora imati izmedju 4 i 20 karaktera")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Mora imati izmedju 5 i 30 karaktera")]
        public string Lozinka { get; set; }
        public bool Aktivan { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Validator), "ValidateDate")]
        public DateTime DatumRodjenja { get; set; }
        public int Id { get; set; }
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        [EmailAddress(ErrorMessage = "Nije ispravan format email-a")]
        public string Email { get; set; }
        [StringLength(13, MinimumLength = 9, ErrorMessage = "Mora imati izmedju 9 i 13 brojeva")]
        public string Telefon { get; set; }
        [StringLength(13, MinimumLength = 9, ErrorMessage = "Mora imati izmedju 9 i 13 brojeva")]
        public string Fax { get; set; }
        public string NazivFirme { get; set; }
       
        public int GradId { get; set; }

       
        public List<SelectListItem> gradoviStavke { get; set; }
        public List<SelectListItem> ulogeStavke { get; set; }
    }

   
}