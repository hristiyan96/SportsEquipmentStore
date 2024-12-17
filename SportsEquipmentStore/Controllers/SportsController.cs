using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;

namespace SportsEquipmentStore.Controllers
{
    public class SportsController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public SportsController(SportsEquipmentContext context)
        {
            _context = context;
        }

        // Action to display products by sport category
        public async Task<IActionResult> ProductsBySport(string sportCategory)
        {
            if (string.IsNullOrEmpty(sportCategory))
                return NotFound("Sport category not specified.");

            var products = await _context.Products
                .Where(p => p.SportCategory == sportCategory)
                .ToListAsync();

            if (products == null || !products.Any())
                return View("NoProducts", sportCategory); // Optional: View for no products

            ViewBag.SportCategory = sportCategory;
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}
