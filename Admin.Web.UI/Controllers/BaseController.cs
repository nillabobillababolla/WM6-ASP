using Admin.BLL.Repository;
using Admin.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Admin.Models.Enums;
using System;

namespace Admin.Web.UI.Controllers
{
   
    [Authorize]
    public class BaseController : Controller
    {
        protected List<SelectListItem> GetCategorySelectList()
        {
            IOrderedEnumerable<Category> categories = new CategoryRepo()
                .GetAll(x => x.SupCategoryId == null)
                .OrderBy(x => x.CategoryName);
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Üst Kategorisi Yok",
                    Value = "0"
                }
            };
            foreach (Category category in categories)
            {
                if (category.Categories.Any())
                {
                    list.Add(new SelectListItem()
                    {
                        Text = category.CategoryName,
                        Value = category.Id.ToString()
                    });
                    list.AddRange(GetSubCategories(category.Categories.OrderBy(x => x.CategoryName).ToList()));
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = category.CategoryName,
                        Value = category.Id.ToString()
                    });
                }
            }

            List<SelectListItem> GetSubCategories(List<Category> categories2)
            {
                List<SelectListItem> list2 = new List<SelectListItem>();
                foreach (Category category in categories2)
                {
                    if (category.Categories.Any())
                    {
                        list2.Add(new SelectListItem()
                        {
                            Text = category.CategoryName,
                            Value = category.Id.ToString()
                        });
                        list2.AddRange(GetSubCategories(category.Categories.OrderBy(x => x.CategoryName).ToList()));
                    }
                    else
                    {
                        list2.Add(new SelectListItem()
                        {
                            Text = category.CategoryName,
                            Value = category.Id.ToString()
                        });
                    }
                }
                return list2;
            }

            return list;
        }

        protected List<SelectListItem> GetProductSelectList()
        {
            IOrderedEnumerable<Product> products = new ProductRepo()
                .GetAll(x => x.SupProductId == null && x.ProductType == ProductTypes.Retail)
                .OrderBy(x => x.ProductName);
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Perakende Ürünü Yok",
                    Value = new Guid().ToString()
                }
            };
            foreach (Product product in products)
            {
                if (product.Products.Any(x => x.ProductType == ProductTypes.Retail))
                {
                    list.Add(new SelectListItem()
                    {
                        Text = product.ProductName,
                        Value = product.Id.ToString()
                    });
                    list.AddRange(GetSubProducts(product.Products.Where(x => x.ProductType == ProductTypes.Retail).OrderBy(x => x.ProductName).ToList()));
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = product.ProductName,
                        Value = product.Id.ToString()
                    });
                }
            }

            List<SelectListItem> GetSubProducts(List<Product> products2)
            {
                List<SelectListItem> list2 = new List<SelectListItem>();
                foreach (Product product2 in products2)
                {
                    if (product2.Products.Any(x => x.ProductType == ProductTypes.Retail))
                    {
                        list2.Add(new SelectListItem()
                        {
                            Text = product2.ProductName,
                            Value = product2.Id.ToString()
                        });
                        list2.AddRange(GetSubProducts(product2.Products.Where(x => x.ProductType == ProductTypes.Retail).OrderBy(x => x.ProductName).ToList()));
                    }
                    else
                    {
                        list2.Add(new SelectListItem()
                        {
                            Text = product2.ProductName,
                            Value = product2.Id.ToString()
                        });
                    }
                }
                return list2;
            }

            return list;
        }
    }
}