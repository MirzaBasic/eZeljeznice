﻿using eZeljeznice.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Data.Model
{
    public class Kanton : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
       public string  Naziv { get; set; }
       public string Oznaka { get; set; }

        public virtual Drzava Drzava { get; set; }
        public int DrzavaId { get; set; }
    }
}