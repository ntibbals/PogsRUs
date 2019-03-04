using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PogsRUs.Migrations.PogsRUsDb
{
    public partial class frankenMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PogType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    CartID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SingleItemPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    TransactionHistoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SingleItemPrice = table.Column<decimal>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionHistoryProducts_TransactionHistories_TransactionHistoryID",
                        column: x => x.TransactionHistoryID,
                        principalTable: "TransactionHistories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "PogType", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "A super sick Red Slammer.", "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png", "Red Slammer", 0, 1.00m, "S-Red-1" },
                    { 2, "A super sick Red Milk Cap.", "https://static1.milkcapmania.co.uk/Img/pogs/Canada%20Games/Casper/Kinis/300DPI/Red-07.png", "Red Milk Cap", 1, 0.50m, "MC-Red-2" },
                    { 3, "A super sick Blue Slammer.", "http://i.ebayimg.com/00/s/MTE3N1gxMTc3/z/~TIAAOSwEetWAoU-/$_35.JPG", "Blue Slammer", 0, 1.00m, "S-Blue-3" },
                    { 4, "A super sick Blue Milk Cap.", "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/23-Blue.png", "Blue Milk Cap", 1, 0.50m, "MC-Blue-4" },
                    { 5, "A super sick Green Slammer.", "https://i.pinimg.com/originals/39/a6/66/39a666224fb6e0ce3beed353f8f63395.jpg", "Green Slammer", 0, 1.00m, "S-Green-5" },
                    { 6, "A super sick Green Milk Cap.", "https://static1.milkcapmania.co.uk/Img/pogs/The%20Tick/Kinis/300DPI/Green-Arthur.png", "Green Milk Cap", 1, 0.50m, "MC-Green-6" },
                    { 7, "A super sick Yellow Slammer.", "https://static1.milkcapmania.co.uk/Img/Chupa%20Caps/Slammers/300DPI/Yellow.png", "Yellow Slammer", 0, 1.00m, "S-Yellow-7" },
                    { 8, "A super sick Yellow Milk Cap.", "https://static1.milkcapmania.co.uk/Img/pogs/Avimage/Power%20Rangers/300DPI/54-Yellow-Ranger-%28Gold%29.png", "Yellow Milk Cap", 1, 0.50m, "MC-Yellow-8" },
                    { 9, "A super sick Orange Slammer.", "https://static1.milkcapmania.co.uk/Img/Fun%20Caps/031-060%20Aladdin/Slammers/300DPI/Lamp-orange.png", "Orange Slammer", 0, 1.00m, "S-Orange-9" },
                    { 10, "A super sick Orange Milk Cap.", "https://mightyjabba.files.wordpress.com/2010/08/jabba_pog_slammer2.jpg?w=300&h=282", "Orange Milk Cap", 1, 0.50m, "MC-Orange-10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartID",
                table: "CartProducts",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryProducts_TransactionHistoryID",
                table: "TransactionHistoryProducts",
                column: "TransactionHistoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TransactionHistoryProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "TransactionHistories");
        }
    }
}
