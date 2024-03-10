using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.ViewModels
{
    public class StudentDepartmentsViewModel
    {
        public string Student_Email {  get; set; }
        public string Student_Name {  get; set; }
        public string Student_DepartmentName {  get; set; }

        public List<Department> Departments { get; set; }=new List<Department>();
        public List<Course> Courses { get; set; }=new List<Course>();
        
    }
}
