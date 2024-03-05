using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m2stud_inst_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_Student_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    Navigation_CoursesCourse_Id = table.Column<int>(type: "int", nullable: false),
                    Navigation_DepartmentsDepartment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.Navigation_CoursesCourse_Id, x.Navigation_DepartmentsDepartment_Id });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Course_Navigation_CoursesCourse_Id",
                        column: x => x.Navigation_CoursesCourse_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_Navigation_DepartmentsDepartment_Id",
                        column: x => x.Navigation_DepartmentsDepartment_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    Navigation_CoursesCourse_Id = table.Column<int>(type: "int", nullable: false),
                    Navigation_InstructorsInstructor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.Navigation_CoursesCourse_Id, x.Navigation_InstructorsInstructor_Id });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_Navigation_CoursesCourse_Id",
                        column: x => x.Navigation_CoursesCourse_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Instructors_Navigation_InstructorsInstructor_Id",
                        column: x => x.Navigation_InstructorsInstructor_Id,
                        principalTable: "Instructors",
                        principalColumn: "Instructor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Std_Id = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.Crs_Id, x.Std_Id });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Course_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Student_Std_Id",
                        column: x => x.Std_Id,
                        principalTable: "Student",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_Navigation_DepartmentsDepartment_Id",
                table: "CourseDepartment",
                column: "Navigation_DepartmentsDepartment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_Navigation_InstructorsInstructor_Id",
                table: "CourseInstructor",
                column: "Navigation_InstructorsInstructor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Dept_Id",
                table: "Student",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_Std_Id",
                table: "StudentCourses",
                column: "Std_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
