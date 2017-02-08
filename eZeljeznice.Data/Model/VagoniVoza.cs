using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class VagoniVoza:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DatumKreiranja { get; set; }
        public int RedniBroj { get; set; }

        public virtual Vagon Vagon { get; set; }
        public int VagonId { get; set; }

        public virtual Voz Voz { get; set; }
        public int VozId { get; set; }
    }
}