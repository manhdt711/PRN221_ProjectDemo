using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_ProjectDemo.Models
{
    public partial class StPayment
    {
        public string EMPID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? TotalHours { get; set; }
        public int? LevelId { get; set; }
        public decimal? SalaryPerHour { get; set; }
        public string DepartmentName { get; set; }
        public string PhoneNumber { get; set; }
        public string AllowanceName { get; set; }
        public decimal? AllowanceAmount { get; set; }
        public decimal? AmountTotal { get; set; }
    }
}
