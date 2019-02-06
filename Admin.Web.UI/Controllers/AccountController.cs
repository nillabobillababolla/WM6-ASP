using Admin.Models.Identity.Models;
using Admin.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Admin.BLL.Identity.MembershipTools;

namespace Admin.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.GetOwinContext().Authentication.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            try
            {
                UserStore<User> userStore = NewUserStore();
                RegisterViewModel rm = model.RegisterViewModel;
                Microsoft.AspNet.Identity.UserManager<User> userManager = NewUserManager();
                User user = await userManager.FindByNameAsync(rm.UserName);
                if (user != null)
                {
                    ModelState.AddModelError("UserName", "Bu kullanici adi daha önceden alınmıştır.");
                    return View("Index", model);
                }
                User newUser = new User()
                {
                    Name = rm.UserName,
                    Email = rm.Email,
                    UserName = rm.UserName,
                    Surname = rm.Surname
                };

                IdentityResult result = await userManager.CreateAsync(newUser, rm.Password);
                if (result.Succeeded)
                {
                    if (userStore.Users.Count() == 1)
                    {
                        await userManager.AddToRoleAsync(newUser.Id, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newUser.Id, "User");
                    }
                }
                else
                {
                    string err = "";
                    foreach (string resultError in result.Errors)
                    {
                        err += resultError + " ";
                    }
                    ModelState.AddModelError("", err);
                    return View("Index", model);
                }
                TempData["Message"] = "Kaydınız alınmıştır. Lütfen giriş yapınız";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {ex.Message}",
                    ActionName = "Index",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(RegisterLoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                UserManager<User> userManager = NewUserManager();
                User user = await userManager.FindAsync(model.LoginViewModel.UserName, model.LoginViewModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                    return View("Index", model);
                }
                IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                System.Security.Claims.ClaimsIdentity userIdentity =
                    await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = model.LoginViewModel.RememberMe
                }, userIdentity);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {ex.Message}",
                    ActionName = "Index",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();

            try
            {
                var userManager = NewUserManager();
                var user = await userManager.FindByIdAsync(id);

                var data = new ProfilePasswordViewModel()
                {
                    UserProfileViewModel = new UserProfileViewModel()
                    {
                        Email = user.Email,
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        PhoneNumber = user.PhoneNumber,
                        UserName = user.UserName
                    }
                };
                return View(data);
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu {ex.Message}",
                    ActionName = "UserProfile",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(ProfilePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }

            try
            {
                var userManager = NewUserManager();
                var user = await userManager.FindByIdAsync(model.UserProfileViewModel.Id);

                user.Name = model.UserProfileViewModel.Name;
                user.Surname = model.UserProfileViewModel.Surname;
                if (user.Email != model.UserProfileViewModel.Email)
                {
                    //todo tekrardan aktivasyon gönderilmeli ve kullanıcı rolü aktif olamayan bir kullanıcı rolüne atanmalı!
                }
                user.Email = model.UserProfileViewModel.Email;
                user.PhoneNumber = model.UserProfileViewModel.PhoneNumber;
                await userManager.UpdateAsync(user);
                TempData["Message"] = "Profiliniz güncellenmiştir";
                return RedirectToAction("UserProfile");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu {ex.Message}",
                    ActionName = "UserProfile",
                    ControllerName = "Account",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }
    }
}