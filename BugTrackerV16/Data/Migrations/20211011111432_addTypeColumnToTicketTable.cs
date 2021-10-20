using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerV16.Data.Migrations
{
    public partial class addTypeColumnToTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tickets");
        }
    }
}
