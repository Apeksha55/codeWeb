using Creative.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creative.Web.ViewModel
{
    public class ProductVM
    {
        public ProductVM(Product product)
        {
            ProductId = product.ProductId;
            Category = product.Category;
            ProductName = product.ProductName;
            Rate = product.Rate;
            IsActive = product.IsActive;
        }

        public int ProductId { get; set; }
        [Required]
        [Range(1, 5)]
        public int Category { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
