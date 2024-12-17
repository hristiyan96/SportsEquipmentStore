using System;
using System.ComponentModel.DataAnnotations;

namespace SportsEquipmentStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentMethod { get; set; }
    }
}
