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
    /// Interaction logic for EditAllowenece.xaml
    /// </summary>
    public partial class EditAllowenece : Window
    {
        private AllowanceDAO allowanceDAO;
        public EditAllowenece()
        {
            InitializeComponent();
            allowanceDAO = new AllowanceDAO();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            List<Allowance> allowances = allowanceDAO.GetAllAllowances();
            dataGrid.ItemsSource = allowances;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                Allowance newAllowance = new Allowance
                {
                    AllowanceName = txtName.Text,
                    AllowanceAmount = amount
                };
                if (allowanceDAO.AddAllowance(newAllowance))
                {
                    RefreshDataGrid();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Failed to add allowance.");
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Allowance selectedAllowance && decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                selectedAllowance.AllowanceName = txtName.Text;
                selectedAllowance.AllowanceAmount = amount;
                if (allowanceDAO.UpdateAllowance(selectedAllowance))
                {
                    RefreshDataGrid();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Failed to update allowance.");
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Allowance selectedAllowance)
            {
                if (allowanceDAO.DeleteAllowance(selectedAllowance.AllowanceId))
                {
                    RefreshDataGrid();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete allowance.");
                }
            }
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtAmount.Clear();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            frmSkill skill = new frmSkill();
            skill.Show();
            this.Close();
        }
    }
}

