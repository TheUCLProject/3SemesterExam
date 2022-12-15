using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlMigrations.Migrations
{
    public partial class concurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Projekter",
                type: "INTEGER",
                rowVersion: true,
            nullable: false,
            defaultValue: 0);

            migrationBuilder.Sql("CREATE TRIGGER UpdateProjektVersion " +
                "AFTER UPDATE ON Projekter " +
                "BEGIN " +
                "UPDATE Projekter " +
                "SET Version = Version + 1 " +
                "WHERE rowid = NEW.rowid; " +
                "END; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Projekter");
        }
    }
}
