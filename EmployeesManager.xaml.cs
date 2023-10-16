using PRN221_ProjectDemo.DAO;
using PRN221_ProjectDemo.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EmployeesManager.xaml
    /// </summary>
    public partial class EmployeesManager : Window
    {
        private EmpDAO empDAO;
        private DepartmentDAO departmentDAO;
        private List<Department> lstDepartment;
        public EmployeesManager()
        {
            departmentDAO = new DepartmentDAO();
            InitializeComponent();
            empDAO = new EmpDAO();

            var employeeInfoList = empDAO.GetEmployeeInfoList();
            var departmentsList = departmentDAO.GetAll();

            // Set the DataContext of the ComboBox to the list of departments
            coDepartment.ItemsSource = departmentsList;

            // Set the DisplayMemberPath and SelectedValuePath properties
            coDepartment.DisplayMemberPath = "DepartmentName";
            coDepartment.SelectedValuePath = "DepartmentName";

            // Gán danh sách EmployeeInfo cho ListView
            lstEmp.ItemsSource = employeeInfoList;

        }
        private void lstEmp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            EmployeeInfo selectedEmp = (EmployeeInfo)lstEmp.SelectedItem;

            if (selectedEmp != null)
            {
                try
                {
                    CreateEmp createEmpPopup = new CreateEmp(selectedEmp);
                    createEmpPopup.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateEmp createEmpPopup = new CreateEmp(null);
            createEmpPopup.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
