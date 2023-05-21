using System.Web.Mvc;

namespace BAITAPLON.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "DangNhap", controller="HomeAdmin", id = UrlParameter.Optional }
            );
        }
    }
}