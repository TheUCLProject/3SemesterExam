using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlMigrations.Migrations
{
    public partial class asd11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TlfNr = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opgaver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KompetenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Process_Kategori = table.Column<string>(type: "TEXT", nullable: false),
                    TimeEstimat = table.Column<int>(type: "INTEGER", nullable: false),
                    Kommentar = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opgaver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projekter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KundeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPerson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekter_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjektOpgaver",
                columns: table => new
                {
                    ProjektId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpgaveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjektOpgaver", x => new { x.ProjektId, x.OpgaveId });
                    table.ForeignKey(
                        name: "FK_ProjektOpgaver_Opgaver_OpgaveId",
                        column: x => x.OpgaveId,
                        principalTable: "Opgaver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjektOpgaver_Projekter_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projekter_KundeId",
                table: "Projekter",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjektOpgaver_OpgaveId",
                table: "ProjektOpgaver",
                column: "OpgaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjektOpgaver");

            migrationBuilder.DropTable(
                name: "Opgaver");

            migrationBuilder.DropTable(
                name: "Projekter");

            migrationBuilder.DropTable(
                name: "Kunder");
        }
    }
}
