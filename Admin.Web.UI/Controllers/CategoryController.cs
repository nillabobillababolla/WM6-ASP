using System.Web.Mvc;
// ReSharper disable Mvc.ViewNotResolved

namespace Admin.Web.UI.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}