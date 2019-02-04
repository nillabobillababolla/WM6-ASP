using System.Web.Mvc;

namespace Admin.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}