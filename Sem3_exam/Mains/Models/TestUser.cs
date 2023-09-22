using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sem3_exam.Mains.Models
{
    public class TestUser
    {
        [Key]
        public int employee_code { get; set; }


        [Required, MinLength(3, ErrorMessage = "Required to enter employee name (minlength = 3).")]
        [Display(Name = "Employee Full Name")]
        public string employee_name { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Required to choose department type.")]
        //Giá trị chọn từ 1 đến giá trị tối đa của kiểu dữ liệu int
        [Display(Name = "Department type")]
        public int department_code { get; set; }
        [ForeignKey("department_code")]  //Chỉ định khoá ngoại
        [Display(Name = "Department type")] //Xác định tên hiển thị trên Web(html)
        public virtual TestJob TypeJob { get; set; }

        [Required, MinLength(3, ErrorMessage = "Required to enter employee rank (minlength = 3).")]
        [Display(Name = "Department Rank")]
        public string employee_rnk { get; set; }

    }
}
