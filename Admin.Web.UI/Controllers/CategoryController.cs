using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Admin.BLL.Repository;
using Admin.Models.Entities;
using Admin.Models.ViewModels;

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
                new CategoryRepo().Insert(model);
                return RedirectToAction("Add", "Category");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata olustu. {ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Category"
                };
                return RedirectToAction("Add", "Category");
            }

        }


    }
}