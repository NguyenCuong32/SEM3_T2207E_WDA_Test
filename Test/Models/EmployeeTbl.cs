using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class EmployeeTbl
{
    public string EmpId { get; set; } = null!;

    public string? EmpName { get; set; }

    public string Department { get; set; } = null!;

    public string? Rank { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public virtual DepartmentTbl DepartmentNavigation { get; set; } = null!;
}
