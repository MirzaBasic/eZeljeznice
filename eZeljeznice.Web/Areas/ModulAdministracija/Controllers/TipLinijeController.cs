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
    public class TipLinijeController : Controller
    {
        // GET: ModulAdministracija/TipLinije
        MojContext mc = new MojContext();

        public ActionResult Index()
        {
            TipLinijePrikaziVM model = new TipLinijePrikaziVM();
            model.TipoviLinija = mc.TipoviLinije.Select(x => new TipLinijePrikaziVM.TipLinijeInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int tipLinijeId)
        {
            TipLinije tl = mc.TipoviLinije.Find(tipLinijeId);
            TipLinijeUrediVM model = new TipLinijeUrediVM();
            model.Id = tl.Id;
            model.Naziv = tl.Naziv;
            model.Opis = tl.Opis;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int tipLinijeId)
        {
            TipLinije tl = mc.TipoviLinije.Find(tipLinijeId);

            mc.TipoviLinije.Remove(tl);
            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            TipLinijeUrediVM model = new TipLinijeUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(TipLinijeUrediVM tl)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", tl);


            }

            TipLinije tipDB;
            if (tl.Id == 0)
            {
                tipDB = new TipLinije();
                mc.TipoviLinije.Add(tipDB);

            }
            else
            {
                tipDB = mc.TipoviLinije.Where(x => x.Id == tl.Id).FirstOrDefault();

            }

            tipDB.Naziv = tl.Naziv;
            tipDB.Opis = tl.Opis;

            mc.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}