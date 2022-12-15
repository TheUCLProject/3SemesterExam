using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class KompetenceStored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KompetenceStoredEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Egenskab = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompetenceStoredEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompetenceStoredEntities");
        }
    }
}
