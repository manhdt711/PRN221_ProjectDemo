using PRN221_ProjectDemo.DAO;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static PRN221_ProjectDemo.Models.StEmployeeInfo;

namespace PRN221_ProjectDemo
{
    public partial class CreateEmp : Window
    {
        private Prn221ProjectContext _context;
        private DepartmentDAO departmentDAO;
        private EmpDAO empDAO;
        private PaymentDAO paymentDAO;
        private UserDAO userDAO;
        private JobLevelDAO jobLevelDAO;
        private string Var_SavedId = null;
        private bool IsCreate = false;

        public CreateEmp(EmployeeInfo? employeeInfo)
        {
            jobLevelDAO = new JobLevelDAO();
            departmentDAO = new DepartmentDAO();
            InitializeComponent();
            InitializeComboBoxes();

            if (employeeInfo != null)
            {
                Var_SavedId = employeeInfo.EmployeeId;
                IsCreate = false;
                PopulateFields(employeeInfo);
            }
            else
            {
                IsCreate = true;
            }
        }

        private void InitializeComboBoxes()
        {
            var departmentsList = departmentDAO.GetAll();
            DepartmentComboBox.ItemsSource = departmentsList;
            DepartmentComboBox.DisplayMemberPath = "DepartmentName";
            DepartmentComboBox.SelectedValuePath = "DepartmentName";

            SalaryPerHourTextBox.ItemsSource = jobLevelDAO.GetAllJobLevels();
            SalaryPerHourTextBox.DisplayMemberPath = "SalaryPerHour";
            SalaryPerHourTextBox.SelectedValuePath = "SalaryPerHour";

            GenderComboBox.ItemsSource = new List<string> { "Male", "Female" };
        }

        private void PopulateFields(EmployeeInfo employeeInfo)
        {
            FirstNameTextBox.Text = employeeInfo.FirstName;
            LastNameTextBox.Text = employeeInfo.LastName;
            DepartmentComboBox.SelectedValue = employeeInfo.DepartmentName;
            DateOfBirthDatePicker.SelectedDate = employeeInfo.DateOfBirth;
            JobTextBox.Text = employeeInfo.Job;
            GenderComboBox.Text = employeeInfo.Gender;
            PhoneNumberTextBox.Text = employeeInfo.PhoneNumber;
            SalaryPerHourTextBox.Text = employeeInfo.SalaryPerHour.ToString();
            PermissionTextBox.Text = employeeInfo.Permission.ToString();
            BeginDateDatePicker.SelectedDate = employeeInfo.BeginDate;
            EndDateDatePicker.SelectedDate = employeeInfo.EndDate;
            Action.Content = "Edit";
        }

        private string GenerateNewEmployeeId()
        {
            using (var _context = new Prn221ProjectContext())
            {
                // Sử dụng LINQ để truy vấn số emp lớn nhất
                var maxEmpId = _context.Employees
                    .Select(e => e.EmployeeId)
                    .Max();

                if (!string.IsNullOrEmpty(maxEmpId))
                {
                    // Nếu có số emp trong cơ sở dữ liệu, bạn có thể tạo một số emp mới dựa trên số emp lớn nhất đã có.
                    int maxEmpNumber = int.Parse(maxEmpId.Substring(3));
                    string newId = "EMP" + (maxEmpNumber + 1).ToString("D3");
                    return newId;
                }
                else
                {
                    // Nếu không có số emp trong cơ sở dữ liệu, bạn có thể tạo số emp đầu tiên.
                    return "EMP001";
                }
            }
        }


        private void CreateEmployee()
        {
            departmentDAO = new DepartmentDAO();
            string newEmpId = GenerateNewEmployeeId();

            empDAO = new EmpDAO();
            paymentDAO = new PaymentDAO();
            userDAO = new UserDAO();

            Employee newEmp = new Employee
            {
                EmployeeId = newEmpId,
                /*DepartmentId = departmentDAO.FindDepartmentByName((string)DepartmentComboBox.SelectedValue).DepartmentId*/
                DepartmentId = departmentDAO.FindDepartmentByName((string)DepartmentComboBox.SelectedValue).DepartmentId,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DateOfBirth = DateOfBirthDatePicker.SelectedDate,
                Title = JobTextBox.Text,
               Gender = (string)GenderComboBox.SelectedValue,

                PhoneNumber = PhoneNumberTextBox.Text,
                JobLevelId = jobLevelDAO.FindJobLevelBySalary(decimal.Parse(SalaryPerHourTextBox.Text)).JobLevelId,
                BeginDate = BeginDateDatePicker.SelectedDate,
                EndDate = EndDateDatePicker.SelectedDate
            };

            Payment newPayment = new Payment
            {
                EmployeeId = newEmpId,
                SalaryPeriod = (DateTime)BeginDateDatePicker.SelectedDate,
                Coefficient = 1,
            };

            User newUser = new User
            {
                EmployeeId = newEmpId,
                Password = "1",
                Permission = 1,
            };

            userDAO.CreateUser(newUser);
            empDAO.AddEmp(newEmp);
            paymentDAO.CreateNewPayment(newPayment);

            MessageBox.Show("Tạo thành công");
        }

        private void UpdateEmployee()
        {
            empDAO = new EmpDAO();
            departmentDAO = new DepartmentDAO();
            jobLevelDAO = new JobLevelDAO();

            if (empDAO.GetEmpById(Var_SavedId) != null && DepartmentComboBox.SelectedValue != null && SalaryPerHourTextBox.Text != null)
            {
                Employee updatedEmp = new Employee
                {
                    EmployeeId = Var_SavedId,
                    DepartmentId = departmentDAO.FindDepartmentByName((string)DepartmentComboBox.SelectedValue)?.DepartmentId,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    DateOfBirth = DateOfBirthDatePicker.SelectedDate,
                    Title = JobTextBox.Text,
                    Gender = (string)GenderComboBox.SelectedValue,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    JobLevelId = jobLevelDAO.FindJobLevelBySalary(decimal.Parse(SalaryPerHourTextBox.Text))?.JobLevelId,
                    BeginDate = BeginDateDatePicker.SelectedDate,
                    EndDate = EndDateDatePicker.SelectedDate,
                };

                Payment updatedPayment = new Payment
                {
                    EmployeeId = Var_SavedId,
                    SalaryPeriod = (DateTime)BeginDateDatePicker.SelectedDate,
                    Coefficient = 1,
                };

                User newUser = new User
                {
                    EmployeeId = Var_SavedId,
                    Permission = int.Parse(PermissionTextBox.Text),
                };

                paymentDAO = new PaymentDAO();
                userDAO = new UserDAO();

                userDAO.UpdateUserByAdmin(newUser);
                empDAO.UpdateEmp(updatedEmp);
                paymentDAO.updatePaymentByAdmin(updatedPayment);

                MessageBox.Show("Cập nhật thành công");
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsCreate)
                {
                    CreateEmployee();
                }
                else
                {
                    UpdateEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EmployeesManager employeesManager = new EmployeesManager();
            employeesManager.Show();
            this.Close();
        }
    }
}
