using Microsoft.EntityFrameworkCore;

namespace ITIExaminationSyustem.Models
{
    public class Exam_Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<DepartmentInstructors> DepartmentInstructors { set; get; }

        public Exam_Context()
        {

        }
        public Exam_Context(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentInstructors>().HasKey(c => new { c.Dept_Id, c.Ins_Id });
            modelBuilder.Entity<StudentCourses>().HasKey(c => new { c.Crs_Id, c.Std_Id });
            base.OnModelCreating(modelBuilder);
        }
    }
}
