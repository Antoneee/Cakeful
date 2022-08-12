﻿// <auto-generated />
using Cakeful.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cakeful.Migrations
{
    [DbContext(typeof(CakefulDbContext))]
    [Migration("20220811040451_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cakeful.Models.Cake", b =>
                {
                    b.Property<int>("CakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CakeId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeaturedCake")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CakeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cakes");

                    b.HasData(
                        new
                        {
                            CakeId = 1,
                            CategoryId = 1,
                            ImageUrl = "https://img.taste.com.au/TLieHxEI/taste/2010/01/butter-cake_1980x1320-118370-1.jpg",
                            InStock = true,
                            IsFeaturedCake = true,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.",
                            Name = "Gooey Butter Cake",
                            Price = 9.25m,
                            ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor."
                        },
                        new
                        {
                            CakeId = 2,
                            CategoryId = 2,
                            ImageUrl = "https://www.biggerbolderbaking.com/wp-content/uploads/2021/01/Sour-Cream-Pound-Cake-Thumbnail-scaled.jpg",
                            InStock = true,
                            IsFeaturedCake = true,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.",
                            Name = "Lemon Pound Cake",
                            Price = 12.49m,
                            ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor."
                        },
                        new
                        {
                            CakeId = 3,
                            CategoryId = 3,
                            ImageUrl = "https://assets.epicurious.com/photos/622b69616a88a4aff613f7d6/4:3/w_3742,h_2807,c_limit/Victory-Victoria-Sponge.jpg",
                            InStock = true,
                            IsFeaturedCake = true,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.",
                            Name = "Victoria Sponge Cake",
                            Price = 10.99m,
                            ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor."
                        },
                        new
                        {
                            CakeId = 4,
                            CategoryId = 1,
                            ImageUrl = "https://storcpdkenticomedia.blob.core.windows.net/media/recipemanagementsystem/media/recipe-media-files/recipes/retail/x17/2020_retail_classic-yellow-butter-cake_600x600.jpg?ext=.jpg",
                            InStock = true,
                            IsFeaturedCake = false,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.",
                            Name = "Yellow Butter Cake",
                            Price = 11.49m,
                            ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor."
                        });
                });

            modelBuilder.Entity("Cakeful.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Butter",
                            Description = "Amet dictum sit amet justo donec enim diam vulputate."
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Pound",
                            Description = "Amet dictum sit amet justo donec enim diam vulputate."
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Sponge",
                            Description = "Amet dictum sit amet justo donec enim diam vulputate."
                        });
                });

            modelBuilder.Entity("Cakeful.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CakeId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("CakeId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Cakeful.Models.Cake", b =>
                {
                    b.HasOne("Cakeful.Models.Category", "Category")
                        .WithMany("Cakes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Cakeful.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Cakeful.Models.Cake", "Cake")
                        .WithMany()
                        .HasForeignKey("CakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cake");
                });

            modelBuilder.Entity("Cakeful.Models.Category", b =>
                {
                    b.Navigation("Cakes");
                });
#pragma warning restore 612, 618
        }
    }
}
