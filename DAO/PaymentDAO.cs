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
    internal class PaymentDAO
    {
        private readonly Prn221ProjectContext dbContext;
        public PaymentDAO()
        {
            dbContext = new Prn221ProjectContext();
        }
        public void CreateNewPayment(Payment payment)
        {
            try
            {
                dbContext.Payments.Add(payment);
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

        public void updatePaymentByAdmin(Payment payment)
        {
            try
            {

                var exitxstingPayment = dbContext.Payments.FirstOrDefault(p => p.EmployeeId == payment.EmployeeId);
                if (exitxstingPayment != null)
                {
                    exitxstingPayment.Coefficient = payment.Coefficient;
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
        public void Update(Payment payment)
        {
            try
            {
                // Tìm bản ghi trong cơ sở dữ liệu dựa trên EmployeeID
                var existingPayment = dbContext.Payments.FirstOrDefault(p => p.EmployeeId == payment.EmployeeId);

                if (existingPayment != null)
                {
                    // Cập nhật giá trị cho các cột
                    existingPayment.SalaryPeriod = payment.SalaryPeriod;
                    existingPayment.TotalHours = payment.TotalHours;
                    existingPayment.Coefficient = payment.Coefficient;
                    existingPayment.AmountTotal = (decimal)(payment.TotalHours * payment.Coefficient);
                    existingPayment.OtherPayment = payment.OtherPayment;
                    existingPayment.TotalPayments = existingPayment.AmountTotal + payment.OtherPayment;
                    dbContext.Payments.Update(existingPayment);
                    // Lưu thay đổi vào cơ sở dữ liệu
                    dbContext.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                // Xử lý ngoại lệ liên quan đến cơ sở dữ liệu (ví dụ: duplicate key)
                // Có thể ghi log hoặc thực hiện các hành động khác tùy theo nhu cầu
                Debug.WriteLine("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác (nếu có)
                Debug.WriteLine("Lỗi: " + ex.Message);
            }
        }
        public Payment GetPaymentByEmpId(string empID)
        {
            return dbContext.Payments.FirstOrDefault(p => p.EmployeeId == empID);
        }
    }
}
