using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class User
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string User_Email { get; set; }
        public string  User_Image { get; set; }
        public string User_Password { get; set; }

        [ForeignKey("Navigation_Role")]
        public int Role_Id { get; set; }






        #region Navigation property
        public Role Navigation_Role { get; set; }
        public Instructor? Navigation_Instructor { get; set; }
        public Student? Navigation_Student { get; set; }
        public HumanResource? Navigation_Human_Resource { get; set; }
        #endregion
    }
}
