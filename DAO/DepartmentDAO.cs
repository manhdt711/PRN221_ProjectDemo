using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_ProjectDemo.DAO
{
    internal class DepartmentDAO
    {
        private readonly Prn221ProjectContext dbContext;
        public DepartmentDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

        public List<Department> GetAll()
        {
            var departments = dbContext.Departments.ToList();
            return departments;
        }

        public Department FindDepartmentByName(string name)
        {
            var department = dbContext.Departments.FirstOrDefault(d => d.DepartmentName == name);
            return department;
        }

        public void Add(Department department)
        {
            try
            {
                dbContext.Departments.Add(department);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }

        public void Update(Department department)
        {
            try
            {
                dbContext.Entry(department).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }

        public void Delete(Department department)
        {
            try
            {
                dbContext.Departments.Remove(department);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Debug.WriteLine(dbEx.Message);
            }
        }
    }
}
