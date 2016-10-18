using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    string employeeType = txtEmployeeType.Text;
                    decimal hoursWorked = Convert.ToDecimal(txtHoursWorked.Text);
                    decimal salesRevenue = Convert.ToDecimal(txtSalesRevenue.Text);

                    decimal commission = 0;
                    decimal totalPay = 0;
                    decimal commissionForSalaried = .02m;
                    decimal commissionForHourly = .01m;

                    if (employeeType == "S")
                    {
                        commission = (salesRevenue * commissionForSalaried);
                        totalPay = commission + 300;
                    }
                    else if (employeeType == "C")
                    {
                        commission = (salesRevenue * commissionForHourly);
                        totalPay = commission + (hoursWorked * 12);
                    }
                    else if (employeeType == "N")
                    {
                        commission = 0;
                        totalPay = commission + (hoursWorked * 16);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a correct Employee Type \n\n" + 
                            "S = Salaried \n C = Hourly Commissioned \n N = Houlry Non-Commision",
                            "Entry Error");
                        txtEmployeeType.Focus();
                    }


                    txtEmployeeType.Text = employeeType.ToString();
                    txtHoursWorked.Text = hoursWorked.ToString();
                    txtSalesRevenue.Text = salesRevenue.ToString();
                    txtSalesCommission.Text = commission.ToString("c");
                    txtTotalPay.Text = totalPay.ToString("c");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");

            }
        }

        public bool IsValidData()
        {
            return
                IsPresent(txtEmployeeType, "Employee Type") &&
                
                IsPresent(txtHoursWorked, "Hours Worked") &&
                IsDecimal(txtHoursWorked, "Hours Worked") &&
                IsWithinRange(txtHoursWorked, "Hours Worked", 0, 80) &&

                IsPresent(txtSalesRevenue, "Sales Revenue") &&
                IsDecimal(txtSalesRevenue, "Sales Revenue") &&
                IsWithinRange(txtSalesRevenue, "Sales Revenue", 0, 900000);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be netween " + min + " and " + max + " .", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
