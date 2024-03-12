using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.ViewModels
{
    public class AddStudentViewModel
    {
        public int User_Id { get; set; }
        public int Student_Id { get; set; }
        public int Department_Id { get; set; }
        public List<Course> StudentCourses { get; set; }
        public List<Course> CoursesToAdd { get; set; }
    }
}
