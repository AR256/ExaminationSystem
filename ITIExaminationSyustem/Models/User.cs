using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ITIExaminationSyustem.Models
{
    public class User
    {
        //remember to switch this id to be primary key
        [Key]
        public int User_Id { get; set; }
        [Required]
        [RegularExpression(@"^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$")]
        public string User_Email { get; set; }
        public string  User_Image { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
        public string User_Password { get; set; }






        #region Navigation property
        public ICollection<Role> Navigation_Roles { get; set; } = new HashSet<Role>();
        public Instructor? Navigation_Instructor { get; set; }
        public Student? Navigation_Student { get; set; }
        public Admin? Navigation_Admin { get; set; }
        public BranchManager? Navigation_BranchManager { get; set; }
        #endregion
    }
}
