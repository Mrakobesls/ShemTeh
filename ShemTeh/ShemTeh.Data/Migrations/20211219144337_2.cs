using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShemTeh.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "QuestionTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "QuestionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
