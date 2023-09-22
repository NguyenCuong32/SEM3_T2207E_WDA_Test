using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class DepartmentTbl
{
    public string DepartmentId { get; set; } = null!;

    public string? DepartmentName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<EmployeeTbl> EmployeeTbls { get; set; } = new List<EmployeeTbl>();
}
