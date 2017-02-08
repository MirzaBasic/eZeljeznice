using eZeljeznice.Data.Model;
using eZeljeznice.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
      
            MojContext ctx = new MojContext();
            // GET: Autentifikacija

            [HttpGet]
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Index(string korisnickoIme, string lozinka, bool zapamti)
            {

                List<Zaposlenik> listaZaposlenika = ctx.Zaposlenici.ToList();
                Zaposlenik k = null;
                foreach (Zaposlenik x in listaZaposlenika)
                {
                    if (x.KorisnickoIme == korisnickoIme && x.Lozinka == lozinka)
                    {
                        k = x;
                    }
                }

                if (k == null)
                {
                    ViewData["PorukaCrvena"] = "Pogrešan username/password";
                    return View();
                }

                Autentifikacija.PokreniNovuSesiju(k, HttpContext, zapamti);

                return RedirectToAction("Index", "Home");

            }

            public ActionResult Logout()
            {
                Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
                return RedirectToAction("Index", "Login");
            }
        }
    }
