using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketService.DAL.Migrations
{
    public partial class withListing5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Listings_ListingId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Listings_ListingId",
                table: "Tickets",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Listings_ListingId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Listings_ListingId",
                table: "Tickets",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
