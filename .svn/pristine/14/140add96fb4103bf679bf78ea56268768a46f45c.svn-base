using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class UlogeKorisnika : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DatumKreiranja { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }

        public virtual Uloga Uloga { get; set; }
        public int UlogaId { get; set; }

    }
}