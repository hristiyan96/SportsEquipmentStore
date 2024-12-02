using Microsoft.AspNetCore.Mvc;

namespace SportsEquipmentStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
