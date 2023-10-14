using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

public partial class Payment
{
    public string EmployeeId { get; set; }

    public DateTime SalaryPeriod { get; set; }

    public double? TotalHours { get; set; }

    public double? Coefficient { get; set; }

    public decimal? AmountTotal { get; set; }

    public decimal? OtherPayment { get; set; }

    public decimal? TotalPayments { get; set; }

    public virtual Employee Employee { get; set; }
}
