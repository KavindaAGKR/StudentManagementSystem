using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class results : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Results_Dbmodules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Dbstudnets_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_ModuleId",
                table: "Results",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentsId",
                table: "Results",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
