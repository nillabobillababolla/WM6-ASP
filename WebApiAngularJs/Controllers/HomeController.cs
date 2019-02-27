using System.Web.Mvc;

namespace WebApiAngularJs.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Products()
        {
            return View();
        }
    }
}