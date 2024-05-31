using SampleAPI.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Models.Validations
{
    public class Ensure_CorrectStockSize : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var stock = validationContext.ObjectInstance as StockDTO;
            if (stock.Name != null && stock.Stocksize <= 0)
            {
                return new ValidationResult("Please enter a valid stock size number");
            }
            else if (stock.Description == null)
            {
                return new ValidationResult("Please enter a Description for the stock item");
            }

            return ValidationResult.Success;
        }




    }
}
