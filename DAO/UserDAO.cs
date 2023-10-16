﻿using Microsoft.EntityFrameworkCore;
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
        public void CreateUser(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Xử lý lỗi DbUpdateException ở đây
                // In thông tin lỗi hoặc ghi vào tệp log
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                // Để xem thông tin lỗi cụ thể hơn, bạn có thể truy cập Inner Exception.
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            
        }    

        public void UpdateUserByAdmin(User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(u => u.EmployeeId == user.EmployeeId);
            if(existingUser != null)
            {
                existingUser.Permission = user.Permission;
                dbContext.SaveChanges();
            }    
        }
    }
}
