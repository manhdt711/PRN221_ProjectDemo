using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
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
            var department = dbContext.Departments.ToList();
            return department;
        }
    }
}
