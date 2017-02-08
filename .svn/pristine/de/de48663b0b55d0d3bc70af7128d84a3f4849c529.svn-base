using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZeljeznice.Data.Model
{
    public class Vagon : IEntity
    {
        public int Id { get; set; }
       
        public bool IsDeleted { get; set; }


        public string Naziv { get; set; }
        public string SerijskiBroj { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public int BrojSjedista { get; set; }
        public bool Aktivan { get; set; }

        public virtual TipVagona TipVagona { get; set; }
        public int TipVagonaId { get; set; }


    }
}
