using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Dobavljac : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        
        public string NazivFirme { get; set; }
        public string KontaktOsoba { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Opis { get; set; }
        public bool Aktivan { get; set; }


        public virtual Grad Grad { get; set; }
        public int GradId { get; set; }
    }
}