using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShemTeh.Data.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "RadioButton" });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "CheckBox" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Group", "LastName", "Login", "Password", "RoleId" },
                values: new object[] { 1, "Teacher", 0, "Teacher", "Teacher", "10000.E1oWoDmucer3gKs31Cd1NA==.acfwsZcyNgPBDPw7KDCwtPp6g7lVZCYfVBMJppZtaQQ=", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
