using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Admin.Models.Abstracts;
using Admin.Models.Enums;

namespace Admin.Web.UI.Models.ViewModels
{
    public class ProductViewModel:BaseEntity<Guid>
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Kategori Adı 3 ile 100 karakter arasında  olabilir.")]
        [DisplayName("Ürün Adı")]
        [Required]
        public string ProductName { get; set; }
        [DisplayName("Ürün Tipi")]
        public ProductTypes ProductType { get; set; }
        [DisplayName("Satış Fiyatı")]
        public decimal SalesPrice { get; set; }
        [DisplayName("Alış Fiyatı")]
        public decimal BuyPrice { get; set; }
        [DisplayName("Stok Miktarı")]
        [Range(0, 9999)]
        public decimal UnitsInStock { get; set; }
        public string SupProductId { get; set; }
        [StringLength(20)]
        [Required]
        public string Barcode { get; set; }
        [DisplayName("Birim")]
        public int Quantity { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
    }
}