using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIExaminationSyustem.Migrations
{
    /// <inheritdoc />
    public partial class m9DbSetsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceQuestion_Choice_Navigation_ChoicesChoice_Id",
                table: "ChoiceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceQuestion_Question_Navigation_QuestionsQuestion_Id",
                table: "ChoiceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Course_Navigation_CoursesCourse_Id",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branch_Brch_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MainDepartment_MainDept_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Student_StudId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQs_Exam_Exam_Id",
                table: "ExamQs");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQs_Question_Q_Id",
                table: "ExamQs");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_User_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_Crs_Id",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuestionType_Question_Type",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_Std_User_Email",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Course_Crs_Id",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Student_Std_Id",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Role_Id",
                table: "User");

            migrationBuilder.DropTable(
                name: "Human_Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainDepartment",
                table: "MainDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "QuestionType",
                newName: "QuestionTypes");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "MainDepartment",
                newName: "MainDepartments");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "Choices");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_User_Role_Id",
                table: "Users",
                newName: "IX_Users_Role_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Std_User_Email",
                table: "Students",
                newName: "IX_Students_Std_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Dept_Id",
                table: "Students",
                newName: "IX_Students_Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Question_Question_Type",
                table: "Questions",
                newName: "IX_Questions_Question_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Question_Crs_Id",
                table: "Questions",
                newName: "IX_Questions_Crs_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_StudId",
                table: "Exams",
                newName: "IX_Exams_StudId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_Crs_Id",
                table: "Exams",
                newName: "IX_Exams_Crs_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "User_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Student_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Role_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTypes",
                table: "QuestionTypes",
                column: "QuestionType_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Question_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainDepartments",
                table: "MainDepartments",
                column: "MainDepartment_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Exam_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Course_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                column: "Choice_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Branch_Id");

            migrationBuilder.CreateTable(
                name: "BranchManagers",
                columns: table => new
                {
                    Branch_Manager_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch_Manager_Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Branch_Manager_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchManagers", x => x.Branch_Manager_Id);
                    table.ForeignKey(
                        name: "FK_BranchManagers_Users_Branch_Manager_Email",
                        column: x => x.Branch_Manager_Email,
                        principalTable: "Users",
                        principalColumn: "User_Email");
                });

            migrationBuilder.CreateTable(
                name: "HumanResources",
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
                name: "IX_BranchManagers_Branch_Manager_Email",
                table: "BranchManagers",
                column: "Branch_Manager_Email");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceQuestion_Choices_Navigation_ChoicesChoice_Id",
                table: "ChoiceQuestion",
                column: "Navigation_ChoicesChoice_Id",
                principalTable: "Choices",
                principalColumn: "Choice_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceQuestion_Questions_Navigation_QuestionsQuestion_Id",
                table: "ChoiceQuestion",
                column: "Navigation_QuestionsQuestion_Id",
                principalTable: "Questions",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_Navigation_CoursesCourse_Id",
                table: "CourseDepartment",
                column: "Navigation_CoursesCourse_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "CoursesCourse_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branches_Brch_Id",
                table: "Departments",
                column: "Brch_Id",
                principalTable: "Branches",
                principalColumn: "Branch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MainDepartments_MainDept_Id",
                table: "Departments",
                column: "MainDept_Id",
                principalTable: "MainDepartments",
                principalColumn: "MainDepartment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQs_Exams_Exam_Id",
                table: "ExamQs",
                column: "Exam_Id",
                principalTable: "Exams",
                principalColumn: "Exam_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQs_Questions_Q_Id",
                table: "ExamQs",
                column: "Q_Id",
                principalTable: "Questions",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_Crs_Id",
                table: "Exams",
                column: "Crs_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudId",
                table: "Exams",
                column: "StudId",
                principalTable: "Students",
                principalColumn: "Student_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                principalTable: "Users",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_Crs_Id",
                table: "Questions",
                column: "Crs_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionTypes_Question_Type",
                table: "Questions",
                column: "Question_Type",
                principalTable: "QuestionTypes",
                principalColumn: "QuestionType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_Crs_Id",
                table: "StudentCourses",
                column: "Crs_Id",
                principalTable: "Courses",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_Std_Id",
                table: "StudentCourses",
                column: "Std_Id",
                principalTable: "Students",
                principalColumn: "Student_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Dept_Id",
                table: "Students",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Std_User_Email",
                table: "Students",
                column: "Std_User_Email",
                principalTable: "Users",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Role_Id",
                table: "Users",
                column: "Role_Id",
                principalTable: "Roles",
                principalColumn: "Role_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceQuestion_Choices_Navigation_ChoicesChoice_Id",
                table: "ChoiceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceQuestion_Questions_Navigation_QuestionsQuestion_Id",
                table: "ChoiceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_Navigation_CoursesCourse_Id",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesCourse_Id",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branches_Brch_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MainDepartments_MainDept_Id",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQs_Exams_Exam_Id",
                table: "ExamQs");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQs_Questions_Q_Id",
                table: "ExamQs");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_Crs_Id",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Ins_User_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_Crs_Id",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionTypes_Question_Type",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_Crs_Id",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_Std_Id",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Dept_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Std_User_Email",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Role_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BranchManagers");

            migrationBuilder.DropTable(
                name: "HumanResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTypes",
                table: "QuestionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainDepartments",
                table: "MainDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "QuestionTypes",
                newName: "QuestionType");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "MainDepartments",
                newName: "MainDepartment");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Choices",
                newName: "Choice");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Role_Id",
                table: "User",
                newName: "IX_User_Role_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Std_User_Email",
                table: "Student",
                newName: "IX_Student_Std_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Dept_Id",
                table: "Student",
                newName: "IX_Student_Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_Question_Type",
                table: "Question",
                newName: "IX_Question_Question_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_Crs_Id",
                table: "Question",
                newName: "IX_Question_Crs_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_StudId",
                table: "Exam",
                newName: "IX_Exam_StudId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_Crs_Id",
                table: "Exam",
                newName: "IX_Exam_Crs_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "User_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Student_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Role_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType",
                column: "QuestionType_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Question_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainDepartment",
                table: "MainDepartment",
                column: "MainDepartment_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Exam_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Course_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "Choice_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Branch_Id");

            migrationBuilder.CreateTable(
                name: "Human_Resource",
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
                name: "FK_ChoiceQuestion_Choice_Navigation_ChoicesChoice_Id",
                table: "ChoiceQuestion",
                column: "Navigation_ChoicesChoice_Id",
                principalTable: "Choice",
                principalColumn: "Choice_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceQuestion_Question_Navigation_QuestionsQuestion_Id",
                table: "ChoiceQuestion",
                column: "Navigation_QuestionsQuestion_Id",
                principalTable: "Question",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Course_Navigation_CoursesCourse_Id",
                table: "CourseDepartment",
                column: "Navigation_CoursesCourse_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourse_Id",
                table: "CourseInstructor",
                column: "CoursesCourse_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branch_Brch_Id",
                table: "Departments",
                column: "Brch_Id",
                principalTable: "Branch",
                principalColumn: "Branch_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MainDepartment_MainDept_Id",
                table: "Departments",
                column: "MainDept_Id",
                principalTable: "MainDepartment",
                principalColumn: "MainDepartment_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_Crs_Id",
                table: "Exam",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Student_StudId",
                table: "Exam",
                column: "StudId",
                principalTable: "Student",
                principalColumn: "Student_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQs_Exam_Exam_Id",
                table: "ExamQs",
                column: "Exam_Id",
                principalTable: "Exam",
                principalColumn: "Exam_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQs_Question_Q_Id",
                table: "ExamQs",
                column: "Q_Id",
                principalTable: "Question",
                principalColumn: "Question_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_User_Ins_User_Email",
                table: "Instructors",
                column: "Ins_User_Email",
                principalTable: "User",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_Crs_Id",
                table: "Question",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Course_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionType_Question_Type",
                table: "Question",
                column: "Question_Type",
                principalTable: "QuestionType",
                principalColumn: "QuestionType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_Std_User_Email",
                table: "Student",
                column: "Std_User_Email",
                principalTable: "User",
                principalColumn: "User_Email");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Course_Crs_Id",
                table: "StudentCourses",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Course_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Student_Std_Id",
                table: "StudentCourses",
                column: "Std_Id",
                principalTable: "Student",
                principalColumn: "Student_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Role_Id",
                table: "User",
                column: "Role_Id",
                principalTable: "Role",
                principalColumn: "Role_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
