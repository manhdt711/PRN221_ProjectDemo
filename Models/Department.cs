using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

public partial class Department
{
    public string DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentDuty { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
