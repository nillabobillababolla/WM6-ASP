using System.Web.Mvc;

namespace MvcExamples_02_WebSiteProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}