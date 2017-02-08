﻿using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Korisnik : IEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public string BrojKreditenKartice { get; set; }


        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Aktivan { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Adresa { get; set; }
        public string Email { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public string NazivFirme { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }

        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }





    }
}