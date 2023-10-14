using System;
using System.Collections.Generic;

namespace PRN221_ProjectDemo.Models;

public partial class Employee
{
    public string EmployeeId { get; set; }

    public string DepartmentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Title { get; set; }

    public string Gender { get; set; }

    public string PhoneNumber { get; set; }

    public int? JobLevelId { get; set; }

    public DateTime? BeginDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Department Department { get; set; }

    public virtual User EmployeeNavigation { get; set; }

    public virtual JobLevel JobLevel { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<WorkHour> WorkHours { get; set; } = new List<WorkHour>();
}
