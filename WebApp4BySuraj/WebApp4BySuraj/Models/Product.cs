using System.ComponentModel.DataAnnotations;

namespace WebApp4BySuraj.Models
{
    public class Product
    {
        // Primary key
        public int Id { get; set; }

        // Name of the product, required field
        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name must be at most 100 characters long.")]
        public string Name { get; set; }

        // Price of the product, required field, must be between 0.01 and 10,000
        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, 10000, ErrorMessage = "The Price must be between 0.01 and 10,000.")]
        public decimal Price { get; set; }
    }
}
