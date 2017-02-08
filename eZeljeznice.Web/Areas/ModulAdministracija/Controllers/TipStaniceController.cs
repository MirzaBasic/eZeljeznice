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
    public class TipStaniceController : Controller
    {
        // GET: ModulAdministracija/TipStanice
        MojContext mc = new MojContext();

        public ActionResult Index()
        {
            TipStanicePrikaziVM model = new TipStanicePrikaziVM();
            model.TipoviStanica = mc.TipStanice.Select(x => new TipStanicePrikaziVM.TipStaniceInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int tipStaniceId)
        {
            TipStanice ts = mc.TipStanice.Find(tipStaniceId);
            TipStaniceUrediVM model = new TipStaniceUrediVM();
            model.Id = ts.Id;
            model.Naziv = ts.Naziv;
            model.Opis = ts.Opis;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int tipStaniceId)
        {
            TipStanice ts = mc.TipStanice.Find(tipStaniceId);

            mc.TipStanice.Remove(ts);
            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            TipStaniceUrediVM model = new TipStaniceUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(TipStaniceUrediVM ts)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", ts);


            }

            TipStanice tipDB;
            if (ts.Id == 0)
            {
                tipDB = new TipStanice();
                mc.TipStanice.Add(tipDB);

            }
            else
            {
                tipDB = mc.TipStanice.Where(x => x.Id == ts.Id).FirstOrDefault();

            }

            tipDB.Naziv = ts.Naziv;
            tipDB.Opis = ts.Opis;

            mc.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}