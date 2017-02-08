using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class UlogaKorisnikaUrediVM
    {


        public int Id { get; set; }
    

       
       
        public int KorisnikId { get; set; }

        public int UlogaId { get; set; }

        public List<SelectListItem> ulogeStavke { get; set; }
    }
}