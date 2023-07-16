using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dbstudnets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    RegNo = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TelNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbstudnets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dbusers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbusers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dbmodules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Credit = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbmodules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dbmodules_Dbstudnets_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Dbstudnets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DbstudentModules",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<string>(type: "TEXT", nullable: false),
                    Credit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbstudentModules", x => new { x.StudentId, x.ModuleId });
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
                name: "IX_Dbmodules_StudentsId",
                table: "Dbmodules",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_DbstudentModules_ModuleId",
                table: "DbstudentModules",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbstudentModules");

            migrationBuilder.DropTable(
                name: "Dbusers");

            migrationBuilder.DropTable(
                name: "Dbmodules");

            migrationBuilder.DropTable(
                name: "Dbstudnets");
        }
    }
}
