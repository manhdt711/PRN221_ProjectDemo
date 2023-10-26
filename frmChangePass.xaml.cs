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
            if (sender is Button button)
            {
                if (button.Name == "Button_Click")
                {
                    // Xử lý sự kiện khi nút "ChangePassword" được nhấn
                    string employeeId = txacc.Text; // Lấy giá trị từ TextBox txacc
                    string oldPassword = txtOldPass.Text; // Lấy giá trị từ TextBox txtOldPass
                    string newPassword = txtPass.Text; // Lấy giá trị từ TextBox txtPass

                    // Gọi hàm xử lý thay đổi mật khẩu ở phần BE
/*                    bool passwordChanged = ChangePassword(employeeId, oldPassword, newPassword);

                    if (passwordChanged)
                    {
                        txtNofy.Content = "Password changed successfully.";
                    }
                    else
                    {
                        txtNofy.Content = "Failed to change password.";
                    }*/
                }
                else if (button.Name == "Back")
                {
                    // Xử lý sự kiện khi nút "Back" được nhấn
                    // Đóng cửa sổ hiện tại hoặc thực hiện hành động khác (tùy theo yêu cầu của bạn).
                    this.Close();
                }
            }
        }

/*        private bool ChangePassword(string employeeId, string oldPassword, string newPassword)
        {
            UserDAO userDAO = new UserDAO();
            string acc = txacc.Text;
            string pass = txtPass.Text;
            var user = userDAO.GetUserById(acc);
            if (user == null)
            {
                notiText.Content = "Wrong Account";
            }
            else if (user.Password != pass)
            {
                notiText.Content = "Wrong Password";
            }
            else if (user.Permission == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (user.Permission == 2)
            {
                frmLogwork logwork = new frmLogwork(user);
                logwork.Show();
                this.Close();
            }
        }*/
    }
}
