using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainGame.Db.Migrations
{
    public partial class NumberQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "PlantsQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "MushroomsQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "AnimalQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "PlantsQuestions");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "MushroomsQuestions");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AnimalQuestions");
        }
    }
}
