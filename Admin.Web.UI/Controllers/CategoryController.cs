using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.Models.Entities;
using Admin.Models.ViewModels;
using System;
using System.Data.Entity.Validation;
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
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.CategoryList = GetCategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Fishing yöntemine karşı siteyi koruma.
        public ActionResult Add(Category model)
        {
            try
            {
                model.TaxRate /= 100;
                if (model.SupCategoryId == 0)
                    model.SupCategoryId = null;
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("CategoryName","100 karakteri gecme kardes.");
                    model.TaxRate *= 100;
                    model.SupCategoryId = model.SupCategoryId ?? 0;
                    ViewBag.CategoryList = GetCategorySelectList();
                    return View(model);
                }

                if (model.SupCategoryId>0)
                {
                    model.TaxRate = new CategoryRepo().GetById(model.SupCategoryId).TaxRate;
                }

                new CategoryRepo().Insert(model);
                TempData["Message"] = $"{model.CategoryName} isimli kategori basariyla eklendi.";
                return RedirectToAction("Add", "Category");
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Add",
                    ControllerName = "Category",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Category",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public ActionResult Update()
        {
            ViewBag.CategoryList = this.GetCategorySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Category Model)
        {
            try
            {
               var category = new CategoryRepo().GetById(Model.Id);
               if (category == null)
               {
                  return RedirectToAction("Update", "Category");
               }

               category.CategoryName = Model.CategoryName;
               category.SupCategoryId = Model.SupCategoryId;
               category.TaxRate = Model.TaxRate;
               new CategoryRepo().Update(category);
               return RedirectToAction("Update", "Category");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Update", "Category");
            }
        }

    }
}