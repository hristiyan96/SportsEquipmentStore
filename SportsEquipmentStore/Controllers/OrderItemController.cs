using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public OrderItemController(SportsEquipmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orderItems = _context.OrderItems.Include(oi => oi.Order).Include(oi => oi.Equipment);
            return View(await orderItems.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Equipments = _context.Equipments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Orders = _context.Orders.ToList();
            ViewBag.Equipments = _context.Equipments.ToList();
            return View(orderItem);
        }
    }
}
