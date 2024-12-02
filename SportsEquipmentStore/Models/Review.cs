using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
