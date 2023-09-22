using System.ComponentModel.DataAnnotations;

namespace NguyenQuangTao.Models
{
    public class Department
    {
        [Key]
        [Required]
        [Display(Name = "Mã Phòng Ban")]

        public int DepartmentCode { get; set; }
        [Display(Name = "Tên Phòng Ban")]
        public string DepartmentName { get; set; }
        [Display(Name = "Vị trí")]
        public string Location { get; set; }
        [Display(Name = "Số Lượng")]
        public string NumberOfPersonals { get; set; }
    }
}
