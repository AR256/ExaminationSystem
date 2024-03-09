using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class User
    {
        //remember to switch this id to be primary key
        public int User_Id { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string User_Email { get; set; }
        public string  User_Image { get; set; }
        public string User_Password { get; set; }






        #region Navigation property
        public ICollection<Role> Navigation_Roles { get; set; } = new HashSet<Role>();
        public Instructor? Navigation_Instructor { get; set; }
        public Student? Navigation_Student { get; set; }
        public Admin? Navigation_Admin { get; set; }
        #endregion
    }
}
