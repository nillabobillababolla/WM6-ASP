using Admin.BLL.Identity;
using Admin.Models.Enums;
using Admin.Models.Identity.Models;
using Microsoft.AspNet.Identity;
using System;
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

            string[] roller = Enum.GetNames(typeof(IdentityRoles));

            RoleManager<Role> roleManager = MembershipTools.NewRoleManager();
            foreach (string rol in roller)
            {
                if (!roleManager.RoleExists(rol))
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
