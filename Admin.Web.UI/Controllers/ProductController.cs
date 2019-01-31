using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.BLL.Helpers;
using Admin.Models.Entities;
using Admin.Models.ViewModels;

namespace Admin.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken] // Fishing yöntemine karşı siteyi koruma.
        //public ActionResult Add(Product model)
        //{
        //    try
        //    {

        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        TempData["Model"] = new ErrorViewModel()
        //        {
        //            Text = $"Bir hata olustu. {EntityHelpers.ValidationMessage(ex)}",
        //            ActionName = "Add",
        //            ControllerName = "Category",
        //            ErrorCode = 500
        //        };
        //        return RedirectToAction("Error", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["Model"] = new ErrorViewModel()
        //        {
        //            Text = $"Bir hata olustu. {ex.Message}",
        //            ActionName = "Add",
        //            ControllerName = "Category",
        //            ErrorCode = 500
        //        };
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

    }
}