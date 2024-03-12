using ITIExaminationSyustem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.ViewModels
{
    public class DepartmentViewModel
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public int? Department_MgrId { set; get; }
        public int? Brch_Id { get; set; }
        public int? MainDept_Id { get; set; }
        public List<Branch> branches { get; set; }
        public List<MainDepartment> mainDepartments {  get; set; }
        public List<DepartmentInstructors> departmentInstructors { get; set; }
    }
}
