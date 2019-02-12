using AutoMapper;
using Kuzey.BLL.Repository;
using Kuzey.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Kuzey.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var data = new EmployeeRepo().GetAll().Select(x => Mapper.Map<EmployeeViewModel>(x)).ToList();
            return View(data);
        }
    }
}