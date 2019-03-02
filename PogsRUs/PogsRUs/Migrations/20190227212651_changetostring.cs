using Microsoft.EntityFrameworkCore.Migrations;

namespace PogsRUs.Migrations
{
    public partial class changetostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Carts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
