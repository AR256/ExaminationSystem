using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class MainDepartment
    {
        [Key]
        public int MainDepartment_Id { get; set; }
        public string MainDepartment_Name { get; set; }


        #region Navigation property
        public ICollection<Department> Navigation_Departments { get; set; } = new HashSet<Department>();

        #endregion
    }
}
