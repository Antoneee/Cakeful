using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cakeful.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    CakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeaturedCake = table.Column<bool>(type: "bit", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.CakeId);
                    table.ForeignKey(
                        name: "FK_Cakes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CakeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Cakes_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cakes",
                        principalColumn: "CakeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Butter", "Amet dictum sit amet justo donec enim diam vulputate." });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Pound", "Amet dictum sit amet justo donec enim diam vulputate." });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Sponge", "Amet dictum sit amet justo donec enim diam vulputate." });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CategoryId", "ImageUrl", "InStock", "IsFeaturedCake", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, "https://img.taste.com.au/TLieHxEI/taste/2010/01/butter-cake_1980x1320-118370-1.jpg", true, true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", "Gooey Butter Cake", 9.25m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor." },
                    { 2, 2, "https://www.biggerbolderbaking.com/wp-content/uploads/2021/01/Sour-Cream-Pound-Cake-Thumbnail-scaled.jpg", true, true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", "Lemon Pound Cake", 12.49m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor." },
                    { 3, 3, "https://assets.epicurious.com/photos/622b69616a88a4aff613f7d6/4:3/w_3742,h_2807,c_limit/Victory-Victoria-Sponge.jpg", true, true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", "Victoria Sponge Cake", 10.99m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor." },
                    { 4, 1, "https://storcpdkenticomedia.blob.core.windows.net/media/recipemanagementsystem/media/recipe-media-files/recipes/retail/x17/2020_retail_classic-yellow-butter-cake_600x600.jpg?ext=.jpg", true, false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Faucibus scelerisque eleifend donec pretium vulputate. Diam in arcu cursus euismod quis viverra nibh cras.", "Yellow Butter Cake", 11.49m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CategoryId",
                table: "Cakes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CakeId",
                table: "ShoppingCartItems",
                column: "CakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
