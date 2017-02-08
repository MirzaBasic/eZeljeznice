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
    public class TipKarteController : Controller
    {
        // GET: ModulAdministracija/TipKarte
        MojContext mc = new MojContext();

        public ActionResult Index()
        {
            TipKartePrikaziVM model = new TipKartePrikaziVM();
            model.TipoviKarte = mc.TipoviKarte.Select(x => new TipKartePrikaziVM.TipKarteInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Popust=x.Popust
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int tipKarteId)
        {
            TipKarte tk = mc.TipoviKarte.Find(tipKarteId);
            TipKarteUrediVM model = new TipKarteUrediVM();
            model.Id = tk.Id;
            model.Naziv = tk.Naziv;
            model.Popust = tk.Popust;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int tipKarteId)
        {
            TipKarte tk = mc.TipoviKarte.Find(tipKarteId);

            mc.TipoviKarte.Remove(tk);

            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            TipKarteUrediVM model = new TipKarteUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(TipKarteUrediVM tk)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", tk);


            }

            TipKarte tipDB;
            if (tk.Id == 0)
            {
                tipDB = new TipKarte();
                mc.TipoviKarte.Add(tipDB);

            }
            else
            {
                tipDB = mc.TipoviKarte.Where(x => x.Id == tk.Id).FirstOrDefault();

            }

            tipDB.Naziv = tk.Naziv;
            tipDB.Popust = tk.Popust;

            mc.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}