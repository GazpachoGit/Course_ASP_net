using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketService.DAL.Migrations
{
    public partial class withListing3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Listings",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Listings",
                newName: "id");
        }
    }
}
