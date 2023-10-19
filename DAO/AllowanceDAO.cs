using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PRN221_ProjectDemo.DAO
{
    internal class AllowanceDAO
    {
        private readonly Prn221ProjectContext dbContext;
        private const string logFilePath = "debug.log"; // Đường dẫn tới tệp tin log

        public AllowanceDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        private void LogError(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(DateTime.Now + " - " + message);
            }
        }

        public List<Allowance> GetAllAllowances()
        {
            return dbContext.Allowances.ToList();
        }

        public bool AddAllowance(Allowance allowance)
        {
            try
            {
                dbContext.Allowances.Add(allowance);
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while adding Allowance: " + ex.Message);
                return false;
            }
        }

        public bool UpdateAllowance(Allowance allowance)
        {
            try
            {
                var existingAllowance = dbContext.Allowances.Find(allowance.AllowanceId);
                if (existingAllowance != null)
                {
                    dbContext.Entry(existingAllowance).CurrentValues.SetValues(allowance);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while updating Allowance: " + ex.Message);
                return false;
            }
        }

        public bool DeleteAllowance(int allowanceId)
        {
            try
            {
                var allowance = dbContext.Allowances.Find(allowanceId);
                if (allowance != null)
                {
                    dbContext.Allowances.Remove(allowance);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateException ex)
            {
                LogError("Error while deleting Allowance: " + ex.Message);
                return false;
            }
        }
    }
}
