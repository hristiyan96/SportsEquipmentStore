using Microsoft.AspNetCore.Mvc;
using SportsEquipmentStore.Utilities;
using SportsEquipmentStore.Data;
using SportsEquipmentStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace SportsEquipmentStore.Controllers
{
    public class CartController : Controller
    {
        private readonly SportsEquipmentContext _context;
        private readonly IConfiguration _configuration;

        // Constructor to inject database context and configuration
        public CartController(SportsEquipmentContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Add a product to the cart
        public IActionResult AddToCart(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<int>>("Cart") ?? new List<int>();

            if (!cart.Contains(productId))
            {
                cart.Add(productId);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        // View Cart
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<int>>("Cart") ?? new List<int>();
            var products = _context.Products
                                   .Where(p => cart.Contains(p.Id))
                                   .ToList();

            return View(products);
        }

        // Remove a single product from the cart
        public IActionResult Remove(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<int>>("Cart") ?? new List<int>();

            if (cart.Contains(productId))
            {
                cart.Remove(productId);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        // Clear the cart
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

        // Proceed to checkout
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<int>>("Cart") ?? new List<int>();
            var products = _context.Products
                                   .Where(p => cart.Contains(p.Id))
                                   .ToList();

            if (!products.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index");
            }

            // Pass Stripe Public Key to the View
            ViewBag.StripePublicKey = "your-stripe-public-key"; // Replace with your actual public key

            // Generate Client Secret
            var stripeService = new StripeService(_configuration);
            var paymentIntent = stripeService.CreatePaymentIntent((long)(products.Sum(p => p.Price) * 100));
            ViewBag.ClientSecret = paymentIntent.ClientSecret;

            return View(products);
        }


        // Stripe Payment Action
        public IActionResult StripePayment()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<int>>("Cart") ?? new List<int>();
            var products = _context.Products.Where(p => cart.Contains(p.Id)).ToList();

            if (!products.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index");
            }

            var stripeService = new StripeService(_configuration);
            var paymentIntent = stripeService.CreatePaymentIntent((long)(products.Sum(p => p.Price) * 100));

            ViewBag.ClientSecret = paymentIntent.ClientSecret;
            return View(products);
        }
        public IActionResult PaymentSuccess()
        {
            TempData["Success"] = "Payment was successful. Thank you for your purchase!";
            HttpContext.Session.Remove("Cart"); // Clear the cart after successful payment
            return View();
        }

    }
}
