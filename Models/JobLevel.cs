using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

public partial class JobLevel
{
    public int JobLevelId { get; set; }

    public decimal? SalaryPerHour { get; set; }

    public int? AllowanceId { get; set; }

    public virtual Allowance Allowance { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
