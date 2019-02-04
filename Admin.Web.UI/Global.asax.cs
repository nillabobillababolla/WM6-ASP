using Admin.BLL.Identity;
using Admin.Models.Identity.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Routing;

namespace Admin.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string[] roller = new string[] { "Admin", "User" };
            RoleManager<Role> roleManager = MembershipTools.NewRoleManager();
            foreach (string rol in roller)
            {
                if (roleManager.RoleExists(rol))
                {
                    roleManager.Create(new Role()
                    {
                        Name = rol
                    });
                }
            }
        }
    }
}
