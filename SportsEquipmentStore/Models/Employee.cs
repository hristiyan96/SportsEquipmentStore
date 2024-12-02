using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Position { get; set; }

        public DateTime HireDate { get; set; }
    }
}
