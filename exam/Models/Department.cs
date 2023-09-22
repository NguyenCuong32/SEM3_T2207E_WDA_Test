using System.ComponentModel.DataAnnotations;

namespace exam.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }

        public string location { get; set; }

        public int NumberOfPersonal { get; set; }

    }
}