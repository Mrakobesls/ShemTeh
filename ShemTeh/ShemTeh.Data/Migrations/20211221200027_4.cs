using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShemTeh.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TestAssignees_Users_UserId",
                table: "TestAssignees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestAssignees_Users_UserId",
                table: "TestAssignees");

            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_Users_UserId",
                table: "TestResults");
        }
    }
}
