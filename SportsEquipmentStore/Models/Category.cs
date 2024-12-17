using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

       
    }
}
