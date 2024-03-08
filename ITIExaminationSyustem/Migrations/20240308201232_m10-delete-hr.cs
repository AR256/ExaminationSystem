using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m10deletehr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanResources");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin_User_Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Admin_Branch_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_Id);
                    table.ForeignKey(
                        name: "FK_Admins_Branches_Admin_Branch_Id",
                        column: x => x.Admin_Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Branch_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Admin_User_Email",
                        column: x => x.Admin_User_Email,
                        principalTable: "Users",
                        principalColumn: "User_Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Admin_Branch_Id",
                table: "Admins",
                column: "Admin_Branch_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Admin_User_Email",
                table: "Admins",
                column: "Admin_User_Email",
                unique: true,
                filter: "[Admin_User_Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.CreateTable(
                name: "HumanResources",
                columns: table => new
                {
                    Human_Resource_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HR_Branch_Id = table.Column<int>(type: "int", nullable: false),
                    HR_User_Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Human_Resource_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResources", x => x.Human_Resource_Id);
                    table.ForeignKey(
                        name: "FK_HumanResources_Branches_HR_Branch_Id",
                        column: x => x.HR_Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Branch_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HumanResources_Users_HR_User_Email",
                        column: x => x.HR_User_Email,
                        principalTable: "Users",
                        principalColumn: "User_Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HumanResources_HR_Branch_Id",
                table: "HumanResources",
                column: "HR_Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HumanResources_HR_User_Email",
                table: "HumanResources",
                column: "HR_User_Email",
                unique: true,
                filter: "[HR_User_Email] IS NOT NULL");
        }
    }
}
