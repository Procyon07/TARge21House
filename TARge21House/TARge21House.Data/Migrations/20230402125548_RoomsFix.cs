using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge21House.Data.Migrations
{
    public partial class RoomsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Houses",
                newName: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rooms",
                table: "Houses",
                newName: "Country");
        }
    }
}
