using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDuty { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
