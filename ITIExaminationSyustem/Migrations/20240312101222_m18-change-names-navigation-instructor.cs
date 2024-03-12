using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m18changenamesnavigationinstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.RenameColumn(
                name: "CoursesCourse_Id",
                table: "CourseInstructor",
                newName: "Navigation_CoursesCourse_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_Navigation_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "Navigation_CoursesCourse_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_Navigation_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.RenameColumn(
                name: "Navigation_CoursesCourse_Id",
                table: "CourseInstructor",
                newName: "CoursesCourse_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "CoursesCourse_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
