using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}
