using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class DatatimeConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpgaveId",
                table: "Bookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpgaveId",
                table: "Bookings");
        }
    }
}
