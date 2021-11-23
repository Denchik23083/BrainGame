using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainGame.Db.Migrations
{
    public partial class removeNAme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quiz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quiz",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
