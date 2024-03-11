using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        public string  Branch_Name { get; set; }
        public string Branch_Manager_Name { get; set; }





        #region Navigation Property

        public ICollection<Department> Navigation_Departments { get; set; } = new HashSet<Department>();
        //public ICollection<MainDepartment> Navigation_Main_Departments { get; set; } = new HashSet<MainDepartment>();
        public Admin? Navigation_Admin { get; set; }

        #endregion
    }
}
