using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public EquipmentController(SportsEquipmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var equipments = await _context.Equipments.Include(e => e.Category).Include(e => e.Brand).ToListAsync();
            return View(equipments);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View();
        }
        public IActionResult Search(string query)
        {
            var results = _context.Equipments
                .Where(e => e.Name.Contains(query) || e.Description.Contains(query))
                .ToList();
            return View(results);
        }
        public IActionResult Filter(int? categoryId, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Equipments.AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(e => e.CategoryId == categoryId);

            if (minPrice.HasValue)
                query = query.Where(e => e.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(e => e.Price <= maxPrice);

            return View(query.ToList());
        }
        public IActionResult Details(int id)
        {
            var equipment = _context.Equipments
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == id);

            if (equipment == null)
                return NotFound();

            return View(equipment);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(equipment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {
            if (id != equipment.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(equipment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
                return NotFound();

            return View(equipment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
