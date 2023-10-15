using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static PRN221_ProjectDemo.Models.StEmployeeInfo;

namespace PRN221_ProjectDemo.DAO
{
    internal class EmpDAO
    {
        private readonly Prn221ProjectContext dbContext;

        public EmpDAO()
        {
            // Khởi tạo đối tượng DbContext
            dbContext = new Prn221ProjectContext();
        }

        public List<EmployeeInfo> GetEmployeeInfoList()
        {
            var sql = $@"SELECT 
    e.EmployeeID,
    e.FirstName,
    e.LastName,
    d.DepartmentName,
    d.DepartmentDuty,
    e.DateOfBirth,
    e.Title AS Job,
    e.Gender,
    e.PhoneNumber,
    j.SalaryPerHour,
    u.Permission,
    p.Coefficient AS PaymentCoefficient,
	e.BeginDate,
	e.EndDate
FROM Employee AS e
LEFT JOIN Department AS d ON e.DepartmentID = d.DepartmentID
LEFT JOIN JobLevel AS j ON e.JobLevelID = j.JobLevelID
LEFT JOIN [User] AS u ON e.EmployeeID = u.EmployeeID
LEFT JOIN WorkHour AS wh ON e.EmployeeID = wh.EmployeeID
LEFT JOIN Payments AS p ON e.EmployeeID = p.EmployeeID
                                ";

            var employeeInfoList = dbContext.EmployeeInfos.FromSqlRaw(sql).ToList();

            return employeeInfoList;
        }
        public void AddEmp(Employee emp)
        {
            dbContext.Add(emp);
            dbContext.SaveChanges();
        }
        public void UpdateEmp(Employee emp)
        {
            var existing = dbContext.Employees.FirstOrDefault(e => e.EmployeeId == emp.EmployeeId);
            if(existing != null)
            {
                existing = emp;
                dbContext.SaveChanges();
            }    
        }

    }
}