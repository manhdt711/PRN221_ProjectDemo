using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

public partial class WorkHour
{
    public string EmployeeId { get; set; }

    public DateTime WorkDay { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public double? Coefficient { get; set; }

    public virtual Employee Employee { get; set; }
}
