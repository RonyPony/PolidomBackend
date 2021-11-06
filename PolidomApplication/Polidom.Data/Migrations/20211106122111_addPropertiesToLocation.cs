using Microsoft.EntityFrameworkCore.Migrations;

namespace Polidom.Data.Migrations
{
    public partial class addPropertiesToLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReporterUserId",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Locality",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterUserId",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
