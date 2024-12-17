using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Product
    {
        public string Description { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty; // Required
        public decimal? Price { get; set; } // Nullable decimal

        public decimal Discount { get; set; }

        public decimal DiscountedPrice => (decimal)(Price * (1 - Discount / 100));
        public string? ImageUrl { get; set; } // Nullable string
        public string? SportCategory { get; set; } // Nullable string
        public int? BrandId { get; set; } // Foreign Key to Brand

        public Brand? Brand { get; set; } // Navigation property
    }
}
