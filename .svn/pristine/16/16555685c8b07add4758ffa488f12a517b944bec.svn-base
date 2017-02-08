using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Kvar:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }


        public DateTime VrijemeKvara { get; set; }
        public string OpisKvara { get; set; }
        public string Napomena { get; set; }
        public bool Popravljeno { get; set; }
        public DateTime? VrijemePopravke { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public int ZaposlenikId { get; set; }

        public virtual Voz Voz { get; set; }
        public int? VozId { get; set; }

        public virtual KategorijaKvara KategorijaKvara { get; set; }
        public int KategorijaKvaraId { get; set; }

    }
}