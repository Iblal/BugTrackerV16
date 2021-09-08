using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerV16.Data.Migrations
{
    public partial class addprojectidcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Project",
                table: "Tickets",
                newName: "ProjectName");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ProjectName",
                table: "Tickets",
                newName: "Project");
        }
    }
}
