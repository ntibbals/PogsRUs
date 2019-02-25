using Microsoft.EntityFrameworkCore.Migrations;

namespace PogsRUs.Migrations.ApplicationDb
{
    public partial class pro1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Professional",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Professional",
                table: "AspNetUsers");
        }
    }
}
