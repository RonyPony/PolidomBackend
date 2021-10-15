using Microsoft.EntityFrameworkCore.Migrations;

namespace Polidom.Data.Migrations
{
    public partial class addSomePropertiesToReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AssignedAuthorityId",
                table: "Reports",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Reports",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedAuthorityId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Reports");
        }
    }
}
