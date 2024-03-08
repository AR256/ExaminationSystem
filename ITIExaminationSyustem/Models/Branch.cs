using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Branch
    {
        [Key]
        public int Branch_Id { get; set; }
        public string  Branch_Name { get; set; }
  






        #region Navigation Property
        public ICollection<Department> Navigation_Departments { get; set; } = new HashSet<Department>();
        public ICollection<HumanResource> Navigation_Human_Resources { get; set; } = new HashSet<HumanResource>();
        #endregion
    }
}
