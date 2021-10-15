using Microsoft.EntityFrameworkCore.Migrations;

namespace Polidom.Data.Migrations
{
    public partial class ChangeSomePropertiesToDomains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sector",
                table: "AspNetUsers",
                newName: "Sector");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sector",
                table: "AspNetUsers",
                newName: "sector");
        }
    }
}
