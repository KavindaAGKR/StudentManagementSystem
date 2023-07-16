using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class resultupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Dbmodules_ModuleId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Dbstudnets_StudentsId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Dbresults");

            migrationBuilder.RenameIndex(
                name: "IX_Results_StudentsId",
                table: "Dbresults",
                newName: "IX_Dbresults_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_ModuleId",
                table: "Dbresults",
                newName: "IX_Dbresults_ModuleId");

            migrationBuilder.AlterColumn<string>(
                name: "ModuleId",
                table: "Dbmodules",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dbresults",
                table: "Dbresults",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleId",
                table: "Dbresults",
                column: "ModuleId",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dbresults_Dbstudnets_StudentsId",
                table: "Dbresults",
                column: "StudentsId",
                principalTable: "Dbstudnets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dbresults_Dbmodules_ModuleId",
                table: "Dbresults");

            migrationBuilder.DropForeignKey(
                name: "FK_Dbresults_Dbstudnets_StudentsId",
                table: "Dbresults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dbresults",
                table: "Dbresults");

            migrationBuilder.RenameTable(
                name: "Dbresults",
                newName: "Results");

            migrationBuilder.RenameIndex(
                name: "IX_Dbresults_StudentsId",
                table: "Results",
                newName: "IX_Results_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Dbresults_ModuleId",
                table: "Results",
                newName: "IX_Results_ModuleId");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Dbmodules",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Dbmodules_ModuleId",
                table: "Results",
                column: "ModuleId",
                principalTable: "Dbmodules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Dbstudnets_StudentsId",
                table: "Results",
                column: "StudentsId",
                principalTable: "Dbstudnets",
                principalColumn: "Id");
        }
    }
}
