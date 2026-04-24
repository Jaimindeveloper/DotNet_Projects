using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace eCommerce.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        public InvoicePriceValidatorAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If InvoicePrice is null, nothing to validate
            if (value == null)
                return null;

            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
            if (otherProperty == null)
                return null;

            var products = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!;
            if (products == null || products.Count == 0)
                return new ValidationResult("No products found to validate invoice price", new[] { validationContext.MemberName ?? nameof(Order.Products) });

            double totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += product.Price * product.Quantity;
            }

            double actualPrice;
            try
            {
                actualPrice = Convert.ToDouble(value);
            }
            catch
            {
                return new ValidationResult("Invoice price is not a valid number", new[] { validationContext.MemberName ?? "InvoicePrice" });
            }

            if (totalPrice != actualPrice)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new[] { validationContext.MemberName ?? "InvoicePrice" });
            }

            return ValidationResult.Success;
        }
    }
}
