using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m20Bonus_column_Name_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bouns",
                table: "StudentCourses",
                newName: "Bonus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bonus",
                table: "StudentCourses",
                newName: "Bouns");
        }
    }
}
