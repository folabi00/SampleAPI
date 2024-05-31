using SampleAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Models
{
    public class Stock
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
     
        [Ensure_CorrectStockSize]
        public string? Description { get; set; }
        [Required]
        [Ensure_CorrectStockSize]
        public int Stocksize { get; set; }
        public DateTime? LastModified { get; set; }

       
    }
}
