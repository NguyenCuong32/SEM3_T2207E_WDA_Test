using System;
using System.ComponentModel.DataAnnotations;

namespace exam.Models
{
	public class DepartmentModel
	{
		[Key]
		public int Id { set; get; }
        [Required, MinLength(4, ErrorMessage = "Requires entering a Department name")]
        public string name { set; get; }
        [Required, MinLength(4, ErrorMessage = "Requires entering a Department code")]
        public string code { set; get; }
        [Required, MinLength(4, ErrorMessage = "Requires entering a Department location")]
        public string location { set; get; }
        [Required, MinLength(4, ErrorMessage = "Requires entering a Department number of personals")]
        public int numberOfPersonals { set; get; }

	}
}

