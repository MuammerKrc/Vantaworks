using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCoreApp.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", null, "Pizza" },
                    { 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", null, "Burger" },
                    { 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", null, "Noodle" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "En güzel burgerlar burada", "slider/s1.png", "Burgerlar" },
                    { 2, "En güzel pizzalar burada", "slider/s2.png", "Pizzalar" },
                    { 3, "En güzel noddlelar burada", "slider/s3.png", "Noddle" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsHome", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/pizza.jpg", false, "New York Pizza", 18.2m },
                    { 2, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/pizza.jpg", false, "Neapolitan pizza", 18.2m },
                    { 3, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/pizza.jpg", false, "Sicilya stili pizza", 18.2m },
                    { 4, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/pizza.jpg", false, "Romana Pizza", 18.2m },
                    { 5, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/pizza.jpg", false, "Chicago Pizza.", 18.2m },
                    { 6, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/burger.jpg", false, "Beyaz Peynirli Burger", 18.2m },
                    { 7, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/burger.jpg", false, "3. Rokforlu Burger", 18.2m },
                    { 8, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/burger.jpg", false, "4. Tavuk Burger", 18.2m },
                    { 9, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/burger.jpg", false, "Dana Baconlı Burger", 18.2m },
                    { 10, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Balık Noodle", 18.2m },
                    { 11, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Special Noodle", 18.2m },
                    { 12, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Tavuk Noodle", 18.2m },
                    { 13, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Körili Noodle", 18.2m },
                    { 14, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Gurme Noodle", 18.2m },
                    { 15, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Acılı Noodle", 18.2m },
                    { 16, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Perspiciatis quos itaque dolores? Placeat non vel, accusantium doloremque modi animi, ipsam sequi quidem, unde officiis error quisquam esse assumenda culpa sed. Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat earum aut placeat? Consectetur corrupti quo, dolor laborum, doloremque hic sed recusandae, quos enim totam cupiditate vero aperiam labore aliquam quibusdam.", "menu/noddle.jpg", false, "Balık Noodle", 18.2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
