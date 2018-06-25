using Microsoft.EntityFrameworkCore.Migrations;

namespace BabySitter.Web.Migrations
{
    public partial class AddHourlyRatesToBabySitter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HourlyRate",
                table: "BabySitters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HourlyRateAfterMidnight",
                table: "BabySitters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HourlyRateBetweenBedtimeAndMidnight",
                table: "BabySitters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "BabySitters");

            migrationBuilder.DropColumn(
                name: "HourlyRateAfterMidnight",
                table: "BabySitters");

            migrationBuilder.DropColumn(
                name: "HourlyRateBetweenBedtimeAndMidnight",
                table: "BabySitters");
        }
    }
}
