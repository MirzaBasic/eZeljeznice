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
    public class UlogaKorisnikaController : Controller
    {
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Uloge
        public ActionResult Index(int korisnikId)
        {
            UlogaKorisnikaPrikaziVM model = new UlogaKorisnikaPrikaziVM();
            Korisnik k = mc.Korisnici.Find(korisnikId);
            model.KorisnikId = korisnikId;
            model.Korisnik = k.Ime + " " +k.Prezime;
            model.ulogeKorisnika = mc.UlogeKorisnika.Where(x => x.KorisnikId == korisnikId).Select(x => new UlogaKorisnikaPrikaziVM.UlogeKorisnikaInfo
            {
                Id = x.Id,
                Naziv = x.Uloga.Naziv,
                
                DatumKreiranja = x.DatumKreiranja,



            }).ToList();

            return View("Prikazi", model);
        }

        public ActionResult Dodaj(int korisnikId) {

            UlogaKorisnikaUrediVM model = new UlogaKorisnikaUrediVM();
            model.KorisnikId = korisnikId;
            model.ulogeStavke = mc.Uloge.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();

            return View("Uredi", model);
        }

     
        public ActionResult Uredi(int ulogaKorisnikaId)
        {
            UlogaKorisnikaUrediVM model = new UlogaKorisnikaUrediVM();
            UlogeKorisnika uk = mc.UlogeKorisnika.Where(x => x.Id == ulogaKorisnikaId).FirstOrDefault();

            model.Id = uk.Id;
            model.KorisnikId = uk.KorisnikId;
            model.UlogaId = uk.UlogaId;
          
            

            model.ulogeStavke = mc.Uloge.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();

            return View("Uredi", model);

        }

        public ActionResult Obrisi(int ulogaKorisnikaId)
        {
            UlogeKorisnika uk = mc.UlogeKorisnika.Find(ulogaKorisnikaId);
            mc.UlogeKorisnika.Remove(uk);
            mc.SaveChanges();


            return RedirectToAction("Index",new { korisnikId = uk.KorisnikId });

        }

        public ActionResult Snimi(UlogaKorisnikaUrediVM ulogaKorisnika)
         
        {
            if (!ModelState.IsValid)
            {
                ulogaKorisnika.ulogeStavke = mc.Uloge.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();

                return View("Uredi", ulogaKorisnika);

            }
            UlogeKorisnika ulogaDB;

            if (ulogaKorisnika.Id <= 0)
            {
                 ulogaDB = new UlogeKorisnika();
                mc.UlogeKorisnika.Add(ulogaDB);

            }

            else {
                ulogaDB = mc.UlogeKorisnika.Where(x => x.Id == ulogaKorisnika.Id).FirstOrDefault();


            }

     
            ulogaDB.UlogaId = ulogaKorisnika.UlogaId;
            ulogaDB.KorisnikId = ulogaKorisnika.KorisnikId;
            ulogaDB.DatumKreiranja = DateTime.Now;


            mc.SaveChanges();
            return RedirectToAction("Index",new { korisnikId = ulogaDB.KorisnikId });

        }

    }
}