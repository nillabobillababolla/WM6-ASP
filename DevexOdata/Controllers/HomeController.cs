using DevexOdata.Models;
using System.Web.Mvc;

namespace DevexOdata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ApplicationDbContext db = new ApplicationDbContext();

            for (int i = 0; i < 5000; i++)
            {
                db.Customers.Add(new Customer
                {
                    Address = FakeData.PlaceData.GetAddress(),
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Balance = FakeData.NumberData.GetNumber(1250, 999999),
                    Phone = "05" + FakeData.PhoneNumberData.GetPhoneNumber().Replace("-", "").Substring(0,10),
                });
                if (i % 100 == 0)
                    db.SaveChanges();
            }
            db.SaveChanges();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}