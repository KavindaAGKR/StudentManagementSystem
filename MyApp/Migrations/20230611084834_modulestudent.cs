using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class modulestudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbmoduleStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbmoduleStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbmoduleStudents_Dbmodules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbmoduleStudents_Dbstudnets_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbmoduleStudents_ModuleId",
                table: "DbmoduleStudents",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_DbmoduleStudents_StudentId",
                table: "DbmoduleStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbmoduleStudents");
        }
    }
}
