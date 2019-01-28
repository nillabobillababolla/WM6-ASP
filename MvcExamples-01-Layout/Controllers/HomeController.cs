using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcExamples_01_Layout.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public PartialViewResult UrunGetir()
        {
            List<string> urunListesi = new List<string>
            {
                "Kalem",
                "Silgi",
                "Defter"
            };
            return PartialView("~/Views/Home/_partialUrunListesi.cshtml", urunListesi);
        }

    }

}