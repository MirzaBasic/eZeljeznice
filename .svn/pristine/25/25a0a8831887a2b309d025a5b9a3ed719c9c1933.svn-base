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
    public class KantonController : Controller
    {
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Drzava
        public ActionResult Index(int drzavaId)
        {
            KantonPrikaziVM model = new KantonPrikaziVM();
            model.Drzava= mc.Drzave.Find(drzavaId).Naziv;
            model.DrzavaId = drzavaId;
            model.Kantoni = mc.Kantoni.Where(x => x.DrzavaId == drzavaId).ToList().Select(x => new KantonPrikaziVM.KantonInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Oznaka = x.Oznaka,
         

            }).ToList();
            return View("Prikazi", model);
        }


        public ActionResult Uredi(int kantonId)
        {

            KantonUrediVM model = new KantonUrediVM();
            Kanton k = mc.   Kantoni.Where(x => x.Id == kantonId).FirstOrDefault();
            model.Id = k.Id;
            model.Naziv = k.Naziv;
            model.Oznaka = k.Oznaka;
            model.DrzavaId = k.DrzavaId;

           
            return View("Uredi", model);
        }
        public ActionResult Dodaj(int drzavaId)
        {

            KantonUrediVM model = new KantonUrediVM();
            model.DrzavaId = drzavaId;
           

            return View("Uredi", model);
        }
        public ActionResult Obrisi(int kantonId)
        {

            Kanton k = mc.Kantoni.Find(kantonId);
            mc.Kantoni.Remove(k);
            mc.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult Snimi(KantonUrediVM kanton)
        {
            if (!ModelState.IsValid)
            {

                return View("Uredi", kanton);
            }

            Kanton kantonDB;
            if (kanton.Id == 0)
            {

                kantonDB = new Kanton();
                mc.Kantoni.Add(kantonDB);

            }

            else
            {

                kantonDB = mc.Kantoni.Where(x => x.Id == kanton.Id).FirstOrDefault();
            }

            kantonDB.Naziv = kanton.Naziv;
            kantonDB.Oznaka = kanton.Oznaka;
            kantonDB.DrzavaId = kanton.DrzavaId;


            mc.SaveChanges();


            return RedirectToAction("Index", new { drzavaId = kanton.DrzavaId });
        }


    }
}