namespace SportsEquipmentStore.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // Link to Product
         // Navigation property
        public int UserId { get; set; } // Link to User
        public User User { get; set; } // Navigation property

        public Product Product { get; set; }
    }
}
