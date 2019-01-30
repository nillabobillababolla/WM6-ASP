using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Admin.BLL.Repository;
using Admin.Models.Entities;

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

                new CategoryRepo().Insert(model);
                return RedirectToAction("Add", "Category");
            }
            catch
            {
                return RedirectToAction("Add", "Category");
            }

        }

    }
}