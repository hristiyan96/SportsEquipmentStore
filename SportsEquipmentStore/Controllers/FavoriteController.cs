using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly SportsEquipmentContext _context;

        public FavoriteController(SportsEquipmentContext context)
        {
            _context = context;
        }

        // Display the list of favorites for the logged-in user
        public async Task<IActionResult> Index()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            var favorites = await _context.Favorites
                .Where(f => f.UserId == user.Id)
                .Include(f => f.Product)
                .ToListAsync();

            return View(favorites);
        }


        // Add an item to favorites
        [HttpPost]
        public async Task<IActionResult> AddToFavorite(int productId)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            var exists = await _context.Favorites
                .AnyAsync(f => f.UserId == user.Id && f.ProductId == productId);

            if (!exists)
            {
                var favorite = new Favorite
                {
                    ProductId = productId,
                    UserId = user.Id
                };

                _context.Favorites.Add(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Favorite");
        }

        // Remove an item from favorites
        [HttpPost]
        public async Task<IActionResult> Remove(int favoriteId)
        {
            var favorite = await _context.Favorites.FindAsync(favoriteId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
