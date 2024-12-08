public class ShoppingCartItem
{
    public int EquipmentId { get; set; }
    public string EquipmentName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Total => Price * Quantity;
}
