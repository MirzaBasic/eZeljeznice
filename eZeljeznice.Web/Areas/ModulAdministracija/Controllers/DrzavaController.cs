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
    public class DrzavaController : Controller
    {
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Drzava
        public ActionResult Index()
        {
            DrzavaPrikaziVM model = new DrzavaPrikaziVM();

            model.Drzave = mc.Drzave.Select(x => new DrzavaPrikaziVM.DrzavaInfo
            {
                Id = x.Id,
                Naziv=x.Naziv,
                Oznaka=x.Oznaka

            }).ToList();
            return View("Prikazi", model);
        }


        public ActionResult Uredi(int drzavaId)
        {

            DrzavaUrediVM model = new DrzavaUrediVM();
            Drzava d = mc.Drzave.Where(x => x.Id == drzavaId).FirstOrDefault();
            model.Id = d.Id;
            model.Naziv = d.Naziv;
            model.Oznaka = d.Oznaka;

            return View("Uredi", model);
        }
        public ActionResult Dodaj()
        {

            DrzavaUrediVM model = new DrzavaUrediVM();
      

            return View("Uredi", model);
        }
        public ActionResult Obrisi(int drzavaId)
        {

            Drzava d = mc.Drzave.Find(drzavaId);
            mc.Drzave.Remove(d);
            try { mc.SaveChanges(); } catch { }
      


            return RedirectToAction("Index");
        }
        public ActionResult Snimi(DrzavaUrediVM drzava)
        {
            if (!ModelState.IsValid)
            {

                return View("Uredi", drzava);
            }

            Drzava drzavaDB;
            if (drzava.Id == 0)
            {

                drzavaDB = new Drzava();
                mc.Drzave.Add(drzavaDB);

            }

            else
            {

                drzavaDB = mc.Drzave.Where(x => x.Id == drzava.Id).FirstOrDefault();
            }

            drzavaDB.Naziv = drzava.Naziv;
            drzavaDB.Oznaka = drzava.Oznaka;


          
            mc.SaveChanges();


            return RedirectToAction("Index");
        }


    }
}