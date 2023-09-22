using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class Employee
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }
        public string code { get; set; }

        public string rank { get; set; }

        
        public int DepartmentId { get; set; }
       
    }
}
