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
    public class KorisnikController : Controller
    {
    
        MojContext mc = new MojContext();
        // GET: ModelKorisnici/Korisnik
  



        public ActionResult Index()
        {
             KorisnikPrikaziVM model = new KorisnikPrikaziVM();
            model.korisnici = mc.Korisnici.ToList()
                .Select(x => new KorisnikPrikaziVM.KorisnikInfo
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
                    NazivFirme = x.NazivFirme,




                }).ToList();

          


         

            return View("Prikazi", model);
        }

        public ActionResult Dodaj()
        {

            KorisnikUrediVM model = new KorisnikUrediVM();
           
          
 
            model.gradoviStavke=mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }).ToList();



            return View("Uredi",model);
        }




        public ActionResult Obrisi(int korisnikId)
        {
            Korisnik k = mc.Korisnici.Find(korisnikId);
            List<UlogeKorisnika> uloge = mc.UlogeKorisnika.Where(x => x.KorisnikId == korisnikId).ToList();
            mc.UlogeKorisnika.RemoveRange(uloge);
            mc.Korisnici.Remove(k);
            mc.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Uredi(int korisnikId)
        {

            KorisnikUrediVM model = new KorisnikUrediVM();

            Korisnik k= mc.Korisnici.Find(korisnikId);

            model.Id = k.Id;
            model.Ime = k.Ime;
            model.Prezime = k.Prezime;
            model.KorisnickoIme = k.KorisnickoIme;
            model.Lozinka = k.Lozinka;
            model.JMBG = k.JMBG;
            model.Telefon = k.Telefon;
            model.Lozinka = k.Lozinka;
            model.Fax = k.Fax;
            model.DatumRodjenja = k.DatumRodjenja;
            model.BrojKreditenKartice = k.BrojKreditenKartice;
            model.Adresa = k.Adresa;
            model.Aktivan = k.Aktivan;
            model.Email = k.Email;
            model.GradId = k.GradId;


            model.gradoviStavke=mc.Gradovi .Select(x => new SelectListItem {   Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")"  }).ToList();
            return View("Uredi", model);
        }

        public ActionResult Snimi(KorisnikUrediVM korisnik)
        {
            if (!ModelState.IsValid) {

                korisnik.gradoviStavke = mc.Gradovi.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv + " (" + x.Kanton.Oznaka + ")" }).ToList();

                return View("Uredi", korisnik);
            }
            Korisnik korisnikDB;
            if (korisnik.Id == 0)
            {


                korisnikDB = new Korisnik();
                mc.Korisnici.Add(korisnikDB);

            }

            else
            {

                korisnikDB = mc.Korisnici.Where(x => x.Id == korisnik.Id).FirstOrDefault();
            }
            korisnikDB.Ime = korisnik.Ime;
            korisnikDB.Prezime = korisnik.Prezime;
            korisnikDB.JMBG = korisnik.JMBG;
            korisnikDB.KorisnickoIme = korisnik.KorisnickoIme;
            korisnikDB.Lozinka = korisnik.Lozinka;
            korisnikDB.DatumRodjenja = korisnik.DatumRodjenja;
            korisnikDB.DatumIzmjene = DateTime.Now;
            korisnikDB.Aktivan = korisnik.Aktivan;
            korisnikDB.GradId = korisnik.GradId;
            korisnikDB.Telefon = korisnik.Telefon;
            korisnikDB.Fax = korisnik.Fax;
            korisnikDB.Email = korisnik.Email;
            korisnikDB.NazivFirme = korisnik.NazivFirme;
            korisnikDB.BrojKreditenKartice = korisnik.BrojKreditenKartice;
            korisnikDB.Adresa = korisnik.Adresa;



            mc.SaveChanges();
            if (korisnik.Id == 0)
            { 
            UlogeKorisnika uk = new UlogeKorisnika();
            uk.KorisnikId = korisnikDB.Id;
            uk.UlogaId = mc.Uloge.Where(x => x.Naziv == "User").FirstOrDefault().Id;
            uk.DatumKreiranja = DateTime.Now;
            mc.UlogeKorisnika.Add(uk);
            mc.SaveChanges();
            }
            return RedirectToAction("Index");

        }

    }
}