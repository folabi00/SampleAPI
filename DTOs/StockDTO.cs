using SampleAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace SampleAPI.DTOs
{
    public class StockDTO
    {
        [Required]
        public string? Name { get; set; }

        [Ensure_CorrectStockSize]
        public string? Description { get; set; }
        [Required]
        [Ensure_CorrectStockSize]
        public int Stocksize { get; set; }
        public DateTime? LastModified { get; set; }

        public int MaximumStockLevel { get; set; } = 0;
    }
}
