using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class DepartmentModel
    {
        [Key]
        [Display(Name = "Tên căn hộ")]
        public String DepartmentName { get; set; }
        [Display(Name = "Mã nhà")]
        public String DepartmentCode { get; set; }
        [Display(Name = "Địa chỉ")]
        public String Location { get; set; }
        [Display(Name = "Số người")]
        public String Number_of_personals { get; set; }
    }
}
