using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
	public class EmployeeModel
	{
		public int Id { set; get; }
        [Required, MinLength(4, ErrorMessage = "Requires entering a Employee name")]
        public string Name { set; get; }
        [Required, MinLength(2, ErrorMessage = "Requires entering a Employee code")]
        public string Code { set; get; }

		[ForeignKey("Department")]

		public int DepartmentID { set; get; }
		public DepartmentModel Departments { set; get; }
	}
}

