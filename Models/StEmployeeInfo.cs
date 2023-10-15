using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_ProjectDemo.Models
{
    public class StEmployeeInfo
    {
        public class EmployeeInfo
        {
            public string EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string DepartmentName { get; set; }
            public string DepartmentDuty { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Job { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public decimal SalaryPerHour { get; set; }
            public int Permission { get; set; }
            public double PaymentCoefficient { get; set; }

            public DateTime BeginDate { get; set; }

            public DateTime? EndDate { get; set; }
        }
    }
}
