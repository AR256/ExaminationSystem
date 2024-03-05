using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m3branchesexamcoursestudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_Navigation_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.DropColumn(
                name: "Department_Name",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Navigation_CoursesCourse_Id",
                table: "CourseInstructor",
                newName: "CoursesCourse_Id");

            migrationBuilder.AddColumn<int>(
                name: "Brch_Id",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainDept_Id",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Branch_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Branch_Id);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Exam_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_Duration = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false),
                    StudId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Exam_Id);
                    table.ForeignKey(
                        name: "FK_Exam_Course_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_Student_StudId",
                        column: x => x.StudId,
                        principalTable: "Student",
                        principalColumn: "Student_Id");
                });

            migrationBuilder.CreateTable(
                name: "MainDepartment",
                columns: table => new
                {
                    MainDepartment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainDepartment_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDepartment", x => x.MainDepartment_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Brch_Id",
                table: "Departments",
                column: "Brch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MainDept_Id",
                table: "Departments",
                column: "MainDept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Crs_Id",
                table: "Exam",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudId",
                table: "Exam",
                column: "StudId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "CoursesCourse_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branch_Brch_Id",
                table: "Departments",
                column: "Brch_Id",
                principalTable: "Branch",
                principalColumn: "Branch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MainDepartment_MainDept_Id",
                table: "Departments",
                column: "MainDept_Id",
                principalTable: "MainDepartment",
                principalColumn: "MainDepartment_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branch_Brch_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MainDepartment_MainDept_Id",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "MainDepartment");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Brch_Id",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MainDept_Id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Brch_Id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MainDept_Id",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "CoursesCourse_Id",
                table: "CourseInstructor",
                newName: "Navigation_CoursesCourse_Id");

            migrationBuilder.AddColumn<string>(
                name: "Department_Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_Navigation_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "Navigation_CoursesCourse_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
