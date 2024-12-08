using System.Collections.Generic;
using System.Linq;

public class ShoppingCart
{
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    public decimal GrandTotal => Items.Sum(item => item.Total);

    public void AddItem(int equipmentId, string name, decimal price, int quantity = 1)
    {
        var existingItem = Items.FirstOrDefault(i => i.EquipmentId == equipmentId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Items.Add(new ShoppingCartItem
            {
                EquipmentId = equipmentId,
                EquipmentName = name,
                Price = price,
                Quantity = quantity
            });
        }
    }

    public void RemoveItem(int equipmentId)
    {
        var item = Items.FirstOrDefault(i => i.EquipmentId == equipmentId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }
}
