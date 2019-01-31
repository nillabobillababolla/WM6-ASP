using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.Models.Entities;
using Admin.Models.ViewModels;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Admin.Web.UI.Models.ViewModels;

namespace Admin.Web.UI.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {

            ViewBag.CategoryList = GetCategorySelectList();
            ViewBag.ProductList = GetProductSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Fishing yöntemine karşı siteyi koruma.
        public ActionResult Add(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    ViewBag.GetProducts = GetProductSelectList();
                    ViewBag.CategotyList = GetCategorySelectList();
                    return View(model);
                }

                new ProductRepo().Insert(model);
                TempData["Message"] = $"{model.ProductName} isimli ürün basariyla eklendi.";
                return RedirectToAction("Add", "Product");
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 400
                };
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 400
                };
                return RedirectToAction("Error", "Home");
            }
        }

    }
}