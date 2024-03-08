using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Type { get; set; }

        #region Navigation property
        public ICollection<User> Navigation_Users { get; set; } = new HashSet<User>();

        #endregion
    }
}
