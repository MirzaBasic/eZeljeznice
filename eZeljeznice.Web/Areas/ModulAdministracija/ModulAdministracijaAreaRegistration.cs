using System.Web.Mvc;

namespace eZeljeznice.Web.Areas.ModulAdministracija
{
    public class ModulAdministracijaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulAdministracija";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulAdministracija_default",
                "ModulAdministracija/{controller}/{action}/{id}",
                new { area = "ModulAdministracija", action = "Index", id = UrlParameter.Optional },
                new string[] { "eZeljeznice.Web.Areas.ModulAdministracija.Controllers" }
            );
        }
    }
}