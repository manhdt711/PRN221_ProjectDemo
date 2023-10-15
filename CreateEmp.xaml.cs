using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static PRN221_ProjectDemo.Models.StEmployeeInfo;

namespace PRN221_ProjectDemo
{
    /// <summary>
    /// Interaction logic for CreateEmp.xaml
    /// </summary>
    public partial class CreateEmp : Window
    {
        private Prn221ProjectContext _context;
        private bool IsCreate = false;
        public CreateEmp(EmployeeInfo? employeeInfo)
        {
            InitializeComponent();

            if (employeeInfo != null)
            {
                bool IsCreate = false;
                FirstNameTextBox.Text = employeeInfo.FirstName;
                LastNameTextBox.Text = employeeInfo.LastName;
                DepartmentComboBox.Text = employeeInfo.DepartmentName;
                DepartmentDutyTextBox.Text = employeeInfo.DepartmentDuty;
                DateOfBirthDatePicker.SelectedDate = employeeInfo.DateOfBirth;
                JobTextBox.Text = employeeInfo.Job;
                GenderComboBox.Text = employeeInfo.Gender;
                PhoneNumberTextBox.Text = employeeInfo.PhoneNumber;
                SalaryPerHourTextBox.Text = employeeInfo.SalaryPerHour.ToString();
                PermissionTextBox.Text = employeeInfo.Permission.ToString();
                PaymentCoefficientTextBox.Text = employeeInfo.PaymentCoefficient.ToString();
                BeginDateDatePicker.SelectedDate = employeeInfo.BeginDate;
                EndDateDatePicker.SelectedDate = employeeInfo.EndDate;
                Action.Content = "Edit";
            }
            IsCreate = true;
        }
        private string InsertEmpId()
        {
            string newString = "";
            int countEmp = _context.Employees.Count();
            string input = "EMP" + countEmp.ToString("D3");

            if (int.TryParse(input.Substring(3), out int number))
            {
                number++; // Tăng giá trị số lên 1

                newString = "EMP" + number.ToString("D3");
                Console.WriteLine(newString);
            }
            else
            {
                Debug.WriteLine("Không thể tìm thấy số trong chuỗi.");
            }
            return newString;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsCreate)
            {
                try
                {
                    Employee newEmp = new Employee
                    {
                        EmployeeId = InsertEmpId(),
                        DepartmentId = "",
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        DateOfBirth = DateOfBirthDatePicker.SelectedDate,
                        Title = "",
                        Gender = "",
                        PhoneNumber = PhoneNumberTextBox.Text,
                        JobLevelId = 2,
                        BeginDate = BeginDateDatePicker.SelectedDate,
                        EndDate = EndDateDatePicker.SelectedDate
                    };

                    // Thêm newEmp vào cơ sở dữ liệu (nếu cần)
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi ở đây
                }
            }
        }


    }

}
