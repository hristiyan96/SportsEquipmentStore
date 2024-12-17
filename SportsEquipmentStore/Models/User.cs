namespace SportsEquipmentStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } // Already exists
        public string PasswordHash { get; set; } // Rename 'Password' to 'PasswordHash'

        // Add these new properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
