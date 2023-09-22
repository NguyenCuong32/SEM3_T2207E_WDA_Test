using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMVC_NguyenVanQuy.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int Code { get; set; }

		[Required]
		public string Rank { get; set; } = string.Empty;

		[ForeignKey("Department")]
		public int DepartmenteId { get; set; }
		public virtual Department? department { get; set; }

	}
}
