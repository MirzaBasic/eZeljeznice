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
    public class LokomotivaController : Controller
    {
       
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Lokomotiva
     

        public ActionResult Index(int? tipLokomotiveId)
        {
            
            LokomotivaPrikaziVM model = new LokomotivaPrikaziVM();

            model.tipoviLokomotivaStavke = new List<SelectListItem>();
            model.tipoviLokomotivaStavke.Add(new SelectListItem { Value = null, Text = "< Svi tipovi lokomotiva >" });
            model.tipoviLokomotivaStavke.AddRange(mc.TipoviLokomotiva.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }));


            model.lokomotive = mc.Lokomotive.Where(x=>!tipLokomotiveId.HasValue||x.TipLokomotiveId==tipLokomotiveId).ToList().Select(x => new LokomotivaPrikaziVM.LokomotivaInfo
            {
                Id=x.Id,
                Naziv = x.Naziv,
                SerijskiBroj=x.SerijskiBroj,
                DatumProizvodnje=x.DatumProizvodnje,
                Aktivan=x.Aktivan,
                TipLokomotive=x.TipLokomotive.Naziv
                


            }).ToList();
           

            return View("Prikazi", model);
        }


        public ActionResult Dodaj() {
            LokomotivaUrediVM model = new LokomotivaUrediVM();
            model.tipoviLokomotivaStavke = mc.TipoviLokomotiva.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(), Text = x.Naziv
            }).ToList();


            return View("Uredi", model);
        }

        public ActionResult Obrisi(int lokomotivaId)
        {
            Lokomotiva l = mc.Lokomotive.Where(x=>x.Id==lokomotivaId).FirstOrDefault();
            mc.Lokomotive.Remove(l);
            mc.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Uredi(int lokomotivaId)
        {
            LokomotivaUrediVM model = new LokomotivaUrediVM();
            Lokomotiva l = mc.Lokomotive.Find(lokomotivaId);

            model.Id = l.Id;
            model.Naziv = l.Naziv;
            model.SerijskiBroj = l.SerijskiBroj;
            model.TipLokomotiveId = l.TipLokomotiveId;
            model.Aktivan = l.Aktivan;
            model.DatumProizvodnje = l.DatumProizvodnje;


            model.tipoviLokomotivaStavke = mc.TipoviLokomotiva.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).ToList();


            return View("Uredi", model);

        }


        public ActionResult Snimi(LokomotivaUrediVM lokomotiva)
        {
            if (!ModelState.IsValid)
            {
                lokomotiva.tipoviLokomotivaStavke = mc.TipoviLokomotiva.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();

                return View("Uredi", lokomotiva);
            }
            Lokomotiva lokomotivaDB;

            if (lokomotiva.Id <= 0)
            {

                lokomotivaDB = new Lokomotiva();
                mc.Lokomotive.Add(lokomotivaDB);
            }

            else {
                lokomotivaDB = mc.Lokomotive.Where(x => x.Id == lokomotiva.Id).FirstOrDefault();


            }

            lokomotivaDB.Naziv = lokomotiva.Naziv;
            lokomotivaDB.SerijskiBroj = lokomotiva.SerijskiBroj;
            lokomotivaDB.TipLokomotiveId = lokomotiva.TipLokomotiveId;
            lokomotivaDB.DatumProizvodnje = lokomotiva.DatumProizvodnje;
            lokomotivaDB.Aktivan = lokomotiva.Aktivan;


            mc.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}