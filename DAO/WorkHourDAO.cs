using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PRN221_ProjectDemo.DAO
{
    internal class WorkHourDAO
    {
        private readonly Prn221ProjectContext dbContext;

        public WorkHourDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        public List<WorkHour> GetAll()
        {
            var workHours = dbContext.WorkHours.ToList();
            return workHours;
        }

        public List<WorkHour> GetAllByEmpId(string EmpId)
        {
            var workHours = dbContext.WorkHours.Where(w => w.EmployeeId == EmpId).ToList();
            return workHours;
        }
        public WorkHour getWorkbySelectedDate(DateTime date)
        {
            return dbContext.WorkHours.FirstOrDefault(w => w.WorkDay == date);
        }
        public void Add(WorkHour workHour)
        {
            try
            {
                dbContext.WorkHours.Add(workHour);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }

        public void Update(WorkHour workHour)
        {
            try
            {
                dbContext.Entry(workHour).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }

        public void Delete(WorkHour workHour)
        {
            try
            {
                dbContext.WorkHours.Remove(workHour);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }
    }
}
