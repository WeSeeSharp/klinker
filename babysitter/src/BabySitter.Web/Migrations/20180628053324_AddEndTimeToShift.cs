using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace BabySitter.Web.Migrations
{
    public partial class AddEndTimeToShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<LocalDateTime>(
                name: "EndTime",
                table: "Shifts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Shifts");
        }
    }
}
