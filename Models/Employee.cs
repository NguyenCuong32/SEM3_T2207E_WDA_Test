namespace WCD_test.Models;

public class Employee
{
    public int Id { get; set; }
    public string name { get; set; }
    public string Code { get; set; }
    public string rank { get; set; }
    public Department Department { get; set; }
}