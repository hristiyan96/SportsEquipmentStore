using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Data
{
    public class SportsEquipmentContext : DbContext
    {
        public SportsEquipmentContext(DbContextOptions<SportsEquipmentContext> options) : base(options) { }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fitness Equipment", Description = "Treadmills, weights, etc." },
                new Category { Id = 2, Name = "Outdoor Sports", Description = "Football, cricket, etc." },
                new Category { Id = 3, Name = "Water Sports", Description = "Kayaks, surfing boards, etc." }
            );

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Adidas", Country = "Germany" },
                new Brand { Id = 2, Name = "Nike", Country = "USA" },
                new Brand { Id = 3, Name = "Decathlon", Country = "France" }
            );

            // Seed Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Fitness Co.", Contact = "123-456-7890", Email = "contact@fitnessco.com", Address = "123 Fitness Lane" },
                new Supplier { Id = 2, Name = "Outdoor Unlimited", Contact = "987-654-3210", Email = "info@outdoorunlimited.com", Address = "456 Outdoor Ave" },
                new Supplier { Id = 3, Name = "Water Adventures", Contact = "555-123-4567", Email = "sales@wateradventures.com", Address = "789 Water St" }
            );

            // Seed Products
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Treadmill", CategoryId = 1, BrandId = 1, Price = 1200.99M, Description = "High-performance treadmill for indoor running." },
                new Equipment { Id = 2, Name = "Dumbbell Set", CategoryId = 1, BrandId = 2, Price = 150.49M, Description = "Adjustable dumbbell set with rack." },
                new Equipment { Id = 3, Name = "Football", CategoryId = 2, BrandId = 2, Price = 25.99M, Description = "Professional-grade football for outdoor use." },
                new Equipment { Id = 4, Name = "Kayak", CategoryId = 3, BrandId = 3, Price = 800.00M, Description = "Single-seat kayak for water sports enthusiasts." }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "555-555-5555", Address = "123 Main St" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "555-666-7777", Address = "456 Elm St" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Now, TotalAmount = 1250.00M },
                new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.Now, TotalAmount = 800.00M }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, EquipmentId = 1, Quantity = 1, Price = 1200.99M },
                new OrderItem { Id = 2, OrderId = 2, EquipmentId = 4, Quantity = 1, Price = 800.00M }
            );

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, EquipmentId = 1, CustomerId = 1, Rating = 5, Comment = "Excellent treadmill!", ReviewDate = DateTime.Now },
                new Review { Id = 2, EquipmentId = 4, CustomerId = 2, Rating = 4, Comment = "Great kayak for beginners!", ReviewDate = DateTime.Now }
            );

            // Seed Stock
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, EquipmentId = 1, Quantity = 10 },
                new Stock { Id = 2, EquipmentId = 2, Quantity = 20 },
                new Stock { Id = 3, EquipmentId = 3, Quantity = 50 },
                new Stock { Id = 4, EquipmentId = 4, Quantity = 15 }
            );
        }
    }
}
