using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainGame.Db.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Corrects_CorrectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CorrectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Corrects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 5,
                column: "QuestionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Corrects",
                keyColumn: "Id",
                keyValue: 6,
                column: "QuestionId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Corrects_QuestionId",
                table: "Corrects",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corrects_Questions_QuestionId",
                table: "Corrects",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corrects_Questions_QuestionId",
                table: "Corrects");

            migrationBuilder.DropIndex(
                name: "IX_Corrects_QuestionId",
                table: "Corrects");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Corrects");

            migrationBuilder.AddColumn<int>(
                name: "CorrectId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CorrectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CorrectId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CorrectId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CorrectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CorrectId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CorrectId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectId",
                table: "Questions",
                column: "CorrectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Corrects_CorrectId",
                table: "Questions",
                column: "CorrectId",
                principalTable: "Corrects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
