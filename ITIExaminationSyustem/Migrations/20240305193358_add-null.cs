using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class addnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamQs",
                columns: table => new
                {
                    Exam_Id = table.Column<int>(type: "int", nullable: false),
                    Q_Id = table.Column<int>(type: "int", nullable: false),
                    Student_Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQs", x => new { x.Exam_Id, x.Q_Id });
                    table.ForeignKey(
                        name: "FK_ExamQs_Exam_Exam_Id",
                        column: x => x.Exam_Id,
                        principalTable: "Exam",
                        principalColumn: "Exam_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQs_Question_Q_Id",
                        column: x => x.Q_Id,
                        principalTable: "Question",
                        principalColumn: "Question_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQs_Q_Id",
                table: "ExamQs",
                column: "Q_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQs");
        }
    }
}
