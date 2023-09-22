using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PhongBanModel
    {
        [Key]
        public int Code { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public string Location { get; set; }


        [Required]
        public int NumberOfPersonel { get; set; }

    }
}
