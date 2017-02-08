﻿using eZeljeznice.Data.Model;
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
    public class TipVagonaController : Controller
    {
        // GET: ModulAdministracija/TipVagona
        MojContext mc = new MojContext();

        public ActionResult Index()
        {
            TipVagonaPrikaziVM model = new TipVagonaPrikaziVM();
            model.TipoviVagona = mc.TipoviVagona.Select(x => new TipVagonaPrikaziVM.TipVagonaInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int tipVagonaId)
        {
            TipVagona tv = mc.TipoviVagona.Find(tipVagonaId);
            TipVagonaUrediVM model = new TipVagonaUrediVM();
            model.Id = tv.Id;
            model.Naziv = tv.Naziv;
            model.Opis = tv.Opis;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int tipVagonaId)
        {
            TipVagona tv = mc.TipoviVagona.Find(tipVagonaId);

            mc.TipoviVagona.Remove(tv);

            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            TipVagonaUrediVM model = new TipVagonaUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(TipVagonaUrediVM tv)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", tv);


            }

            TipVagona tipDB;
            if (tv.Id == 0)
            {
                tipDB = new TipVagona();
                mc.TipoviVagona.Add(tipDB);

            }
            else
            {
                tipDB = mc.TipoviVagona.Where(x => x.Id == tv.Id).FirstOrDefault();

            }

            tipDB.Naziv = tv.Naziv;
            tipDB.Opis = tv.Opis;

            mc.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}