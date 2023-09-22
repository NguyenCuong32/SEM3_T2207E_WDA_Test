using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThiTH.Models;

public class  Department
{
    [Key]
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentCode { get; set; }
    public string Location{ get; set; }
    public int numberOfPersonals { get; set; }
    
}