using eZeljeznice.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Helper
{
    public class Autentifikacija
    {

        private const string LogiraniZaposlenik = "logirani_korisnik";

        public static void PokreniNovuSesiju(Zaposlenik zaposlenik, HttpContextBase context, bool zapamtiPassword)
        {
            context.Session.Add(LogiraniZaposlenik, zaposlenik);

            if (zapamtiPassword)
            {
                HttpCookie cookie = new HttpCookie("_mvc_session", zaposlenik?.Id.ToString() ?? "");
                cookie.Expires = DateTime.Now.AddDays(10);
                context.Response.Cookies.Add(cookie);
            }
        }

        public static Zaposlenik GetLogiraniZaposlenik(HttpContextBase context)
        {
            Zaposlenik korisnik = (Zaposlenik)context.Session[LogiraniZaposlenik];

            if (korisnik != null)
                return korisnik;

            HttpCookie cookie = context.Request.Cookies.Get("_mvc_session");

            if (cookie == null)
                return null;

            long userId;
            try
            {
                userId = Int64.Parse(cookie.Value);
            }
            catch
            {
                return null;
            }


            MojContext db = new MojContext();

            Zaposlenik z = db.Zaposlenici
                 .SingleOrDefault(x => x.Id == userId);

            PokreniNovuSesiju(z, context, true);
            return z;

        }


    }
}