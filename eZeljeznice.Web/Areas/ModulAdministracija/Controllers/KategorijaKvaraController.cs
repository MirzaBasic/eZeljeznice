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
    public class KategorijaKvaraController : Controller
    {
        // GET: ModulAdministracija/KategorijaKvara
    
        MojContext mc = new MojContext();
  
        public ActionResult Index()
        {
            KategorijaKvaraPrikaziVM model = new KategorijaKvaraPrikaziVM();
            model.KategorijeKvara = mc.KategorijeKvarova.Select(x => new KategorijaKvaraPrikaziVM.KategorijaKvaraInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis
            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Uredi(int kategorijaKvaraId)
        {
            KategorijaKvara kk = mc.KategorijeKvarova.Find(kategorijaKvaraId);
            KategorijaKvaraUrediVM model = new KategorijaKvaraUrediVM();
            model.Id = kk.Id;
            model.Naziv = kk.Naziv;
            model.Opis = kk.Opis;


            return View("Uredi", model);
        }
        public ActionResult Obrisi(int kategorijaKvaraId)
        {
            KategorijaKvara kk = mc.KategorijeKvarova.Find(kategorijaKvaraId);

            mc.KategorijeKvarova.Remove(kk);

            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            KategorijaKvaraUrediVM model = new KategorijaKvaraUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(KategorijaKvaraUrediVM kk)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", kk);


            }

            KategorijaKvara tipDB;
            if (kk.Id == 0)
            {
                tipDB = new KategorijaKvara();
                mc.KategorijeKvarova.Add(tipDB);

            }
            else
            {
                tipDB = mc.KategorijeKvarova.Where(x => x.Id == kk.Id).FirstOrDefault();

            }

            tipDB.Naziv = kk.Naziv;
            tipDB.Opis = kk.Opis;

            mc.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}