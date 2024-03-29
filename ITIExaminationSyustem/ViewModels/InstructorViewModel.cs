﻿using ITIExaminationSyustem.Models;

namespace ITIExaminationSyustem.ViewModels
{
    public class InstructorViewModel
    {
        public int Branch_Id { get; set; }
        public string Instructor_Name { get; set; }
        public string Instructor_Email { get; set; }
        public string Instructor_Image { get; set; }
        public List<Department> Managed_Departments { get; set; }
        public int Instructor_Id { get; set; }
        public int Instructor_User_Id { get; set; }
        public List<Department> Departments { get; set; }
        public List<Department> OtherDepartments { get; set; }
        public List<Course> Courses { get; set; }
        public List<Course> OtherCourses { get; set; }
    }
}
