using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;

namespace SportsEquipmentStore.Controllers
{
    public class SaleController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public SaleController(SportsEquipmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var saleProducts = await _context.Products
                .Where(p => p.Discount > 0) // Products with discounts
                .ToListAsync();

            return View(saleProducts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
