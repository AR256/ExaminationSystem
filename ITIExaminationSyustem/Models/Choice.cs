using System.ComponentModel.DataAnnotations;

namespace ITIExaminationSyustem.Models
{
    public class Choice
    {
        [Key]
        public int Choice_Id { get; set; }
        public string Choice_Text { get; set; }

        #region Navigation property
        public ICollection<Question> Navigation_Questions { get; set; } = new HashSet<Question>();

        #endregion
    }
}
