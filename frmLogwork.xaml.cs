using PRN221_ProjectDemo.DAO;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PRN221_ProjectDemo
{
    public partial class frmLogwork : Window
    {
        private WorkHourDAO workHourDAO = new WorkHourDAO();
        private User SavedUser = null;
        public frmLogwork(User user)
        {
            InitializeComponent();
            workHourDAO = new WorkHourDAO();
            var workHours = workHourDAO.GetAllByEmpId(user.EmployeeId);
            workHourListView.ItemsSource = workHours;
            SavedUser = user;
            textBoxEmployeeID.Text = user.EmployeeId;
        }

        private void RefreshWorkHourList()
        {
            workHourDAO = new WorkHourDAO();
            var workHours = workHourDAO.GetAllByEmpId(SavedUser.EmployeeId);
            workHourListView.ItemsSource = workHours;
        }

        private List<DateTime> vietnamHolidays = new List<DateTime>
        {
            new DateTime(DateTime.Now.Year, 1, 1), 
            new DateTime(DateTime.Now.Year, 4, 30),
            new DateTime(DateTime.Now.Year, 5, 1),  
            new DateTime(DateTime.Now.Year, 9, 2),   
        };

        private bool CheckVietnamHoliday(DateTime date)
        {
            foreach (DateTime holiday in vietnamHolidays)
            {
                if (date.Month == holiday.Month && date.Day == holiday.Day)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckWeekend(DateTime date)
        {
            bool isWeekend = false;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                isWeekend = true;
            }
            return isWeekend;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeID = textBoxEmployeeID.Text;
            DateTime workDay = datePickerWorkDay.SelectedDate ?? DateTime.Now;
            int workHour = int.Parse(textBoxWorklog.Text);
            int coefficientByDate = 1;
            if(CheckWeekend(workDay))
            {
                coefficientByDate = 2;
            }
            if(CheckVietnamHoliday(workDay))
            {
                coefficientByDate = 3;
            }    
            WorkHour newWorkHour = new WorkHour
            {
                EmployeeId = employeeID,
                WorkDay = workDay,
                WorkHour1 = workHour,
                Coefficient = coefficientByDate
            };

            workHourDAO.Add(newWorkHour);
            RefreshWorkHourList();

            datePickerWorkDay.SelectedDate = null;
            textBoxWorklog.Text = null;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            workHourDAO = new WorkHourDAO();
            var selectedWorkHour = (WorkHour)workHourListView.SelectedItem;

            if (selectedWorkHour != null)
            {
                selectedWorkHour.WorkHour1 = int.Parse(textBoxWorklog.Text);
                workHourDAO.Update(selectedWorkHour);
                RefreshWorkHourList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WorkHour selectedWorkHour = (WorkHour)workHourListView.SelectedItem;

            if (selectedWorkHour != null)
            {
                workHourDAO.Delete(selectedWorkHour);
                RefreshWorkHourList();

                datePickerWorkDay.SelectedDate = null;
                textBoxWorklog.Text = null;
            }
        }
        private void workHourListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (workHourListView.SelectedItem != null)
            {
                // Lấy đối tượng WorkHour tương ứng với mục được chọn
                WorkHour selectedWorkHour = (WorkHour)workHourListView.SelectedItem;

                // Gán giá trị của các thuộc tính vào TextBox tương ứng
                textBoxEmployeeID.Text = selectedWorkHour.EmployeeId;
                datePickerWorkDay.SelectedDate = selectedWorkHour.WorkDay;
                textBoxWorklog.Text = selectedWorkHour.WorkHour1.ToString();
            }
        }

    }
}
