using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class entityupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleId",
                table: "Dbresults");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudents_Dbmodules_modulesId",
                table: "ModuleStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudents_Dbstudnets_studentsId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "studentsId",
                table: "ModuleStudents",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "modulesId",
                table: "ModuleStudents",
                newName: "ModulesId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleStudents_studentsId",
                table: "ModuleStudents",
                newName: "IX_ModuleStudents_StudentsId");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Dbresults",
                newName: "ModuleID");

            migrationBuilder.RenameIndex(
                name: "IX_Dbresults_ModuleId",
                table: "Dbresults",
                newName: "IX_Dbresults_ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleID",
                table: "Dbresults",
                column: "ModuleID",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Dbmodules_ModulesId",
                table: "ModuleStudents",
                column: "ModulesId",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Dbstudnets_StudentsId",
                table: "ModuleStudents",
                column: "StudentsId",
                principalTable: "Dbstudnets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleID",
                table: "Dbresults");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudents_Dbmodules_ModulesId",
                table: "ModuleStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleStudents_Dbstudnets_StudentsId",
                table: "ModuleStudents");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "ModuleStudents",
                newName: "studentsId");

            migrationBuilder.RenameColumn(
                name: "ModulesId",
                table: "ModuleStudents",
                newName: "modulesId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleStudents_StudentsId",
                table: "ModuleStudents",
                newName: "IX_ModuleStudents_studentsId");

            migrationBuilder.RenameColumn(
                name: "ModuleID",
                table: "Dbresults",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Dbresults_ModuleID",
                table: "Dbresults",
                newName: "IX_Dbresults_ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleId",
                table: "Dbresults",
                column: "ModuleId",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Dbmodules_modulesId",
                table: "ModuleStudents",
                column: "modulesId",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleStudents_Dbstudnets_studentsId",
                table: "ModuleStudents",
                column: "studentsId",
                principalTable: "Dbstudnets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
