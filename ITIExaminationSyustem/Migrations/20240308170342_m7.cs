using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_Email",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Student_Password",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Instructor_Email",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Instructor_Password",
                table: "Instructors");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "StudentCourses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Bouns",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ins_Feedback",
                table: "StudentCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Std_Feedback",
                table: "StudentCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Std_User_Name",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ins_User_Name",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Email);
                    table.ForeignKey(
                        name: "FK_User_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Role",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Std_User_Name",
                table: "Student",
                column: "Std_User_Name",
                unique: true,
                filter: "[Std_User_Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Ins_User_Name",
                table: "Instructors",
                column: "Ins_User_Name",
                unique: true,
                filter: "[Ins_User_Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_Id",
                table: "User",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_User_Ins_User_Name",
                table: "Instructors",
                column: "Ins_User_Name",
                principalTable: "User",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_Std_User_Name",
                table: "Student",
                column: "Std_User_Name",
                principalTable: "User",
                principalColumn: "User_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_User_Ins_User_Name",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_Std_User_Name",
                table: "Student");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Student_Std_User_Name",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Ins_User_Name",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Bouns",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Ins_Feedback",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Std_Feedback",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Std_User_Name",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Ins_User_Name",
                table: "Instructors");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Email",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Password",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructor_Email",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructor_Password",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
