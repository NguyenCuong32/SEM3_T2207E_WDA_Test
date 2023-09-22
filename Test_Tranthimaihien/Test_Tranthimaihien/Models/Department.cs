using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Tranthimaihien.Models
{
    [Table("Department_Tbl")]
    public class Department
	{
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name ="Department name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string location { get; set; }
        
        [Display(Name = "Number of personals")]
        public int numberEmployee { get; set; }

        public virtual ICollection<Employee> employees { get; set; }
    }
}

