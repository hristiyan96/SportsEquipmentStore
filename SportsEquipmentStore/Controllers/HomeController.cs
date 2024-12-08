using Microsoft.AspNetCore.Mvc;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Fitness Equipment", Description = "Treadmills, weights, etc." },
            new Category { Id = 2, Name = "Outdoor Sports", Description = "Football, cricket, etc." },
            new Category { Id = 3, Name = "Water Sports", Description = "Kayaks, surfing boards, etc." }
        };

            return View(categories);
        }
    }
}
