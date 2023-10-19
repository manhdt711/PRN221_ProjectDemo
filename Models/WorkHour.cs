using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

    public partial class WorkHour
    {
        public string EmployeeId { get; set; }
        public DateTime WorkDay { get; set; }
        public int? WorkHour1 { get; set; }
        public double? Coefficient { get; set; }

        public virtual Employee Employee { get; set; }
    }

