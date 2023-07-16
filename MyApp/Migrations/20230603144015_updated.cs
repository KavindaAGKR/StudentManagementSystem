using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dbmodules_Dbstudnets_StudentsId",
                table: "Dbmodules");

            migrationBuilder.DropIndex(
                name: "IX_Dbmodules_StudentsId",
                table: "Dbmodules");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Dbmodules");

            migrationBuilder.CreateTable(
                name: "ModuleStudents",
                columns: table => new
                {
                    modulesId = table.Column<int>(type: "INTEGER", nullable: false),
                    studentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudents", x => new { x.modulesId, x.studentsId });
                    table.ForeignKey(
                        name: "FK_ModuleStudents_Dbmodules_modulesId",
                        column: x => x.modulesId,
                        principalTable: "Dbmodules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudents_Dbstudnets_studentsId",
                        column: x => x.studentsId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudents_studentsId",
                table: "ModuleStudents",
                column: "studentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleStudents");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Dbmodules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dbmodules_StudentsId",
                table: "Dbmodules",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dbmodules_Dbstudnets_StudentsId",
                table: "Dbmodules",
                column: "StudentsId",
                principalTable: "Dbstudnets",
                principalColumn: "Id");
        }
    }
}
