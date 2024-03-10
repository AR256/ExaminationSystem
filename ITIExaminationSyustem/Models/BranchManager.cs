using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class BranchManager
    {
        [Key]
        public int Branch_Manager_Id { get; set; }

        [ForeignKey("Navigation_User")]
        public int? Branch_Manager_User_Id { get; set; }
        public string Branch_Manager_Name { get; set; }





        #region Navigation property
        public User Navigation_User { get; set; }

        #endregion
    }
}
