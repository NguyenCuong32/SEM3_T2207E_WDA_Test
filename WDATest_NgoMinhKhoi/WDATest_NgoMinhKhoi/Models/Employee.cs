using System.ComponentModel.DataAnnotations;

namespace WDATest_NgoMinhKhoi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
