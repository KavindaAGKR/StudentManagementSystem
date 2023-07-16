using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class mapremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbstudentModules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbstudentModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Credit = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbstudentModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbstudentModules_Dbmodules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbstudentModules_Dbstudnets_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbstudentModules_ModuleId",
                table: "DbstudentModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DbstudentModules_StudentId",
                table: "DbstudentModules",
                column: "StudentId");
        }
    }
}
