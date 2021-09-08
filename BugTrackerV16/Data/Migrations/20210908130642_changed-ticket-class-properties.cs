using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerV16.Data.Migrations
{
    public partial class changedticketclassproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ReportedByUserId",
                table: "Tickets",
                newName: "ReportedByUser");

            migrationBuilder.RenameColumn(
                name: "AssignedToUserId",
                table: "Tickets",
                newName: "Project");

            migrationBuilder.AddColumn<string>(
                name: "AssignedToUser",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedToUser",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ReportedByUser",
                table: "Tickets",
                newName: "ReportedByUserId");

            migrationBuilder.RenameColumn(
                name: "Project",
                table: "Tickets",
                newName: "AssignedToUserId");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
