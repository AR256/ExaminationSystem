using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Admin_User_Email",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchManagers_Users_Branch_Manager_Email",
                table: "BranchManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_Navigation_UsersUser_Email",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Std_User_Email",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_Std_User_Email",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_Navigation_UsersUser_Email",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_BranchManagers_Branch_Manager_Email",
                table: "BranchManagers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_Admin_User_Email",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Std_User_Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Navigation_UsersUser_Email",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Branch_Manager_Email",
                table: "BranchManagers");

            migrationBuilder.DropColumn(
                name: "Admin_User_Email",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Std_User_Id",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Navigation_UsersUser_Id",
                table: "RoleUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ins_User_Id",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Branch_Manager_User_Id",
                table: "BranchManagers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Admin_User_Id",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "User_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "Navigation_RolesRole_Id", "Navigation_UsersUser_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Email",
                table: "Users",
                column: "User_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Std_User_Id",
                table: "Students",
                column: "Std_User_Id",
                unique: true,
                filter: "[Std_User_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_Navigation_UsersUser_Id",
                table: "RoleUser",
                column: "Navigation_UsersUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Ins_User_Id",
                table: "Instructors",
                column: "Ins_User_Id",
                unique: true,
                filter: "[Ins_User_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchManagers_Branch_Manager_User_Id",
                table: "BranchManagers",
                column: "Branch_Manager_User_Id",
                unique: true,
                filter: "[Branch_Manager_User_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Admin_User_Id",
                table: "Admins",
                column: "Admin_User_Id",
                unique: true,
                filter: "[Admin_User_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Admin_User_Id",
                table: "Admins",
                column: "Admin_User_Id",
                principalTable: "Users",
                principalColumn: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchManagers_Users_Branch_Manager_User_Id",
                table: "BranchManagers",
                column: "Branch_Manager_User_Id",
                principalTable: "Users",
                principalColumn: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Ins_User_Id",
                table: "Instructors",
                column: "Ins_User_Id",
                principalTable: "Users",
                principalColumn: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_Navigation_UsersUser_Id",
                table: "RoleUser",
                column: "Navigation_UsersUser_Id",
                principalTable: "Users",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Std_User_Id",
                table: "Students",
                column: "Std_User_Id",
                principalTable: "Users",
                principalColumn: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Admin_User_Id",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchManagers_Users_Branch_Manager_User_Id",
                table: "BranchManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Ins_User_Id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_Navigation_UsersUser_Id",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Std_User_Id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Students_Std_User_Id",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_Navigation_UsersUser_Id",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_Ins_User_Id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_BranchManagers_Branch_Manager_User_Id",
                table: "BranchManagers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_Admin_User_Id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Std_User_Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Navigation_UsersUser_Id",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "Ins_User_Id",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Branch_Manager_User_Id",
                table: "BranchManagers");

            migrationBuilder.DropColumn(
                name: "Admin_User_Id",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "Std_User_Email",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Navigation_UsersUser_Email",
                table: "RoleUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ins_User_Email",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Branch_Manager_Email",
                table: "BranchManagers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_User_Email",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "User_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "Navigation_RolesRole_Id", "Navigation_UsersUser_Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Std_User_Email",
                table: "Students",
                column: "Std_User_Email",
                unique: true,
                filter: "[Std_User_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_Navigation_UsersUser_Email",
                table: "RoleUser",
                column: "Navigation_UsersUser_Email");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                unique: true,
                filter: "[Ins_User_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchManagers_Branch_Manager_Email",
                table: "BranchManagers",
                column: "Branch_Manager_Email");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Admin_User_Email",
                table: "Admins",
                column: "Admin_User_Email",
                unique: true,
                filter: "[Admin_User_Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Admin_User_Email",
                table: "Admins",
                column: "Admin_User_Email",
                principalTable: "Users",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchManagers_Users_Branch_Manager_Email",
                table: "BranchManagers",
                column: "Branch_Manager_Email",
                principalTable: "Users",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                principalTable: "Users",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_Navigation_UsersUser_Email",
                table: "RoleUser",
                column: "Navigation_UsersUser_Email",
                principalTable: "Users",
                principalColumn: "User_Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Std_User_Email",
                table: "Students",
                column: "Std_User_Email",
                principalTable: "Users",
                principalColumn: "User_Email");
        }
    }
}
