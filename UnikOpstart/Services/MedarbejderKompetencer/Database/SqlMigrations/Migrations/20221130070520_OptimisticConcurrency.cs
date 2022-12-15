using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class OptimisticConcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "MedarbejderEntities",
                type: "INTEGER",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("CREATE TRIGGER UpdateMedarbejderEntitesVersion " +
                "AFTER UPDATE ON MedarbejderEntities " +
                "BEGIN " +
                "UPDATE MedarbejderEntities " +
                "SET Version = Version + 1 " +
                "WHERE rowid = NEW.rowid; " +
                "END; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "MedarbejderEntities");
        }
    }
}
