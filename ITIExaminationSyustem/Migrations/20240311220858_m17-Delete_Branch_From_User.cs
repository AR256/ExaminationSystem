using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m17Delete_Branch_From_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_Navigation_BranchBranch_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Navigation_BranchBranch_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Navigation_BranchBranch_Id",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Navigation_BranchBranch_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Navigation_BranchBranch_Id",
                table: "Users",
                column: "Navigation_BranchBranch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_Navigation_BranchBranch_Id",
                table: "Users",
                column: "Navigation_BranchBranch_Id",
                principalTable: "Branches",
                principalColumn: "Branch_Id");
        }
    }
}
