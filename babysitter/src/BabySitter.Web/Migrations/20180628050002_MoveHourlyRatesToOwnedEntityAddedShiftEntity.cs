using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BabySitter.Web.Migrations
{
    public partial class MoveHourlyRatesToOwnedEntityAddedShiftEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HourlyRateBetweenBedtimeAndMidnight",
                table: "BabySitters",
                newName: "HourlyRates_Standard");

            migrationBuilder.RenameColumn(
                name: "HourlyRateAfterMidnight",
                table: "BabySitters",
                newName: "HourlyRates_BetweenBedtimeAndMidnight");

            migrationBuilder.RenameColumn(
                name: "HourlyRate",
                table: "BabySitters",
                newName: "HourlyRates_AfterMidnight");

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    StartTime = table.Column<LocalDateTime>(nullable: false),
                    Bedtime = table.Column<LocalDateTime>(nullable: false),
                    HourlyRates_Standard = table.Column<int>(nullable: false),
                    HourlyRates_BetweenBedtimeAndMidnight = table.Column<int>(nullable: false),
                    HourlyRates_AfterMidnight = table.Column<int>(nullable: false),
                    SitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_BabySitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "BabySitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_SitterId",
                table: "Shifts",
                column: "SitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.RenameColumn(
                name: "HourlyRates_Standard",
                table: "BabySitters",
                newName: "HourlyRateBetweenBedtimeAndMidnight");

            migrationBuilder.RenameColumn(
                name: "HourlyRates_BetweenBedtimeAndMidnight",
                table: "BabySitters",
                newName: "HourlyRateAfterMidnight");

            migrationBuilder.RenameColumn(
                name: "HourlyRates_AfterMidnight",
                table: "BabySitters",
                newName: "HourlyRate");
        }
    }
}
