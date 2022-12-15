using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlMigrations.Migrations
{
    public partial class AddedActiveProgressToProjekt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveProcess",
                table: "Projekter",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveProcess",
                table: "Projekter");
        }
    }
}
