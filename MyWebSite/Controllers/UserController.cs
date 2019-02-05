using MyWebSite.DAL.MyEntities;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User model)
        {
            return View();
        }
    }
}