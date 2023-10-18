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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmChangePass changePass = new frmChangePass();
            changePass.Show();
            this.Close();

        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            string acc = txtAcc.Text;
            string pass = txtPass.Text;
            var user = userDAO.GetUserById(acc);
            if (user == null)
            {
                notiText.Content = "Wrong Account";
            }
            else if(user.Password != pass)
            {
                notiText.Content = "Wrong Password";
            }else if(user.Permission == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }else if(user.Permission == 2)
            {
                frmLogwork logwork = new frmLogwork(user);
                logwork.Show();
                this.Close();
            }
        }
    }
}
