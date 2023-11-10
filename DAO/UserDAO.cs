using Microsoft.EntityFrameworkCore;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
        public User GetUserById(string UserId)
        {
            return dbContext.Users.FirstOrDefault(e => e.EmployeeId == UserId);
        }

        public void UpdateUserByAdmin(User user)
        {
            try
            {
                var existingUser = dbContext.Users.FirstOrDefault(u => u.EmployeeId == user.EmployeeId);
                if (existingUser != null)
                {
                    existingUser.Permission = user.Permission;
                    dbContext.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                // Xử lý lỗi DbUpdateException ở đây
                // In thông tin lỗi hoặc ghi vào tệp log
                Debug.WriteLine($"DbUpdateException: {ex.Message}");
                // Để xem thông tin lỗi cụ thể hơn, bạn có thể truy cập Inner Exception.
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }
        public bool ChagePass(string empId, string password, string newPass)
        {
            bool isChanged = false;
            try
            {
                var existing = dbContext.Users.FirstOrDefault(u => u.EmployeeId.Equals(empId) && u.Password.Equals(password));
                if (existing != null)
                {
                    existing.Password = newPass;
                    dbContext.SaveChanges();
                    isChanged = true;
                }
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine($"DbUpdateException: {ex.Message}");
                // Để xem thông tin lỗi cụ thể hơn, bạn có thể truy cập Inner Exception.
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
            return isChanged;
        }
    }
}
