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

namespace PRN221_ProjectDemo
{
    /// <summary>
    /// Interaction logic for frmSkill.xaml
    /// </summary>
    public partial class frmSkill : Window
    {
        public frmSkill()
        {
            InitializeComponent();
            RefreshList();
        }
        private void RefreshList()
        {
            JobLevelDAO jobLevel = new JobLevelDAO();
            lstViewLevel.ItemsSource = jobLevel.GetAllJobLevels();
            AllowanceDAO allowance = new AllowanceDAO();
            lstViewAllowence.ItemsSource = allowance.GetAllAllowances();
            txtSalary.Clear();
            txtAllowance.Clear();
        }

        private int GenerateNewJobLevelID()
        {
            using (var _context = new Prn221ProjectContext())
            {
                // Sử dụng LINQ để truy vấn số emp lớn nhất
                int maxEmpId = _context.JobLevels
                    .Select(e => e.JobLevelId)
                    .Max();

                if (maxEmpId != null)
                {
                    // Nếu có số emp trong cơ sở dữ liệu, bạn có thể tạo một số emp mới dựa trên số emp lớn nhất đã có.
                    int maxEmpNumber = maxEmpId;
                    int newId = maxEmpNumber + 1;
                    return newId;
                }
                else
                {
                    // Nếu không có số emp trong cơ sở dữ liệu, bạn có thể tạo số emp đầu tiên.
                    return 99999;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JobLevel newJobLevel = (JobLevel)lstViewLevel.SelectedItem;
            if(newJobLevel != null)
            {
                newJobLevel.AllowanceId = int.Parse(txtAllowance.Text);
                newJobLevel.SalaryPerHour = decimal.Parse(txtSalary.Text);
                JobLevelDAO jobLevelDAO = new JobLevelDAO();
                jobLevelDAO.UpdateJobLevel(newJobLevel);
            }    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            JobLevel jobLevel = new JobLevel
            {
                JobLevelId = GenerateNewJobLevelID(),
                SalaryPerHour = decimal.Parse(txtSalary.Text),
                AllowanceId = int.Parse(txtAllowance.Text)
            };
            JobLevelDAO jobLevelDAO = new JobLevelDAO();
            jobLevelDAO.AddJobLevel(jobLevel);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
