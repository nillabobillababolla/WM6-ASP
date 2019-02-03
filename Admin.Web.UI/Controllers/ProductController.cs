using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.BLL.Services;
using Admin.Models.Entities;
using Admin.Models.Models;
using Admin.Models.ViewModels;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Admin.Web.UI.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.ProductList = GetProductSelectList();
            ViewBag.CategoryList = GetCategorySelectList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Add(Product model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductList = GetProductSelectList();
                ViewBag.CategoryList = GetCategorySelectList();
                return View(model);
            }

            try
            {
                if (model.SupProductId.ToString().Replace("0", "").Replace("-", "").Length == 0)
                {
                    model.SupProductId = null;
                }

                model.LastPriceUpdateDate = DateTime.Now;
                await new ProductRepo().InsertAsync(model);
                TempData["Message"] = $"{model.ProductName} isimli ürün başarıyla eklenmiştir";
                return RedirectToAction("Add");
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }


        public JsonResult CheckBarcode(string barcode)
        {
            try
            {
                if (new ProductRepo().Queryable().Any(x => x.Barcode == barcode))
                {
                    return Json(new ResponseData()
                    {
                        message = $"{barcode} sistemde kayıtlı",
                        success = true
                    }, JsonRequestBehavior.AllowGet);
                }
                return Json(new ResponseData()
                {
                    message = $"{barcode} bilgisi servisten getirildi",
                    success = true,
                    data = new BarcodeService().Get(barcode)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    message = $"Bir hata oluştu: {ex.Message}",
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Update(Guid id = default(Guid))
        {
            try
            {
                ViewBag.ProductList = GetProductSelectList();
                var data = new ProductRepo().GetById(id);
                if (data == null)
                {
                    TempData["Model"] = new ErrorViewModel()
                    {
                        Text = $"Ürün Bulunamadı",
                        ActionName = "Update",
                        ControllerName = "Product",
                        ErrorCode = 404
                    };
                    return RedirectToAction("Error", "Home");
                }
                return View(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Product model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ProductList = GetProductSelectList();
                    return View(model);
                }

                var data = new ProductRepo().GetById(model.Id);
                data.ProductName = model.ProductName;
                data.SalesPrice = model.SalesPrice;
                data.SupProductId = model.SupProductId;
                new ProductRepo().Update(data);

                TempData["Message"] = $"{model.ProductName} isimli ürün başarıyla güncellenmiştir";
                ViewBag.CategoryList = GetCategorySelectList();
                return View(data);
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Update",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }

            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu:{ex.Message}",
                    ActionName = "Update",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }
    }

}
