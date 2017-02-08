using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Stanica : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

       public string NazivStanice { get; set; }
       public string Oznaka { get; set; }
       public string Broj { get; set; }
       public bool Aktivan { get; set; }
       public string Adresa { get; set; }
   
       public virtual Grad Grad { get; set; }
       public int GradId { get; set; }
    
       public virtual TipStanice TipStanice { get; set; }
       public int TipStaniceId { get; set; }
    }
}