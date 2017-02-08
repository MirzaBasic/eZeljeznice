using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class StanicaLinije : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }

        public virtual LinijaVoznje LinijaVoznje { get; set; }
        public int LinijaVoznjeId { get; set; }

        public virtual Stanica Stanica { get; set; }
        public int StanicaId { get; set; }
    }
}