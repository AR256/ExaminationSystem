using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ITIExaminationSyustem.Models
{
    public class Exam_Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<DepartmentInstructors> DepartmentInstructors { set; get; }
        public DbSet<Branch> Branches { set; get; }
        public DbSet<Choice> Choices { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Exam> Exams { set; get; }
        public DbSet<ExamQs> ExamQs { set; get; }
        public DbSet<MainDepartment> MainDepartments { set; get; }
        public DbSet<Question> Questions { set; get; }
        public DbSet<QuestionType> QuestionTypes { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudentCourse> StudentCourses { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Admin> Admins { set; get; }




        public Exam_Context()
        {

        }
        public Exam_Context(DbContextOptions option) : base(option)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentInstructors>().HasKey(c => new { c.Dept_Id, c.Ins_Id });
            modelBuilder.Entity<StudentCourse>().HasKey(c => new { c.Crs_Id, c.Std_Id });
            modelBuilder.Entity<ExamQs>().HasKey(c => new { c.Exam_Id, c.Q_Id });
            modelBuilder.Entity<User>().HasIndex(e=>e.User_Email).IsUnique();

          


            base.OnModelCreating(modelBuilder);
        }
    }
}
