using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class Admin
    {
        [Key]
        public int Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        [ForeignKey("Navigation_User")]
        public int? Admin_User_Id { get; set; }
        [ForeignKey("Navigation_Branch")]
        public int Admin_Branch_Id { get; set; }


        #region Navigation property
        public User Navigation_User { get; set; }
        public Branch Navigation_Branch { get; set; }
        #endregion

    }
}
