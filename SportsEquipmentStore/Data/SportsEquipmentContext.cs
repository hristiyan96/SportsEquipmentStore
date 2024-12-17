using Microsoft.EntityFrameworkCore;
using SportsEquipmentStore.Models;

namespace SportsEquipmentStore.Data
{
    public class SportsEquipmentContext : DbContext
    {
        public SportsEquipmentContext(DbContextOptions<SportsEquipmentContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<Brand> Brands { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fitness Equipment", Description = "Treadmills, weights, etc." },
                new Category { Id = 2, Name = "Outdoor Sports", Description = "Football, cricket, etc." },
                new Category { Id = 3, Name = "Water Sports", Description = "Kayaks, surfing boards, etc." }
            );

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(18,2)");
            });

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Nike", Description = "Global leader in sportswear" },
                new Brand { Id = 2, Name = "Adidas", Description = "Innovative and comfortable gear" },
                new Brand { Id = 3, Name = "Puma", Description = "Performance and lifestyle products" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Nike Air Zoom",
                    Description = "Top running shoes.",
                    Price = 120.99m,
                    ImageUrl = "/images/nike_air_zoom.jpg",
                    SportCategory = "Running",
                    BrandId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Adidas Ultraboost",
                    Description = "High-performance running shoes.",
                    Price = 130.50m,
                    ImageUrl = "/images/adidas_ultraboost.jpg",
                    SportCategory = "Running",
                    BrandId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Puma Backpack",
                    Description = "Durable sports backpack.",
                    Price = 49.99m,
                    ImageUrl = "/images/puma_backpack.jpg",
                    SportCategory = "Accessories",
                    BrandId = 3
                }
            );



          
           

            


            


           

           
        }
    }
}
