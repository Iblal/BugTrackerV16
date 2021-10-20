using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerV16.Data.Migrations
{
    public partial class addArchivedColumnToProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Projects");
        }
    }
}
