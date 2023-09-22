namespace WCD_test.Models;

public class Department
{
    public int Id { get; set; }
    public string name { get; set; }
    public string DepartmentCode { get; set; }
    public string Location { get; set; }
    public List<Employee>? Employees { get; set; }
    
}