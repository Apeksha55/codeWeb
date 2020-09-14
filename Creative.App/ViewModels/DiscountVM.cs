using Creative.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creative.Web.ViewModel
{
    public class DiscountVM
    {
        public DiscountVM(Discount discount)
        {
            DiscountId = discount.DiscountId;
            OfferName = discount. OfferName;
            Category = discount.Category;
            ApplicableFrom = discount.ApplicableFrom;
            ApplicableTo = discount.ApplicableTo;
            IsActive = discount.IsActive;
        }
        [Required]
        public int DiscountId { get; set; }
        [Required]
        public string OfferName { get; set; }
        [Required]
        [Range(1,5)]
        public int Category { get; set; }
        [Required]
        public System.DateTime ApplicableFrom { get; set; }
        [Required]
        public System.DateTime ApplicableTo { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
