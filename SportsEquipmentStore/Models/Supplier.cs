using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
    }
}
