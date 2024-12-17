using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class BrandController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public BrandController(SportsEquipmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductsByBrand(string brandName)
        {
            if (string.IsNullOrEmpty(brandName))
                return NotFound();

            // Ensure brandName filtering is case-insensitive and exact
            var products = await _context.Products
                .Include(p => p.Brand)
                .Where(p => p.Brand.Name.ToLower() == brandName.ToLower())
                .ToListAsync();

            if (products == null || !products.Any())
            {
                ViewData["BrandName"] = brandName;
                return View("ProductsPlaceholder");
            }

            ViewData["BrandName"] = brandName;
            return View(products);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _context.Products
                .Include(p => p.Brand) // Include Brand details
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Handle missing product
            }

            return View(product); // Pass the product to the ProductDetails view
        }

    }
}
