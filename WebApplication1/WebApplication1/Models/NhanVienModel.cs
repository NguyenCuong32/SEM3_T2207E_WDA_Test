using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class NhanVienModel
    {
        [Key]
        public int Code { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public int PhongBanCode { get; set; }
        [ForeignKey("PhongBanCode")]
        public PhongBanModel PhongBan { get; set; }


        [Required]
        public string Rank { get; set; }
    }
}
