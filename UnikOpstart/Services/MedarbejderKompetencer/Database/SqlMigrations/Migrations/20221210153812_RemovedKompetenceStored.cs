using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class RemovedKompetenceStored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedarbejderId",
                table: "KompetenceEntities");

            migrationBuilder.CreateTable(
                name: "MedarbejderKompetenceEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedarbejderId = table.Column<int>(type: "INTEGER", nullable: false),
                    KompetenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedarbejderKompetenceEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedarbejderKompetenceEntities_KompetenceEntities_KompetenceId",
                        column: x => x.KompetenceId,
                        principalTable: "KompetenceEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedarbejderKompetenceEntities_MedarbejderEntities_MedarbejderId",
                        column: x => x.MedarbejderId,
                        principalTable: "MedarbejderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedarbejderKompetenceEntities_KompetenceId",
                table: "MedarbejderKompetenceEntities",
                column: "KompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedarbejderKompetenceEntities_MedarbejderId",
                table: "MedarbejderKompetenceEntities",
                column: "MedarbejderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedarbejderKompetenceEntities");

            migrationBuilder.AddColumn<int>(
                name: "MedarbejderId",
                table: "KompetenceEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
