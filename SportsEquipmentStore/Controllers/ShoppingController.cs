using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SportsEquipmentStore.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult AddToCart(int equipmentId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var equipment = _context.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment != null)
            {
                cart.AddItem(equipment.Id, equipment.Name, equipment.Price);
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("ViewCart");
        }
        public IActionResult ViewCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return View(cart);
        }
public IActionResult RemoveFromCart(int equipmentId)
{
    var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

    cart.RemoveItem(equipmentId);

    HttpContext.Session.SetObjectAsJson("Cart", cart);

    return RedirectToAction("ViewCart");
}


    }
}
