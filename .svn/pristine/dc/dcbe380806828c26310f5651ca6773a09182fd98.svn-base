using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Lokomotiva : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }
        public DateTime DatumProizvodnje { get; set; }
        public string SerijskiBroj { get; set; }
        public bool Aktivan { get; set; }

        public virtual TipLokomotive TipLokomotive { get; set; }
        public int TipLokomotiveId { get; set; }
    }
}