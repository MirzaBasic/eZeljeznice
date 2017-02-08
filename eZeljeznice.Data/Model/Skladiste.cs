using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Skladiste:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Adresa { get; set; }

        public virtual Grad Grad { get; set; }
        public int GradId { get; set; }
    }
}