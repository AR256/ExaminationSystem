using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class HumanResource
    {
        [Key]
        public int Human_Resource_Id { get; set; }
        public string Human_Resource_Name { get; set; }
        [ForeignKey("Navigation_User")]
        public string HR_User_Email { get; set; }
        [ForeignKey("Navigation_Branch")]
        public int  HR_Branch_Id{ get; set; }





        #region Navigation property
        public User Navigation_User { get; set; }
        public Branch Navigation_Branch { get; set; }
        #endregion
    }
}

