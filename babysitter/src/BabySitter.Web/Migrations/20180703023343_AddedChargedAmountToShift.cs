using Microsoft.EntityFrameworkCore.Migrations;

namespace BabySitter.Web.Migrations
{
    public partial class AddedChargedAmountToShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AmountCharged",
                table: "Shifts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountCharged",
                table: "Shifts");
        }
    }
}
