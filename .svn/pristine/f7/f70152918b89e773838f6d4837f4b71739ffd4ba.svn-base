using eZeljeznice.Data.Model;
using eZeljeznice.Web.Areas.ModulAdministracija.Models;
using eZeljeznice.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Controllers
{
    [Autorizacija(true)]
    public class TipZaposlenikaController : Controller
    {
        // GET: ModulAdministracija/TipZaposlenika
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Uloga
        public ActionResult Index()
        {
            TipZaposlenikaPrikaziVM model = new TipZaposlenikaPrikaziVM();
            model.TipoviZaposlenika = mc.TipoviZaposlenika.Select(x => new TipZaposlenikaPrikaziVM.TipZaposlenikaInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int tipZaposlenikaId)
        {
            TipZaposlenika tz = mc.TipoviZaposlenika.Find(tipZaposlenikaId);
            TipZaposlenikaUrediVM model = new TipZaposlenikaUrediVM();
            model.Id = tz.Id;
            model.Naziv = tz.Naziv;
            model.Opis = tz.Opis;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int tipZaposlenikaId)
        {
            TipZaposlenika tz = mc.TipoviZaposlenika.Find(tipZaposlenikaId);
      
            mc.TipoviZaposlenika.Remove(tz);

            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            TipZaposlenikaUrediVM model = new TipZaposlenikaUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(TipZaposlenikaUrediVM tz)
        {

            if (!ModelState.IsValid)
            {
               
                return View("Uredi", tz);


            }

            TipZaposlenika tipDB;
            if (tz.Id == 0)
            {
                tipDB = new TipZaposlenika();
                mc.TipoviZaposlenika.Add(tipDB);

            }
            else
            {
                tipDB = mc.TipoviZaposlenika.Where(x => x.Id == tz.Id).FirstOrDefault();

            }

            tipDB.Naziv = tz.Naziv;
            tipDB.Opis = tz.Opis;

            mc.SaveChanges();

       

            return RedirectToAction("Index");
        }
    }
}