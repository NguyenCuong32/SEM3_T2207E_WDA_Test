using System.ComponentModel.DataAnnotations;

namespace BaiThi.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfPersonals { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
