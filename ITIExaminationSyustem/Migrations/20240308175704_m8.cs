using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_User_Ins_User_Name",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_Std_User_Name",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_Std_User_Name",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Ins_User_Name",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "Std_User_Name",
                table: "Student",
                newName: "Std_User_Email");

            migrationBuilder.RenameColumn(
                name: "Ins_User_Name",
                table: "Instructors",
                newName: "Ins_User_Email");

            migrationBuilder.CreateTable(
                name: "Human_Resource",
                columns: table => new
                {
                    Human_Resource_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Human_Resource_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HR_User_Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HR_Branch_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human_Resource", x => x.Human_Resource_Id);
                    table.ForeignKey(
                        name: "FK_Human_Resource_Branch_HR_Branch_Id",
                        column: x => x.HR_Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Branch_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Human_Resource_User_HR_User_Email",
                        column: x => x.HR_User_Email,
                        principalTable: "User",
                        principalColumn: "User_Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Std_User_Email",
                table: "Student",
                column: "Std_User_Email",
                unique: true,
                filter: "[Std_User_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                unique: true,
                filter: "[Ins_User_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Human_Resource_HR_Branch_Id",
                table: "Human_Resource",
                column: "HR_Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Human_Resource_HR_User_Email",
                table: "Human_Resource",
                column: "HR_User_Email",
                unique: true,
                filter: "[HR_User_Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_User_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                principalTable: "User",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_Std_User_Email",
                table: "Student",
                column: "Std_User_Email",
                principalTable: "User",
                principalColumn: "User_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_User_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_Std_User_Email",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Human_Resource");

            migrationBuilder.DropIndex(
                name: "IX_Student_Std_User_Email",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "Std_User_Email",
                table: "Student",
                newName: "Std_User_Name");

            migrationBuilder.RenameColumn(
                name: "Ins_User_Email",
                table: "Instructors",
                newName: "Ins_User_Name");

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
    }
}
