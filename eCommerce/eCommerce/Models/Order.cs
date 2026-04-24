using eCommerce.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Order
    {
        [Required(ErrorMessage = "{0} is Required!")]
        [DisplayName("Person Name")]
        public string PersonName { get; set; }

        [DisplayName("Order No.")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "The {0} can't be null")]
        [DisplayName("Order Date")]
        [MinimumDateValidator("2020-01-01", ErrorMessage = "{0} should be greater than or equal to {1}")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be null")]
        [DisplayName("Invoice Price")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        [InvoicePriceValidator]
        public decimal InvoicePrice { get; set; }

        [ProductsListValidator]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
