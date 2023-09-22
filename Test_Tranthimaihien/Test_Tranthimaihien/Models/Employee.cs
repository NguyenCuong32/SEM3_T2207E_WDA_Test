using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Tranthimaihien.Models
{
    [Table("Employee_Tbl")]
    public class Employee
	{
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Employee's name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Employee's Rank")]
        public string rank { get; set; }
        [ForeignKey("Department")]
        public int departmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}

