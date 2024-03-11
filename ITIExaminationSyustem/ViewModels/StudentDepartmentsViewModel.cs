using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.ViewModels
{
    public class StudentDepartmentsViewModel
    {
        public string Student_Email {  get; set; }
        public string Student_Name {  get; set; }
        public string Student_DepartmentName {  get; set; }
        public int Student_DepartmentNumber {  get; set; }
        public string Student_Image {  get; set; }

        public List<MainDepartment> MainDepartmentsInStudentBranch { get; set; }
        public List<Course> StudentCourses { get; set; }
        
    }
}
