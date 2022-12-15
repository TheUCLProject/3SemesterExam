using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnikOpstart.Services.Database.SqlMigrations.Migrations
{
    public partial class MedarbejderKompAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedarbejderId",
                table: "KompetenceEntities");

            migrationBuilder.CreateTable(
                name: "MedarbejderKompetencer",
                columns: table => new
                {
                    MedarbejderId = table.Column<int>(type: "INTEGER", nullable: false),
                    KompetenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedarbejderKompetencer", x => new { x.MedarbejderId, x.KompetenceId });
                    table.ForeignKey(
                        name: "FK_MedarbejderKompetencer_KompetenceEntities_KompetenceId",
                        column: x => x.KompetenceId,
                        principalTable: "KompetenceEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedarbejderKompetencer_MedarbejderEntities_MedarbejderId",
                        column: x => x.MedarbejderId,
                        principalTable: "MedarbejderEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedarbejderKompetencer_KompetenceId",
                table: "MedarbejderKompetencer",
                column: "KompetenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedarbejderKompetencer");

            migrationBuilder.AddColumn<int>(
                name: "MedarbejderId",
                table: "KompetenceEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
