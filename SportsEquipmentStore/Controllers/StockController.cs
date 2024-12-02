using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class StockController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public StockController(SportsEquipmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stock = _context.Stock.Include(s => s.Equipment);
            return View(await stock.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Equipments = _context.Equipments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Equipments = _context.Equipments.ToList();
            return View(stock);
        }
    }
}
