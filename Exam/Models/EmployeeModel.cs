using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class EmployeeModel
    {
        [Key]

        [Display(Name = "Tên nhân viên")]
        public String EmployeeName { get; set; }
        [Display(Name = "Code nhân viên")]
        public String EmployeeCode { get; set; }
        [Display(Name = "Rank nhân viên")]
        public String EmployeeRank { get; set; }
        
    }
}
