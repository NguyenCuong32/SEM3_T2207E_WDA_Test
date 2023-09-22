using System.ComponentModel.DataAnnotations;

namespace Sem3_exam.Mains.Models
{
    public class TestJob
    {
        [Key]
        [Display(Name = "Department type ID")]
        public int department_code { get; set; }
        [Required, MinLength(3, ErrorMessage = "Required to enter department name (minlength = 3).")]
        [Display(Name = "Department Name")]
        public string department_name { get; set; }

        [Required, MinLength(3, ErrorMessage = "Required to enter location description (minlength = 3).")]
        [Display(Name = "Department Room")]
        public string location { get; set; }
        [Required]
        [Display(Name = "Number of personals")]
        public int number_of_personals { get; set; }
    }
}
