using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m15removeBranchManageranddependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchManagers");

            migrationBuilder.AddColumn<int>(
                name: "Navigation_BranchBranch_Id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Branch_Manager_Name",
                table: "Branches",
                type: "nvarchar(max)",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Branch_Manager_Name",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "BranchManagers",
                columns: table => new
                {
                    Branch_Manager_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_Manager_User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchManagers", x => x.Branch_Manager_Id);
                    table.ForeignKey(
                        name: "FK_BranchManagers_Users_Branch_Manager_User_Id",
                        column: x => x.Branch_Manager_User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchManagers_Branch_Manager_User_Id",
                table: "BranchManagers",
                column: "Branch_Manager_User_Id",
                unique: true,
                filter: "[Branch_Manager_User_Id] IS NOT NULL");
        }
    }
}
