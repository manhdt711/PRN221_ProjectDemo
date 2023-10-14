using PRN221_ProjectDemo.DAO;
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

namespace PRN221_ProjectDemo
{
    /// <summary>
    /// Interaction logic for EmployeesManager.xaml
    /// </summary>
    public partial class EmployeesManager : Window
    {
        private EmpDAO empDAO;

        public EmployeesManager()
        {
            InitializeComponent();
            empDAO = new EmpDAO(); // Khởi tạo đối tượng EmpDAO
            var employeeInfoList = empDAO.GetEmployeeInfoList();

            // Gán danh sách EmployeeInfo cho ListView
            lstEmp.ItemsSource = employeeInfoList;
        }
    }
}
