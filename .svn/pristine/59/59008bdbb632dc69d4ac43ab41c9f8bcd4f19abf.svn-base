using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Proizvod:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }


        public string Naziv { get; set; }
        public string Sifta { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }

        public virtual PodkategorijeProizvoda PodkategorijeProizvoda { get; set; }
        public int PodkategorijeProizvodaId { get; set; }


    }
}