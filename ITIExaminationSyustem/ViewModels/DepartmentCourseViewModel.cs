using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.ViewModels
{
    public class DepartmentCourseViewModel
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public List<Course> CoursesInDept { get; set; }
        public List<Course> CoursesNotInDept { get; set; }
    }
}
