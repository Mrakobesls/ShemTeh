using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShemTeh.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Questions_QuestionId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "QuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_QuestionId",
                table: "QuestionAnswers",
                newName: "IX_QuestionAnswers_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Questions_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Questions_QuestionId",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.RenameTable(
                name: "QuestionAnswers",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "Companies",
                newName: "IX_Companies_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Questions_QuestionId",
                table: "Companies",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
