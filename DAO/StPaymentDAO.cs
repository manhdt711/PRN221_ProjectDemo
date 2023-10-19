using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PRN221_ProjectDemo.DAO
{
    internal class StPaymentDAO
    {
        private readonly Prn221ProjectContext dbContext;

        public StPaymentDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        public List<StPayment> GetEmployeePayments()
        {
            var query = from p in dbContext.Payments
                        join e in dbContext.Employees on p.EmployeeId equals e.EmployeeId
                        join jl in dbContext.JobLevels on e.JobLevelId equals jl.JobLevelId
                        join d in dbContext.Departments on e.DepartmentId equals d.DepartmentId
                        join a in dbContext.Allowances on jl.AllowanceId equals a.AllowanceId
                        select new StPayment
                        {
                            EMPID = p.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            TotalHours = p.TotalHours,
                            LevelId = e.JobLevelId,
                            SalaryPerHour = jl.SalaryPerHour,
                            DepartmentName = d.DepartmentName,
                            PhoneNumber = e.PhoneNumber,
                            AllowanceName = a.AllowanceName,
                            AllowanceAmount = a.AllowanceAmount,
                            AmountTotal = p.TotalPayments
                        };

            return query.ToList();
        }
        public void CaculatorTotalhourByEmpId(List<StPayment> empId)
        {
            WorkHourDAO hourDAO = new WorkHourDAO();
            PaymentDAO paymentDAO = new PaymentDAO();

            foreach (StPayment stPayment in empId)
            {
                int totalHours = 0;

                var workHours = hourDAO.GetAllByEmpId(stPayment.EMPID);

                foreach (WorkHour work in workHours)
                {
                    if (work.WorkHour1.HasValue)
                    {
                        totalHours += (int)work.WorkHour1;
                    }
                }

                var newPayment = paymentDAO.GetPaymentByEmpId(stPayment.EMPID);

                newPayment.TotalHours = totalHours;
                paymentDAO.Update(newPayment);

            }
        }


        public void CaculatorPayment(List<StPayment> empId)
        {

            PaymentDAO paymentDAO = new PaymentDAO();
            EmpDAO empDAO = new EmpDAO();
            JobLevelDAO jobLevelDAO = new JobLevelDAO();
            AllowanceDAO allowanceDAO = new AllowanceDAO();

            foreach (StPayment stPayment in empId)
            {
                decimal total = 0;
                var payment = paymentDAO.GetPaymentByEmpId(stPayment.EMPID);
                var emp = empDAO.GetEmpById(stPayment.EMPID);

                if (payment != null && emp != null)
                {
                    var level = jobLevelDAO.FindSalaryByJoblevel(emp.JobLevelId);
                    var allowance = allowanceDAO.GetAllowancesById(level.AllowanceId);



                    if (payment.TotalHours.HasValue && level.SalaryPerHour.HasValue && allowance.AllowanceAmount.HasValue)
                    {
                        total = (decimal)payment.TotalHours * (decimal)level.SalaryPerHour + (decimal)allowance.AllowanceAmount;
                    }

                    var newPayment = paymentDAO.GetPaymentByEmpId(stPayment.EMPID);
                    newPayment.TotalPayments = total;
                    paymentDAO.Update(newPayment);
                }
            }
        }

    }
}
