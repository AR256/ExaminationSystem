using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m19HasTakenExam_Added_in_StdCrs_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTakenExam",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTakenExam",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
