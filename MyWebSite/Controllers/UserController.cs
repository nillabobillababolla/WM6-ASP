using MyWebSite.BLL.Service;
using MyWebSite.DAL.MyEntities;
using MyWebSite.Models;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class UserController : Controller
    {

      UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(UserVM item)
        {
           _userService.AddUser(new User
            {
                Email = item.Email,
                FirstName = item.FirstName,
                Gender = item.Gender,
                LastName = item.LastName,
                Password = item.Password
            });
            return View();
        }
    }
}