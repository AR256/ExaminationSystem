using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        public string  Branch_Name { get; set; }


        #region Navigation Property

        public ICollection<Department> Navigation_Departments { get; set; } = new HashSet<Department>();

        #endregion
    }
}
