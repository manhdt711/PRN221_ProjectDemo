using PRN221_ProjectDemo.DAO;
using PRN221_ProjectDemo.Models;
using System.Windows;
using System.Windows.Controls;

namespace PRN221_ProjectDemo
{
    public partial class frmDepartment : Window
    {
        private DepartmentDAO departmentDAO;

        public frmDepartment()
        {
            InitializeComponent();
            departmentDAO = new DepartmentDAO();
            RefreshDepartmentList();
        }

        private void RefreshDepartmentList()
        {
            DepartmentDAO department = new DepartmentDAO();
            departmentListView.ItemsSource = department.GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string departmentID = textBoxDepartmentID.Text;
            string departmentName = textBoxDepartmentName.Text;
            string departmentDuty = textBoxDepartmentDuty.Text;
            string status = textBoxStatus.Text;

            Department newDepartment = new Department
            {
                DepartmentId = departmentID,
                DepartmentName = departmentName,
                DepartmentDuty = departmentDuty,
                Status = status
            };
            DepartmentDAO department = new DepartmentDAO();
            department.Add(newDepartment);
            RefreshDepartmentList();

            textBoxDepartmentID.Clear();
            textBoxDepartmentName.Clear();
            textBoxDepartmentDuty.Clear();
            textBoxStatus.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDepartment = (Department)departmentListView.SelectedItem;

            if (selectedDepartment != null)
            {
                selectedDepartment.DepartmentId = textBoxDepartmentID.Text;
                selectedDepartment.DepartmentName = textBoxDepartmentName.Text;
                selectedDepartment.DepartmentDuty = textBoxDepartmentDuty.Text;
                selectedDepartment.Status = textBoxStatus.Text;
                DepartmentDAO department = new DepartmentDAO();
                department.Update(selectedDepartment);
                RefreshDepartmentList();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDepartment = (Department)departmentListView.SelectedItem;

            if (selectedDepartment != null)
            {
                DepartmentDAO department = new DepartmentDAO();
                department.Delete(selectedDepartment);
                RefreshDepartmentList();

                textBoxDepartmentID.Clear();
                textBoxDepartmentName.Clear();
                textBoxDepartmentDuty.Clear();
                textBoxStatus.Clear();
            }
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (departmentListView.SelectedItem != null)
            {
                Department selectedDepartment = (Department)departmentListView.SelectedItem;

                textBoxDepartmentID.Text = selectedDepartment.DepartmentId;
                textBoxDepartmentName.Text = selectedDepartment.DepartmentName;
                textBoxDepartmentDuty.Text = selectedDepartment.DepartmentDuty;
                textBoxStatus.Text = selectedDepartment.Status;
            }
        }

    }
}
