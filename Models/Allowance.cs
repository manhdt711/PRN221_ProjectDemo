using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models
{
    public partial class Allowance
    {
        public Allowance()
        {
            JobLevels = new HashSet<JobLevel>();
        }

        public int AllowanceId { get; set; }
        public string AllowanceName { get; set; }
        public decimal? AllowanceAmount { get; set; }

        public virtual ICollection<JobLevel> JobLevels { get; set; }
    }
}
