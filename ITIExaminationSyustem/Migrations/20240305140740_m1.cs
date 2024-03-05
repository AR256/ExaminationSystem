using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Instructor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instructor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Instructor_Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department_MgrId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_Id);
                    table.ForeignKey(
                        name: "FK_Departments_Instructors_Department_MgrId",
                        column: x => x.Department_MgrId,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInstructors",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInstructors", x => new { x.Dept_Id, x.Ins_Id });
                    table.ForeignKey(
                        name: "FK_DepartmentInstructors_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentInstructors_Instructors_Ins_Id",
                        column: x => x.Ins_Id,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInstructors_Ins_Id",
                table: "DepartmentInstructors",
                column: "Ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Department_MgrId",
                table: "Departments",
                column: "Department_MgrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentInstructors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
