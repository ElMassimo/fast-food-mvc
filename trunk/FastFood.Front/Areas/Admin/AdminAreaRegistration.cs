using System.Web.Mvc;

namespace FastFood.Front.Areas.Admin
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
                "Admin_login",
                "Admin/Account/Login",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_employees",
                "Admin/Delivery/Employees/{restaurantName}",
                new { controller = "Delivery", action = "Employees" }
            );

            context.MapRoute(
                "Admin_details", // Route name
                "Admin/Restaurant/Details/{name}", // URL with parameters
                new { controller = "Restaurant", action = "Details" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
