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
    /// Interaction logic for frmCaculateSalary.xaml
    /// </summary>
    public partial class frmCaculateSalary : Window
    {
        public frmCaculateSalary()
        {
            InitializeComponent();
            StPaymentDAO stPaymentDAO = new StPaymentDAO();
            var stPaymentList = stPaymentDAO.GetEmployeePayments();

            stPaymentDAO.CaculatorTotalhourByEmpId(stPaymentList);
            stPaymentDAO.CaculatorPayment(stPaymentList);

            lstSalary.ItemsSource = stPaymentList;
        }

        void Caculator()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StPaymentDAO stPaymentDAO = new StPaymentDAO();
            var stPaymentList = stPaymentDAO.GetEmployeePayments();
            stPaymentDAO.CaculatorTotalhourByEmpId(stPaymentList);
            stPaymentDAO.CaculatorPayment(stPaymentList);

            lstSalary.ItemsSource = stPaymentList;
        }
    }
}
