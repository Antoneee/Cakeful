using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cakeful.Models
{
    public class CakefulDbContext : IdentityDbContext
    {
        public CakefulDbContext(DbContextOptions<CakefulDbContext> options) : base(options)
        {

        }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Butter", Description = "Amet dictum sit amet justo donec enim diam vulputate." },
                new Category { CategoryId = 2, CategoryName = "Pound", Description = "Amet dictum sit amet justo donec enim diam vulputate." },
                new Category { CategoryId = 3, CategoryName = "Sponge", Description = "Amet dictum sit amet justo donec enim diam vulputate." }
            );

            modelBuilder.Entity<Cake>().HasData(
                new Cake { CakeId = 1, Name = "Gooey Butter Cake", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", Price = 9.25M, ImageUrl = "https://img.taste.com.au/TLieHxEI/taste/2010/01/butter-cake_1980x1320-118370-1.jpg", IsFeaturedCake = true, InStock = true, CategoryId = 1 },
                new Cake { CakeId = 2, Name = "Lemon Pound Cake", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", Price = 12.49M, ImageUrl = "https://www.biggerbolderbaking.com/wp-content/uploads/2021/01/Sour-Cream-Pound-Cake-Thumbnail-scaled.jpg", IsFeaturedCake = true, InStock = true, CategoryId = 2 },
                new Cake { CakeId = 3, Name = "Victoria Sponge Cake", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", Price = 10.99M, ImageUrl = "https://assets.epicurious.com/photos/622b69616a88a4aff613f7d6/4:3/w_3742,h_2807,c_limit/Victory-Victoria-Sponge.jpg", IsFeaturedCake = true, InStock = true, CategoryId = 3 },
                new Cake { CakeId = 4, Name = "Yellow Butter Cake", ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", Price = 11.49M, ImageUrl = "https://storcpdkenticomedia.blob.core.windows.net/media/recipemanagementsystem/media/recipe-media-files/recipes/retail/x17/2020_retail_classic-yellow-butter-cake_600x600.jpg?ext=.jpg", IsFeaturedCake = false, InStock = true, CategoryId = 1 }
            );
        }
    }
}
