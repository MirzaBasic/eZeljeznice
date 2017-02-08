using eZeljeznice.Web.Areas.ModulAdministracija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eZeljeznice.Data.Model;
using System.Web.Mvc;
using eZeljeznice.Web.Helper;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Controllers
{
    [Autorizacija(true)]
    public class VagonController : Controller
    {
       
        MojContext mc = new MojContext();
        // GET: ModulAdministracija/Vagon
   

        public ActionResult Index(int? tipVagonaId)
        {

            VagonPrikaziVM model = new VagonPrikaziVM();
            model.vagoni = mc.Vagoni.Where(x => !tipVagonaId.HasValue || x.TipVagonaId == tipVagonaId).ToList()
                .Select(x => new VagonPrikaziVM.VagonInfo {

                    Id = x.Id,
                    Naziv = x.Naziv,
                    SerijskiBroj = x.SerijskiBroj,
                    DatumProizvodnje = x.DatumProizvodnje,
                    TipVagona = x.TipVagona.Naziv,
                    Aktivan = x.Aktivan,
                    BrojSjedista = x.BrojSjedista.ToString()

                }).ToList();
            model.tipoviVagonaStake = new List<SelectListItem>();
            model.tipoviVagonaStake.Add(new SelectListItem { Value = null, Text = "< Svi tipovi vagona >" });
            model.tipoviVagonaStake.AddRange(mc.TipoviVagona.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }));

            return View("Prikazi", model);




        }

        public ActionResult Dodaj()
        {

            VagonUrediVM model = new VagonUrediVM();
           Vagon vagon= new Vagon();


            model.Id = vagon.Id;
            model.Naziv = vagon.Naziv;
            model.SerijskiBroj = vagon.SerijskiBroj;
            model.TipVagonaId = vagon.TipVagonaId;
            model.Aktivan = vagon.Aktivan;
            model.BrojSjedista = vagon.BrojSjedista;
            model.DatumProizvodnje = vagon.DatumProizvodnje;
            
            model.tipoviVagonaStavke=mc.TipoviVagona.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();


            return View("Uredi", model);


        }

        public ActionResult Uredi(int vagonId)
        {

            VagonUrediVM model = new VagonUrediVM();
           Vagon v= mc.Vagoni.Find(vagonId);

         


            model.Id = v.Id;
            model.Naziv = v.Naziv;
            model.SerijskiBroj = v.SerijskiBroj;
            model.TipVagonaId = v.TipVagonaId;
            model.Aktivan = v.Aktivan;
            model.BrojSjedista = v.BrojSjedista;
            model.DatumProizvodnje = v.DatumProizvodnje;
            model.tipoviVagonaStavke = mc.TipoviVagona.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();


            return View("Uredi", model);


        }


        public ActionResult Snimi(VagonUrediVM vagon) {

            if (!ModelState.IsValid)
            {
                vagon.tipoviVagonaStavke = mc.TipoviVagona.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList();


                return View("Uredi", vagon);
            }

            Vagon vagonDB;

            if (vagon.Id <= 0)
            {
                vagonDB = new Vagon();
                mc.Vagoni.Add(vagonDB);


         
            }
            else
            {
                vagonDB = mc.Vagoni.Where(x => x.Id == vagon.Id).FirstOrDefault() ;

            }

            vagonDB.Id = vagon.Id;
            vagonDB.Naziv = vagon.Naziv;
            vagonDB.SerijskiBroj = vagon.SerijskiBroj;
            vagonDB.TipVagonaId = vagon.TipVagonaId;
            vagonDB.Aktivan = vagon.Aktivan;
            vagonDB.BrojSjedista = vagon.BrojSjedista;
            vagonDB.DatumProizvodnje = vagon.DatumProizvodnje;


            mc.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Obrisi(int vagonId)
        {

           
            Vagon v = mc.Vagoni.Find(vagonId);
            mc.Vagoni.Remove(v);
            mc.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}