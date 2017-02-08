using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class StavkeNabavke:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int Kolicina { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public int ProizvodId { get; set; }

        public virtual Nabavka Nabavka { get; set; }
        public int NabavkaId { get; set; }
    }
}