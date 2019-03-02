using Microsoft.EntityFrameworkCore.Migrations;

namespace PogsRUs.Migrations
{
    public partial class addedNamePropInCartProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartProducts");
        }
    }
}
