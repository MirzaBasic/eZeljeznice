using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class LinijaVoznje :IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string NazivLinije { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public string Napomena { get; set; }
        public bool Aktivan { get; set; }

        public virtual Voz Voz { get; set; }
        public int VozId { get; set; }


        public virtual TipLinije TipLinije { get; set; }
        public int TipLinijeId { get; set; }
    }
}