using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Voz:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool KretanjeVoza{get;set;}

        public virtual Lokomotiva Lokomotiva { get; set; }
        public int LokomotivaId { get; set; }
    }
}