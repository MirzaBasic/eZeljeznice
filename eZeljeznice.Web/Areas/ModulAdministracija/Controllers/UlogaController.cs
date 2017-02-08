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
    public class UlogaController : Controller
    {
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Uloga
        public ActionResult Index()
        {
            UlogaPrikaziVM model = new UlogaPrikaziVM();
            model.Uloge = mc.Uloge.Select(x => new UlogaPrikaziVM.UlogaInfo
            {
                Id = x.Id,
                Naziv=x.Naziv,
                Opis=x.Opis
            }).ToList();
            
            return View("Prikazi", model);
        }

        public ActionResult Uredi(int ulogaId)
        {
            Uloga u = mc.Uloge.Find(ulogaId);
            UlogaUrediVM model = new UlogaUrediVM();
            model.Id = u.Id;
            model.Naziv = u.Naziv;
            model.Opis = u.Opis;

            return View("Uredi", model);
        }
        public ActionResult Obrisi(int ulogaId)
        {
            Uloga u = mc.Uloge.Find(ulogaId);
            mc.Uloge.Remove(u);

            try { mc.SaveChanges(); } catch { }

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            UlogaUrediVM model = new UlogaUrediVM();


            return View("Uredi", model);
        }
        public ActionResult Snimi(UlogaUrediVM u)
        {

            if (!ModelState.IsValid)
            {

                return View("Uredi", u);


            }

            Uloga ulogaDB;
            if (u.Id == 0)
            {
                ulogaDB = new Uloga();
                mc.Uloge.Add(ulogaDB);

            }
            else
            {
                 ulogaDB = mc.Uloge.Where(x => x.Id == u.Id).FirstOrDefault();

            }

            ulogaDB.Naziv = u.Naziv;
            ulogaDB.Opis = u.Opis;

            mc.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}