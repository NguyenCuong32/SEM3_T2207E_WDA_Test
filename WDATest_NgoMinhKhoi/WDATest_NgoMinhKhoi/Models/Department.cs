using System.ComponentModel.DataAnnotations;

namespace WDATest_NgoMinhKhoi.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string NumberOfPersonal { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
