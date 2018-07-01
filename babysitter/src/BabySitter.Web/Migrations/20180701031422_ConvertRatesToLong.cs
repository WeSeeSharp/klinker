using Microsoft.EntityFrameworkCore.Migrations;

namespace BabySitter.Web.Migrations
{
    public partial class ConvertRatesToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_Standard",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_BetweenBedtimeAndMidnight",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_AfterMidnight",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_Standard",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_BetweenBedtimeAndMidnight",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "HourlyRates_AfterMidnight",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_Standard",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_BetweenBedtimeAndMidnight",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_AfterMidnight",
                table: "Shifts",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_Standard",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_BetweenBedtimeAndMidnight",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "HourlyRates_AfterMidnight",
                table: "BabySitters",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
