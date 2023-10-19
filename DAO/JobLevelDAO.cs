using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;

namespace PRN221_ProjectDemo.DAO
{
    internal class JobLevelDAO
    {
        private readonly Prn221ProjectContext dbContext;
        private const string logFilePath = "debug.log"; // Đường dẫn tới tệp tin log

        public JobLevelDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        public JobLevel FindJobLevelBySalary(decimal salary)
        {
            return dbContext.JobLevels.FirstOrDefault(d => d.SalaryPerHour == salary);
        }

        public JobLevel FindSalaryByJoblevel(int? level)
        {
            return dbContext.JobLevels.FirstOrDefault(d => d.JobLevelId == level);
        }
        public List<JobLevel> GetAllJobLevels()
        {
            return dbContext.JobLevels.ToList();
        }


        private void LogError(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(DateTime.Now + " - " + message);
            }
        }

        // Phương thức để thêm một cấp độ công việc mới
        public bool AddJobLevel(JobLevel jobLevel)
        {
            try
            {
                dbContext.JobLevels.Add(jobLevel);
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while adding JobLevel: " + ex.Message);
                return false;
            }
        }

        // Phương thức để cập nhật thông tin của cấp độ công việc
        public bool UpdateJobLevel(JobLevel jobLevel)
        {
            try
            {
                var existingJobLevel = dbContext.JobLevels.Find(jobLevel.JobLevelId);
                if (existingJobLevel != null)
                {
                    dbContext.Entry(existingJobLevel).CurrentValues.SetValues(jobLevel);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while updating JobLevel: " + ex.Message);
                return false;
            }
        }

        // Phương thức để xóa một cấp độ công việc
        public bool DeleteJobLevel(int jobLevelId)
        {
            try
            {
                var jobLevel = dbContext.JobLevels.Find(jobLevelId);
                if (jobLevel != null)
                {
                    dbContext.JobLevels.Remove(jobLevel);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while deleting JobLevel: " + ex.Message);
                return false;
            }
        }

    }
}
