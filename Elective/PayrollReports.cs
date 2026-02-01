using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elective
{
    public partial class PayrollReports : Form
    {
        payrol_dbconnection payrol_db_connect = new payrol_dbconnection();
        public PayrollReports()
        {
            // establish database connection upon opening of the payroll report form
            payrol_db_connect.payrol_connString();
            InitializeComponent();
        }

        private void payrol_select()
        {
            // codes for selecting payroll records from the database and displaying them in the data grid view
            payrol_db_connect.payrol_cmd();
            payrol_db_connect.payrol_sqladapterSelect();
            payrol_db_connect.payrol_sqldatasetSELECT();
            dataGridView1.DataSource = payrol_db_connect.payrol_sql_dataset.Tables[0];
        }

        private void cleartextboxes()
        {
            // codes for clearing the combo box and text box inputs
            optionCombo.Text = "";
            optionInputTxtbox.Clear();
            optionCombo.Focus();
        }

        private void cleartextboxes1()
        {
            // codes for clearing only the text box input
            optionInputTxtbox.Clear();
            optionInputTxtbox.Focus();
        }
        private void PayrollReports_Load(object sender, EventArgs e)
        {
            // codes for loading all payroll records upon opening of the payroll report form
            try
            {
                payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, basic_income_per_cutoff, " +
                    "honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, other_no_of_hrs_cutoff, other_income_per_cutoff, " +
                    "sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, " +
                    "total_deductions, gross_income, net_income, pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id";
                payrol_select();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            // codes for searching payroll records based on selected option from the combo box and input from the text box
            try
            {
                if (optionCombo.Text == "employee_number")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.emp_id = '" + optionInputTxtbox.Text + "'";
                    payrol_select();
                    cleartextboxes1();
                }
                else if (optionCombo.Text == "surname")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.emp_surname = '" + optionInputTxtbox.Text + "'";
                    payrol_select();
                    cleartextboxes1();
                }
                else if (optionCombo.Text == "firstname")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.emp_fname = '" + optionInputTxtbox.Text + "'";
                    payrol_select();
                    cleartextboxes1();
                }
                else if (optionCombo.Text == "gross_income")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.gross_income = '" + optionInputTxtbox.Text + "'";
                    payrol_select();
                    cleartextboxes1();
                }
                else if (optionCombo.Text == "net_income")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.net_income = '" + optionInputTxtbox.Text + "'";
                    payrol_select();
                    cleartextboxes1();
                }
                else if (optionCombo.Text == "pay_date")
                {
                    payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                        "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                        "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                        "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                        "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE pos_empRegTbl.pay_date = '\" + optionInputTxtbox.Text + \"'\"";
                    payrol_select();
                    cleartextboxes1();

                }
                else
                {
                    MessageBox.Show("No Available Record Found!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void BACK_Click(object sender, EventArgs e)
        {
            // codes for going back to the payroll management form from the payroll report form
            try
            {
                payrol_db_connect.payrol_sql = "SELECT emp_fname, emp_mname, emp_surname, basic_rate_hr, basic_no_of_hrs_cutoff, " +
                    "basic_income_per_cutoff, honorarium_rate_hr, honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, other_rate_hr, " +
                    "other_no_of_hrs_cutoff, other_income_per_cutoff, sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, sss_loan, " +
                    "pagibig_loan, fac_savings_deposit, fac_savings_loan, salary_loan, other_loans, total_deductions, gross_income, net_income, " +
                    "pay_date FROM pos_empRegTbl INNER JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id";
                payrol_select();
                cleartextboxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }
    }
}
