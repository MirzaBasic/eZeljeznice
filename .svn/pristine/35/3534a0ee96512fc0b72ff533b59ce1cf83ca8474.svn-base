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
    public class GradController : Controller
    {
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Drzava
        public ActionResult Index(int kantonId)
        {
            GradPrikaziVM model = new GradPrikaziVM();
            model.Kanton = mc.Kantoni.Find(kantonId).Naziv;
            model.KantonId = kantonId;

            model.Gradovi = mc.Gradovi.Where(x=>x.KantonId==kantonId).ToList().
                Select(x => new GradPrikaziVM.GradInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                PostanskiBroj = x.PostanskiBroj
               

            }).ToList();
            return View("Prikazi", model);
        }


        public ActionResult Uredi(int gradId)
        {

            GradUrediVM model = new GradUrediVM();
            Grad g = mc.Gradovi.Where(x => x.Id == gradId).FirstOrDefault();
            model.Id = g.Id;
            model.Naziv = g.Naziv;
            model.PostanskiBroj = g.PostanskiBroj;
            model.KantonId = g.KantonId;
          

            return View("Uredi", model);
        }
        public ActionResult Dodaj(int kantonId)
        {

            GradUrediVM model = new GradUrediVM();
            model.KantonId = kantonId;
          

            return View("Uredi", model);
        }
        public ActionResult Obrisi(int gradId)
        {

            Grad g = mc.Gradovi.Find(gradId);
            mc.Gradovi.Remove(g);
            mc.SaveChanges();


            return RedirectToAction("Index", new { kantonId = g.KantonId });
        }
        public ActionResult Snimi(GradUrediVM grad)
        {
            if (!ModelState.IsValid)
            {
               
                return View("Uredi", grad);
              
            }

            Grad gradDB;
            if (grad.Id == 0)
            {

                gradDB = new Grad();
                mc.Gradovi.Add(gradDB);

            }

            else
            {

                gradDB = mc.Gradovi.Where(x => x.Id == grad.Id).FirstOrDefault();
            }

            gradDB.Naziv = grad.Naziv;
            gradDB.PostanskiBroj =grad.PostanskiBroj;
            gradDB.KantonId = grad.KantonId;



            mc.SaveChanges();


            return RedirectToAction("Index", new { kantonId = grad.KantonId });
        }


    }
}