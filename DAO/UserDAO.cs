using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN221_ProjectDemo.DAO
{
    internal class UserDAO
    {
        private readonly Prn221ProjectContext dbContext;
        public UserDAO()
        {
            dbContext = new Prn221ProjectContext();
        }

    }
}
