using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Crs_Id",
                table: "Exam",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Choice_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Choice_Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    QuestionType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.QuestionType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question_Type = table.Column<int>(type: "int", nullable: true),
                    Crs_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Question_Id);
                    table.ForeignKey(
                        name: "FK_Question_Course_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id");
                    table.ForeignKey(
                        name: "FK_Question_QuestionType_Question_Type",
                        column: x => x.Question_Type,
                        principalTable: "QuestionType",
                        principalColumn: "QuestionType_Id");
                });

            migrationBuilder.CreateTable(
                name: "ChoiceQuestion",
                columns: table => new
                {
                    Navigation_ChoicesChoice_Id = table.Column<int>(type: "int", nullable: false),
                    Navigation_QuestionsQuestion_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceQuestion", x => new { x.Navigation_ChoicesChoice_Id, x.Navigation_QuestionsQuestion_Id });
                    table.ForeignKey(
                        name: "FK_ChoiceQuestion_Choice_Navigation_ChoicesChoice_Id",
                        column: x => x.Navigation_ChoicesChoice_Id,
                        principalTable: "Choice",
                        principalColumn: "Choice_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceQuestion_Question_Navigation_QuestionsQuestion_Id",
                        column: x => x.Navigation_QuestionsQuestion_Id,
                        principalTable: "Question",
                        principalColumn: "Question_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceQuestion_Navigation_QuestionsQuestion_Id",
                table: "ChoiceQuestion",
                column: "Navigation_QuestionsQuestion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Crs_Id",
                table: "Question",
                column: "Crs_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Question_Type",
                table: "Question",
                column: "Question_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student");

            migrationBuilder.DropTable(
                name: "ChoiceQuestion");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.AlterColumn<int>(
                name: "Dept_Id",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Crs_Id",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
