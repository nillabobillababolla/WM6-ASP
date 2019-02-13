using System.Web.Mvc;

namespace AreaKullanimi.Areas.AdminArea.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}