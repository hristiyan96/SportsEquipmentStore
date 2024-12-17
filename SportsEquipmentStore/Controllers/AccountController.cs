using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Data; // Include the namespace for DbContext
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SportsEquipmentContext _context; // Declare DbContext

        // Constructor to initialize DbContext
        public AccountController(SportsEquipmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PasswordHash != password) // Replace with a hash comparison
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string firstName, string lastName, string email, string password)
        {
            // Check if a user with the given email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View();
            }

            if (ModelState.IsValid)
            {
                // Create new user
                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PasswordHash = password // Replace with hashed password in production
                };

                // Add the user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Set session and redirect to home
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["Error"] = "Please enter a valid email address.";
                return View();
            }

            TempData["Success"] = $"A password reset link has been sent to {email}.";
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}
