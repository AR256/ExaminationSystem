using System.ComponentModel.DataAnnotations.Schema;

namespace ITIExaminationSyustem.Models
{
    public class DepartmentInstructors
    {
        [ForeignKey("Navigation_Department")]
        public int? Dept_Id { get; set; }
        [ForeignKey("Navigation_Instructor")]
        public int? Ins_Id { get; set; }

        #region Navigation property
        // Many To Many Has
        public Instructor Navigation_Instructor { get; set; }
        public Department Navigation_Department { get; set; }


        #endregion

    }
}
