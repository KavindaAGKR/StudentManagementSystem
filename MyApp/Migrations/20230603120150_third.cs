using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbstudentModules",
                table: "DbstudentModules");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DbstudentModules",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbstudentModules",
                table: "DbstudentModules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DbstudentModules_StudentId",
                table: "DbstudentModules",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbstudentModules",
                table: "DbstudentModules");

            migrationBuilder.DropIndex(
                name: "IX_DbstudentModules_StudentId",
                table: "DbstudentModules");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DbstudentModules",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbstudentModules",
                table: "DbstudentModules",
                columns: new[] { "StudentId", "ModuleId" });
        }
    }
}
