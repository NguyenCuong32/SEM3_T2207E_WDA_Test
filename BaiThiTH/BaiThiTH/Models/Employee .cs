using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThiTH.Models;

public class  Employee 
{
    [Key]
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public int EmployeeCode { get; set; }
    public string Department{ get; set; }
    public string Rank { get; set; }
    
}