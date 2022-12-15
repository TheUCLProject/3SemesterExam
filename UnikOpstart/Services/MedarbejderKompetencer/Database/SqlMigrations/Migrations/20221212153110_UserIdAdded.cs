using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class UserIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MedarbejderEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedarbejderEntities");
        }
    }
}
