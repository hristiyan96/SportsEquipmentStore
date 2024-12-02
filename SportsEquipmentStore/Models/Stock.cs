namespace SportsEquipmentStore.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        public int Quantity { get; set; }
    }
}
