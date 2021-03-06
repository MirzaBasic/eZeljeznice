﻿using eZeljeznice.Data;
using eZeljeznice.Data.Model;
using eZeljeznice.Web.Areas.ModulAdministracija.Models;
using eZeljeznice.Web.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Controllers
{
    [Autorizacija(true)]
    public class ZaposlenikController : Controller
    {
       
        MojContext mc = new MojContext();
      
   

        public ActionResult Index(int? gradId) {
            ZaposlenikPrikaziVM model = new ZaposlenikPrikaziVM();


            model.gradoviStavke = new List<SelectListItem>();
            model.gradoviStavke.Add(new SelectListItem { Value = null, Text = "< Svi gradovi >" });
            model.gradoviStavke.AddRange(mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }));


            //model.tipoviZaposlenikaStavke = new List<SelectListItem>();
            //model.tipoviZaposlenikaStavke.Add(new SelectListItem { Value = null, Text = "< Svi tipovi >" });
            //model.tipoviZaposlenikaStavke.AddRange(mc.TipoviZaposlenika.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }));

            model.zaposlenici = mc.Zaposlenici.Where(x => !gradId.HasValue || x.GradId == gradId).ToList()
            .Select(x => new ZaposlenikPrikaziVM.ZaposlenikInfo()
            {
                Id = x.Id,
                Ime = x.Ime,
                Prezime = x.Prezime,
                KorisnickoIme = x.KorisnickoIme,
                Email = x.Email,
                Telefon = x.Telefon,
                Grad = x.Grad.Naziv + " (" + x.Grad.Kanton.Oznaka + ")",
                Adresa = x.Adresa,
                Aktivan = x.Aktivan,
                BrojKreditenKartice = x.BrojKreditenKartice,
                JMBG = x.JMBG,
                Fax = x.Fax,
                TipZaposljenja = x.TipZaposlenika.Naziv,
                Slika =x.Slika
                



            }).ToList();

           


            return View("Prikazi", model);
        }

        public ActionResult Dodaj()
        {
            ZaposlenikUrediVM model = new ZaposlenikUrediVM();
          



            model.gradoviStavke=mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }).ToList();


          
            model.tipoviZaposlenikaStavke=mc.TipoviZaposlenika.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();





            return View("Uredi", model);
        }




        public ActionResult Obrisi(int zaposlenikId)
        {
            Zaposlenik z = mc.Zaposlenici.Find(zaposlenikId);
            mc.Zaposlenici.Remove(z);
            mc.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Uredi(int zaposlenikId)
        {
            ZaposlenikUrediVM model = new ZaposlenikUrediVM();
            Zaposlenik z = mc.Zaposlenici.Find(zaposlenikId);

            model.Id = z.Id;
            model.Ime = z.Ime;
            model.Prezime = z.Prezime;
            model.KorisnickoIme = z.KorisnickoIme;
            model.Lozinka = z.Lozinka;
            model.JMBG = z.JMBG;
            model.Telefon = z.Telefon;
            model.TipZaposlenikaId = z.TipZaposlenikaId;
            model.Fax = z.Fax;
            model.DatumRodjenja = z.DatumRodjenja;
            model.BrojKreditenKartice = z.BrojKreditenKartice;
            model.Adresa = z.Adresa;
            model.Aktivan = z.Aktivan;
            model.Email = z.Email;
            model.GradId = z.GradId;
            model.Slika = z.Slika;
          



            model.gradoviStavke=mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }).ToList();



            model.tipoviZaposlenikaStavke = mc.TipoviZaposlenika.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList() ;

            return View("Uredi",model);
        }

        public ActionResult Snimi(ZaposlenikUrediVM zaposlenik) {


            if (!ModelState.IsValid)


            {

                
                zaposlenik.gradoviStavke = mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }).ToList();


                if (zaposlenik.ImageFile != null && zaposlenik.ImageFile.ContentLength > 0)
                {
                    zaposlenik.Slika = ImageUpload.GetImageFromFileUpload(zaposlenik.ImageFile);
                }
                zaposlenik.tipoviZaposlenikaStavke = mc.TipoviZaposlenika.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();

                return View("Uredi", zaposlenik);
            }

            Zaposlenik zaposlenikDB;
            if ( zaposlenik.Id== 0)
            {

                zaposlenikDB = mc.Zaposlenici.Create();
                mc.Zaposlenici.Add(zaposlenikDB);
              
            }

            else
            {

                zaposlenikDB = mc.Zaposlenici.Where(x => x.Id == zaposlenik.Id).FirstOrDefault();
            }
            zaposlenikDB.Ime = zaposlenik.Ime;
            zaposlenikDB.Prezime = zaposlenik.Prezime;
            zaposlenikDB.JMBG = zaposlenik.JMBG;
            zaposlenikDB.KorisnickoIme = zaposlenik.KorisnickoIme;
            zaposlenikDB.Lozinka = zaposlenik.Lozinka;
            zaposlenikDB.DatumRodjenja = zaposlenik.DatumRodjenja;
            zaposlenikDB.DatumIzmjene = DateTime.Now;
            zaposlenikDB.Aktivan = zaposlenik.Aktivan;
            zaposlenikDB.GradId = zaposlenik.GradId;
            zaposlenikDB.Telefon = zaposlenik.Telefon;
            zaposlenikDB.Fax = zaposlenik.Fax;
            zaposlenikDB.Email = zaposlenik.Email;
            zaposlenikDB.TipZaposlenikaId = zaposlenik.TipZaposlenikaId;
            zaposlenikDB.Adresa = zaposlenik.Adresa;
            zaposlenikDB.BrojKreditenKartice = zaposlenik.BrojKreditenKartice;

            if (zaposlenik.ImageFile != null && zaposlenik.ImageFile.ContentLength > 0)
            {
               zaposlenikDB.Slika= ImageUpload.GetImageFromFileUpload(zaposlenik.ImageFile);
            }



            mc.SaveChanges();
            return RedirectToAction("Index");

        }


     
       
    }
}