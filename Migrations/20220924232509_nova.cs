using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagedIdentity.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "WeatherForecasts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherForecasts",
                schema: "dbo",
                table: "WeatherForecasts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherForecasts",
                schema: "dbo",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "WeatherForecasts");
        }
    }
}
