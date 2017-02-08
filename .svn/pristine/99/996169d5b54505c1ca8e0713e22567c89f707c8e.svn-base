using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Nabavka:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public decimal CijenaBezPDV { get; set; }
        public decimal CijenaSaPDV { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool Isporuceno { get; set; }
        public bool Odobreno { get; set; }
        public bool Ponisteno { get; set; }


        public virtual Dobavljac Dobavljac { get; set; }
        public int DobavljacId { get; set; }

        public virtual Skladiste Skladiste { get; set; }
        public int SkladisteId { get; set; }

        public virtual Zaposlenik Zaposlenik { get; set; }
        public int ZaposlenikId { get; set; }
    }
}