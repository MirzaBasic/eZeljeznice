using eZeljeznice.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Controllers
{
    [Autorizacija(true)]
    public class HomeController : Controller
    {
        
        // GET: ModulAdministracija/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}