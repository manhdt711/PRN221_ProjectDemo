using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_ProjectDemo.DAO
{
    internal class JobLevelDAO
    {
        private readonly Prn221ProjectContext dbContext;

        public JobLevelDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        public JobLevel FindJobLevelBySalary(decimal Salary)
        {
            return dbContext.JobLevels.FirstOrDefault(d => d.SalaryPerHour == Salary);
        }
        public List<JobLevel> GetAllJobLevel()
        {
            return dbContext.JobLevels.ToList();
        }
    }
}
