using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZeljeznice.Data.Model
{
   public class Obavijest:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Opis { get; set; }
        public string Sadrzaj { get; set; }
        public bool Aktivan { get; set; }


        public virtual Zaposlenik Zaposlenik { get; set; }
        public int ZaposlenikId { get; set; }
    }
}
