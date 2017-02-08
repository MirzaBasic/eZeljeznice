using eZeljeznice.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool IsAdministrator;



        public Autorizacija(bool IsAdministrator)
        {
            this.IsAdministrator = IsAdministrator;
        }

        public void OnAuthorization(AuthorizationContext filter)
        {
            Zaposlenik PrijavljeniZaopslenik = Autentifikacija.GetLogiraniZaposlenik(filter.HttpContext);

            bool pristupOdobren = false;

            if (PrijavljeniZaopslenik != null)
            {
                if (PrijavljeniZaopslenik.TipZaposlenika.Naziv == "Administrator")
                    pristupOdobren = true;

              
            }

            if (!pristupOdobren)
                filter.HttpContext.Response.Redirect("/Home/Index");


        }
    }
}