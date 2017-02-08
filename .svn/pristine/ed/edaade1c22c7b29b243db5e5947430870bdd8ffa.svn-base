using eZeljeznice.Data.Model;
using eZeljeznice.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MojContext ctx = new MojContext();

        public ActionResult Index()
        {
            Zaposlenik z = Autentifikacija.GetLogiraniZaposlenik(HttpContext);
            if (z == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            if (z.TipZaposlenika.Naziv=="Administrator")
            {

                return RedirectToAction("Index", "Home", new { area = "ModulAdministracija" });
            }

            return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
        }


    }
}
