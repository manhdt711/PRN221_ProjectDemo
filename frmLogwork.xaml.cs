using PRN221_ProjectDemo.DAO;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PRN221_ProjectDemo
{
    public partial class frmLogwork : Window
    {
        private ObservableCollection<WorkHour> workHours = new ObservableCollection<WorkHour>();
        private WorkHourDAO workHourDAO;

        public frmLogwork()
        {
            InitializeComponent();
            workHourDAO = new WorkHourDAO();
            workHourListView.ItemsSource = workHours;
            RefreshWorkHourList();
        }

        private void RefreshWorkHourList()
        {
            workHours.Clear();
            var workHourList = workHourDAO.GetAll();
            foreach (var workHour in workHourList)
            {
                workHours.Add(workHour);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeID = textBoxEmployeeID.Text;
            DateTime workDay = datePickerWorkDay.SelectedDate ?? DateTime.Now;
            DateTime timeStart = timePickerStart.SelectedDate ?? DateTime.Now;
            DateTime timeEnd = timePickerEnd.SelectedDate ?? DateTime.Now;
            double coefficient = double.Parse(textBoxCoefficient.Text);

            WorkHour newWorkHour = new WorkHour
            {
                EmployeeId = employeeID,
                WorkDay = workDay,
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Coefficient = coefficient
            };

            workHourDAO.Add(newWorkHour);
            RefreshWorkHourList();

            textBoxEmployeeID.Clear();
            datePickerWorkDay.SelectedDate = null;
            timePickerStart.SelectedDate = null;
            timePickerEnd.SelectedDate = null;
            textBoxCoefficient.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            WorkHour selectedWorkHour = (WorkHour)workHourListView.SelectedItem;

            if (selectedWorkHour != null)
            {
                selectedWorkHour.EmployeeId = textBoxEmployeeID.Text;
                selectedWorkHour.WorkDay = datePickerWorkDay.SelectedDate ?? DateTime.Now;
                selectedWorkHour.TimeStart = timePickerStart.SelectedDate ?? DateTime.Now;
                selectedWorkHour.TimeEnd = timePickerEnd.SelectedDate ?? DateTime.Now;
                selectedWorkHour.Coefficient = double.Parse(textBoxCoefficient.Text);

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

                textBoxEmployeeID.Clear();
                datePickerWorkDay.SelectedDate = null;
                timePickerStart.SelectedDate = null;
                timePickerEnd.SelectedDate = null;
                textBoxCoefficient.Clear();
            }
        }
    }
}
