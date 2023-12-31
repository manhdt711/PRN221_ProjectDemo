﻿using PRN221_ProjectDemo.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221_ProjectDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesManager employeesManager = new EmployeesManager();
            employeesManager.Show();
            this.Close();
        }

        private void SalaryReportButton_Click(object sender, RoutedEventArgs e)
        {
            frmDepartment department = new frmDepartment();
            department.Show();
            this.Close();
        }

        private void ManageSkillsAndAllowancesButton_Click(object sender, RoutedEventArgs e)
        {
            frmSkill skill = new frmSkill();
            skill.Show();
            this.Close();
        }

        private void CalculateSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            StPaymentDAO stPaymentDAO = new StPaymentDAO();
            StPaymentDAO stPayment = new StPaymentDAO();
            var stPaymentList = stPaymentDAO.GetEmployeePayments();
            if (stPaymentDAO.CaculatorTotalhourByEmpId(stPaymentList) && stPayment.CaculatorPayment(stPaymentList))
            {
                frmCaculateSalary frmCaculateSalary = new frmCaculateSalary();
                frmCaculateSalary.Show();
                this.Close();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            frmLogin frmLogi = new frmLogin();
            frmLogi.Show();
            this.Close();
        }
    }
}
