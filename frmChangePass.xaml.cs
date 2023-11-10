using System;
using System.Windows;
using System.Windows.Controls;
using PRN221_ProjectDemo.DAO;

namespace PRN221_ProjectDemo
{
    public partial class frmChangePass : Window
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                    string employeeId = txacc.Text;
                    string oldPassword = txtOldPass.Text;
                    string newPassword = txtPass.Text;
                    UserDAO userDAO = new UserDAO();
                    bool passwordChanged = userDAO.ChagePass(employeeId, oldPassword, newPassword);
                    if (passwordChanged)
                    {
                        txtNofy.Content = "Password changed successfully.";
                    }
                    else
                    {
                        txtNofy.Content = "Failed to change password.";
                    }
                
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }
    }


    
}
