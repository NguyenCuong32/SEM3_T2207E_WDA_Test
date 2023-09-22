using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NguyenVanQuy.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Code { get; set; } = string.Empty;

		[Required]
		public string Rank { get; set; } = string.Empty;

		[ForeignKey("Department")]
		public int DepartmentId { get; set; }
		public virtual Department? department { get; set; }
	}
}
