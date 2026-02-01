using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_Prelim
{
    public partial class PayrollDatabase : Form
    {
        //declaration of global variables
        private string picpath;
        private Double basicnetincome = 0.00,
              basic_numhrs = 0.00,
              basic_rate = 0.00,
              hono_netincome = 0.00,
              hono_numhrs = 0.00,
              hono_rate = 0.00,
              other_netincome = 0.00,
              other_numhrs = 0.00,
              other_rate = 0.00;
        private Double netincome = 0.00,
              grossincome = 0.00,
              sss_contrib = 0.00,
              pagibig_contrib = 0.00,
              philhealth_contrib = 0.00,
              tax_contrib = 0.00;
        private Double sss_loan = 0.00,
           pagibig_loan = 0.00,
           salary_loan = 0.00,
           salary_savings = 0.00,
           faculty_sav_loan = 0.00,
           other_deduction = 0.00,
           total_deduction = 0.00,
           total_contrib = 0.00,
           total_loan = 0.00;

        payrol_dbconnection payrol_db_connect = new payrol_dbconnection();
        payrol_variables pay_variables = new payrol_variables();

        public PayrollDatabase()
        {
            // establishing connection to the database upon opening the form
            payrol_db_connect.payrol_connString();
            InitializeComponent();
        }

        private void cleartexteboxes()
        {
            try
            {
                // 1. Linisin ang mga textboxes
                emp_nuTxtbox.Clear(); firstnameTxtbox.Clear(); MNameTxtbox.Clear(); surTxtbox.Clear();
                civil_statusTxtbox.Clear(); desigTxtbox.Clear(); numDependentTxtbox.Clear(); empStatusTxtbox.Clear();
                DeptNameTxtbox.Clear(); BIIncome_Txtbox.Clear(); BIHrs_Txtbox.Clear(); BIRate_Txtbox.Clear();
                HIncome_Txtbox.Clear(); HHours_Txtbox.Clear(); HRate_Txtbox.Clear(); OIncome_Txtbox.Clear();
                OHours_Txtbox.Clear(); ORate_Txtbox.Clear(); SNetIncome_Txtbox.Clear(); SGrossIncome_Txtbox.Clear();
                SSSContri_Txtbox.Clear(); PagibigContri_Txtbox.Clear();
                PhilHealthContri_Txtbox.Clear(); IncometaxContri_Txtbox.Clear();
                SSSLoan_Txtbox.Clear(); PagibigLoan_Txtbox.Clear();
                FSD_Txtbox.Clear(); FSL_Txtbox.Clear();
                SalaryLoan_Txtbox.Clear(); otherLoanTxtbox.Clear();

                // 2. I-reset ang ComboBox at Listbox
                others_loanCombo.SelectedIndex = -1; // Mas maganda ito kaysa .Text
                others_loanCombo.Text = "Select other loan";
                payslip_view_listbox.Items.Clear();

                // 3. I-reset ang PictureBox (Ito ang madalas mag-error)
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose(); // Pakawalan ang file para hindi "Locked"
                    pictureBox1.Image = null;
                }

                // Subukan i-load ang default image pero wag hayaang mag-crash ang app
                try
                {
                    pictureBox1.Image = Image.FromFile("C:\\Users\\andy1\\source\\repos\\AndyVal0611\\ActivityNo1\\UserProf.jpg");
                }
                catch
                {
                    /* Hayaan lang kung walang image */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sa pag-clear: " + ex.Message);
            }
        }

        private string CleanNum(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "0";
            // Tinatanggal ang comma para hindi mag-error sa SQL
            return input.Replace(",", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                payrol_db_connect.payrol_sql = "INSERT INTO payrolTbl (basic_rate_hr, " +
                    "basic_no_of_hrs_cutoff, basic_income_per_cutoff, honorarium_rate_hr, " +
                    "honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, " +
                    "other_rate_hr, other_no_of_hrs_cutoff, other_income_per_cutoff, " +
                    "sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, " +
                    "sss_loan, pagibig_loan, fac_savings_deposit, fac_savings_loan, " +
                    "salary_loan, other_loans, total_deductions, gross_income, " +
                    "net_income, emp_id, pay_date) VALUES ('" +
                    CleanNum(BIRate_Txtbox.Text) + "','" + CleanNum(BIHrs_Txtbox.Text) + "','" + CleanNum(BIIncome_Txtbox.Text) + "','" +
                    CleanNum(HRate_Txtbox.Text) + "','" + CleanNum(HHours_Txtbox.Text) + "','" + CleanNum(HIncome_Txtbox.Text) + "','" +
                    CleanNum(ORate_Txtbox.Text) + "','" + CleanNum(OHours_Txtbox.Text) + "','" + CleanNum(OIncome_Txtbox.Text) + "','" +
                    CleanNum(SSSContri_Txtbox.Text) + "','" + CleanNum(PhilHealthContri_Txtbox.Text) + "','" +
                    CleanNum(PagibigContri_Txtbox.Text) + "','" + CleanNum(IncometaxContri_Txtbox.Text) + "','" +
                    CleanNum(SSSLoan_Txtbox.Text) + "','" + CleanNum(PagibigLoan_Txtbox.Text) + "','" +
                    CleanNum(FSD_Txtbox.Text) + "','" + CleanNum(FSL_Txtbox.Text) + "','" +
                    CleanNum(SalaryLoan_Txtbox.Text) + "','" + CleanNum(otherLoanTxtbox.Text) + "','" +
                    CleanNum(TotalDeductions_Txtbox.Text) + "','" + CleanNum(SGrossIncome_Txtbox.Text) + "','" +
                    CleanNum(SNetIncome_Txtbox.Text) + "','" + emp_nuTxtbox.Text + "','" +
                    paydateDatePicker.Text + "')";

                payrol_db_connect.payrol_cmd();
                payrol_db_connect.payrol_sqladapterInsert();

                MessageBox.Show("Successfully Saved to Database!");
                cleartexteboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input Error: " + ex.Message + "\n\nPakisiguro na walang maling character sa mga boxes.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // EDIT button to update the payroll information of the employee
            try
            {
                // Tamang UPDATE syntax: UPDATE table SET column = value WHERE condition
                payrol_db_connect.payrol_sql = "UPDATE payrolTbl SET " +
                    "basic_rate_hr = '" + CleanNum(BIRate_Txtbox.Text) + "', " +
                    "basic_no_of_hrs_cutoff = '" + CleanNum(BIHrs_Txtbox.Text) + "', " +
                    "basic_income_per_cutoff = '" + CleanNum(BIIncome_Txtbox.Text) + "', " +
                    "honorarium_rate_hr = '" + CleanNum(HRate_Txtbox.Text) + "', " +
                    "honorarium_no_of_hrs_cutoff = '" + CleanNum(HHours_Txtbox.Text) + "', " +
                    "honorarium_income_per_cutoff = '" + CleanNum(HIncome_Txtbox.Text) + "', " +
                    "other_rate_hr = '" + CleanNum(ORate_Txtbox.Text) + "', " +
                    "other_no_of_hrs_cutoff = '" + CleanNum(OHours_Txtbox.Text) + "', " +
                    "other_income_per_cutoff = '" + CleanNum(OIncome_Txtbox.Text) + "', " +
                    "sss_contrib = '" + CleanNum(SSSContri_Txtbox.Text) + "', " +
                    "philhealth_contrib = '" + CleanNum(PhilHealthContri_Txtbox.Text) + "', " +
                    "pagibig_contrib = '" + CleanNum(PagibigContri_Txtbox.Text) + "', " +
                    "tax_contrib = '" + CleanNum(IncometaxContri_Txtbox.Text) + "', " +
                    "sss_loan = '" + CleanNum(SSSLoan_Txtbox.Text) + "', " +
                    "pagibig_loan = '" + CleanNum(PagibigLoan_Txtbox.Text) + "', " +
                    "fac_savings_deposit = '" + CleanNum(FSD_Txtbox.Text) + "', " +
                    "fac_savings_loan = '" + CleanNum(FSL_Txtbox.Text) + "', " +
                    "salary_loan = '" + CleanNum(SalaryLoan_Txtbox.Text) + "', " +
                    "other_loans = '" + CleanNum(otherLoanTxtbox.Text) + "', " +
                    "total_deductions = '" + CleanNum(TotalDeductions_Txtbox.Text) + "', " +
                    "gross_income = '" + CleanNum(SGrossIncome_Txtbox.Text) + "', " +
                    "net_income = '" + CleanNum(SNetIncome_Txtbox.Text) + "' " +
                    "WHERE emp_id = '" + emp_nuTxtbox.Text + "' AND pay_date = '" + paydateDatePicker.Text + "'";

                payrol_db_connect.payrol_cmd();

                // Gamitin ang tamang method para sa Update (karaniwan ay ExecuteNonQuery)
                payrol_db_connect.payrol_sqladapterInsert();

                MessageBox.Show("Employee Payroll Record Successfully Updated!");
                cleartexteboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // DELETE button to remove the payroll information of the employee
            try
            {
                payrol_db_connect.payrol_sql = "DELETE FROM payrolltbl WHERE payrolltbl.emp_id = '" + emp_nuTxtbox.Text + "'";
                payrol_db_connect.payrol_cmd();
                payrol_db_connect.payrol_sqladapterDelete();
                cleartexteboxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Search Button to search the employee information
            try
            {
                payrol_db_connect.payrol_sql = "SELECT emp_id, emp_fname, emp_mname, emp_surname, " +
                    "emp_status, position, emp_no_of_dependents, emp_work_status, emp_department, " +
                    "picpath FROM pos_empRegTbl WHERE emp_id = '" + emp_nuTxtbox.Text + "'";
                payrol_db_connect.payrol_cmd();
                payrol_db_connect.payrol_sqladapterSelect();
                payrol_db_connect.payrol_sqldatasetSELECT();
                firstnameTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][1].ToString();
                MNameTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][2].ToString();
                surTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][3].ToString();
                civil_statusTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][4].ToString();
                desigTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][5].ToString();
                numDependentTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][6].ToString();
                empStatusTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][7].ToString();
                DeptNameTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][8].ToString();
                picpathTxtbox.Text = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0][9].ToString();
                pictureBox1.Image = Image.FromFile(picpathTxtbox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area, contact your administrator!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Search-Edit button to search and edit the payroll information of the employee
            try
            {
                payrol_db_connect.payrol_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, " +
                    "emp_mname, emp_surname, emp_status, position, emp_no_of_dependents, " +
                    "emp_work_status, emp_department, picpath, basic_rate_hr, " +
                    "basic_no_of_hrs_cutoff, basic_income_per_cutoff, honorarium_rate_hr, " +
                    "honorarium_no_of_hrs_cutoff, honorarium_income_per_cutoff, " +
                    "other_rate_hr, other_no_of_hrs_cutoff, other_income_per_cutoff, " +
                    "sss_contrib, philhealth_contrib, pagibig_contrib, tax_contrib, " +
                    "sss_loan, pagibig_loan, fac_savings_deposit, fac_savings_loan, " +
                    "salary_loan, other_loans, total_deductions, gross_income, " +
                    "net_income, payrolTbl.emp_id, pay_date FROM pos_empRegTbl INNER " +
                    "JOIN payrolTbl ON pos_empRegTbl.emp_id = payrolTbl.emp_id WHERE " +
                    "(payrolTbl.emp_id = '" + emp_nuTxtbox.Text + "' AND " +
                    "payrolTbl.pay_date = '" + paydateDatePicker.Text + "')";

                payrol_db_connect.payrol_cmd();
                payrol_db_connect.payrol_sqladapterSelect();
                payrol_db_connect.payrol_sqldatasetSELECT();

                if (payrol_db_connect.payrol_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    var row = payrol_db_connect.payrol_sql_dataset.Tables[0].Rows[0];

                    firstnameTxtbox.Text = row[1].ToString();
                    MNameTxtbox.Text = row[2].ToString();
                    surTxtbox.Text = row[3].ToString();
                    civil_statusTxtbox.Text = row[4].ToString();
                    desigTxtbox.Text = row[5].ToString();
                    numDependentTxtbox.Text = row[6].ToString();
                    empStatusTxtbox.Text = row[7].ToString();
                    DeptNameTxtbox.Text = row[8].ToString();
                    picpathTxtbox.Text = row[9].ToString();

                    if (System.IO.File.Exists(picpathTxtbox.Text))
                    {
                        pictureBox1.Image = Image.FromFile(picpathTxtbox.Text);
                    }

                    BIRate_Txtbox.Text = row[10].ToString();
                    BIHrs_Txtbox.Text = row[11].ToString();
                    BIIncome_Txtbox.Text = row[12].ToString();
                    HRate_Txtbox.Text = row[13].ToString();
                    HHours_Txtbox.Text = row[14].ToString();
                    HIncome_Txtbox.Text = row[15].ToString();
                    ORate_Txtbox.Text = row[16].ToString();
                    OHours_Txtbox.Text = row[17].ToString();
                    OIncome_Txtbox.Text = row[18].ToString();
                    SSSContri_Txtbox.Text = row[19].ToString();
                    PhilHealthContri_Txtbox.Text = row[20].ToString();
                    PagibigContri_Txtbox.Text = row[21].ToString();
                    IncometaxContri_Txtbox.Text = row[22].ToString();
                    SSSLoan_Txtbox.Text = row[23].ToString();
                    PagibigLoan_Txtbox.Text = row[24].ToString();
                    FSD_Txtbox.Text = row[25].ToString();
                    FSL_Txtbox.Text = row[26].ToString();
                    SalaryLoan_Txtbox.Text = row[27].ToString();
                    otherLoanTxtbox.Text = row[28].ToString();
                    TotalDeductions_Txtbox.Text = row[29].ToString();
                    SGrossIncome_Txtbox.Text = row[30].ToString();
                    SNetIncome_Txtbox.Text = row[31].ToString();

                    MessageBox.Show("Employee Record Found!");
                }
                else
                {
                    MessageBox.Show("No payroll record found for this Employee ID and Date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                //codes for converting input data from textboxes as string to numeric
                //codes for putting data from textboxes to variables
                sss_contrib = Convert.ToDouble(SSSContri_Txtbox.Text);
                pagibig_contrib = Convert.ToDouble(PagibigLoan_Txtbox.Text);
                philhealth_contrib = Convert.ToDouble(PhilHealthContri_Txtbox.Text);
                tax_contrib = Convert.ToDouble(IncometaxContri_Txtbox.Text);
                sss_loan = Convert.ToDouble(SSSLoan_Txtbox.Text);
                pagibig_loan = Convert.ToDouble(PagibigLoan_Txtbox.Text);
                salary_loan = Convert.ToDouble(SalaryLoan_Txtbox.Text);
                faculty_sav_loan = Convert.ToDouble(FSL_Txtbox.Text);
                salary_savings = Convert.ToDouble(FSD_Txtbox.Text);
                other_deduction = Convert.ToDouble(otherLoanTxtbox.Text);

                //formula to compute the desired data to be computed
                total_contrib = sss_contrib + pagibig_contrib + philhealth_contrib + tax_contrib;
                total_loan = sss_loan + pagibig_loan + salary_loan + faculty_sav_loan + salary_savings + other_deduction;
                total_deduction = total_contrib + total_loan;

                //codes for converting numeric data to string and displayed it inside the textboxes
                TotalDeductions_Txtbox.Text = total_deduction.ToString();
                netincome = grossincome - total_deduction;
                SNetIncome_Txtbox.Text = netincome.ToString();

                MessageBox.Show("Calculation completed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Please ensure all numeric fields are filled correctly.");
            }
        }

        private void PreviewPayslipDetails_Click(object sender, EventArgs e)
        {
            payslip_view_listbox.Items.Clear(); // Clear previous content
            payslip_view_listbox.Items.Add("");
            payslip_view_listbox.Items.Add("Employee Number:     " + "" + emp_nuTxtbox.Text);
            payslip_view_listbox.Items.Add("First Name:     " + "" + firstnameTxtbox.Text);
            payslip_view_listbox.Items.Add("Middle Name:     " + "" + MNameTxtbox.Text);
            payslip_view_listbox.Items.Add("Surname:     " + "" + surTxtbox.Text);
            payslip_view_listbox.Items.Add("Designation:     " + "" + desigTxtbox.Text);
            payslip_view_listbox.Items.Add("Employee Status:     " + "" + empStatusTxtbox.Text);
            payslip_view_listbox.Items.Add("Department:     " + "" + DeptNameTxtbox.Text);
            payslip_view_listbox.Items.Add("Pay Date:     " + "" + paydateDatePicker.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("BP Num. of Hours:     " + "P" + BIHrs_Txtbox.Text);
            payslip_view_listbox.Items.Add("BP Rate / Hr.:     " + "P" + BIRate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Basic Pay Income:     " + "P" + BIIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("HI Num. of Hrs.:     " + "P" + HHours_Txtbox.Text);
            payslip_view_listbox.Items.Add("HI Rate / Hr.:     " + "P" + HRate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Honorarium Income:     " + "P" + HIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("");
            payslip_view_listbox.Items.Add("OTI Num. of Hrs.:     " + "P" + OHours_Txtbox.Text);
            payslip_view_listbox.Items.Add("OTI Rate / Hr.:     " + "P" + ORate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Other Income:     " + "P" + OIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("SSS Contribution:     " + "P" + SSSContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("Philhealth Contribution:     " + "P" + PhilHealthContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("Tax Contribution:     " + "P" + IncometaxContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("SSS Loan:      " + "P" + SSSLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Pagibig Loan:     " + "P" + PagibigLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Faculty Savings Account:     " + "P" + FSD_Txtbox.Text);
            payslip_view_listbox.Items.Add("Faculty Savings Loan:     " + "P" + FSL_Txtbox.Text);
            payslip_view_listbox.Items.Add("Salary Loan:     " + "P" + SalaryLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Other Loan:     " + "P" + otherLoanTxtbox.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("Total Deduction:     " + "P" + TotalDeductions_Txtbox.Text);
            payslip_view_listbox.Items.Add("Gross Income:     " + "P" + SGrossIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("Net Income:     " + "P" + SNetIncome_Txtbox.Text);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // exit button to close the form
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
            // codes for clearing all textboxes after inputting the data's payroll information
            cleartexteboxes();
        }

        private void PrintPayslip_Click(object sender, EventArgs e)
        {
            PreviewPayslipDetails_Click(sender, e); // auto fill listbox
            Ex5_PrelimPrint print1 = new Ex5_PrelimPrint();
            print1.priDisplaylistbox.Items.AddRange(this.payslip_view_listbox.Items);
            print1.Show();
        }

        private void OHours_Txtbox_TextChanged(object sender, EventArgs e)
        {
            // try and catch
            try
            {
                other_numhrs = Convert.ToDouble(OHours_Txtbox.Text);
                other_rate = Convert.ToDouble(HRate_Txtbox.Text);
                other_netincome = other_numhrs * other_rate;
                OIncome_Txtbox.Text = other_netincome.ToString();

                // Assumes basicnetincome and hono_netincome are already calculated/defined.
                grossincome = basicnetincome + hono_netincome + other_netincome;
                SGrossIncome_Txtbox.Text = grossincome.ToString("n");
                PagibigContri_Txtbox.Text = "200.00"; // Flat rate for Pag-IBIG

                double tax_contrib; // Declared here for scope

                // 2. PHILHEALTH CONTRIBUTION CALCULATION
                if (grossincome < 10000)
                {
                    PhilHealthContri_Txtbox.Text = "250.00"; // Minimum contribution
                }
                else if (grossincome >= 10000 && grossincome <= 11000)
                {
                    PhilHealthContri_Txtbox.Text = ((11000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 11000 && grossincome <= 12000)
                {
                    PhilHealthContri_Txtbox.Text = ((12000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 12000 && grossincome <= 13000)
                {
                    PhilHealthContri_Txtbox.Text = ((13000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 13000 && grossincome <= 14000)
                {
                    PhilHealthContri_Txtbox.Text = ((14000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 14000 && grossincome <= 15000)
                {
                    PhilHealthContri_Txtbox.Text = ((15000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 15000 && grossincome <= 16000)
                {
                    PhilHealthContri_Txtbox.Text = ((16000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 16000 && grossincome <= 17000)
                {
                    PhilHealthContri_Txtbox.Text = ((17000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 17000 && grossincome <= 18000)
                {
                    PhilHealthContri_Txtbox.Text = ((18000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 18000 && grossincome <= 19000)
                {
                    PhilHealthContri_Txtbox.Text = ((19000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 19000 && grossincome <= 20000)
                {
                    PhilHealthContri_Txtbox.Text = ((20000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 20000 && grossincome <= 21000)
                {
                    PhilHealthContri_Txtbox.Text = ((21000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 21000 && grossincome <= 22000)
                {
                    PhilHealthContri_Txtbox.Text = ((22000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 22000 && grossincome <= 23000)
                {
                    PhilHealthContri_Txtbox.Text = ((23000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 23000 && grossincome <= 24000)
                {
                    PhilHealthContri_Txtbox.Text = ((24000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 24000 && grossincome <= 25000)
                {
                    PhilHealthContri_Txtbox.Text = ((25000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 25000 && grossincome <= 26000)
                {
                    PhilHealthContri_Txtbox.Text = ((26000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 26000 && grossincome <= 27000)
                {
                    PhilHealthContri_Txtbox.Text = ((27000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 27000 && grossincome <= 28000)
                {
                    PhilHealthContri_Txtbox.Text = ((28000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 28000 && grossincome <= 29000)
                {
                    PhilHealthContri_Txtbox.Text = ((29000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 29000 && grossincome <= 30000)
                {
                    PhilHealthContri_Txtbox.Text = ((30000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 30000 && grossincome <= 31000)
                {
                    PhilHealthContri_Txtbox.Text = ((31000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 31000 && grossincome <= 32000)
                {
                    PhilHealthContri_Txtbox.Text = ((32000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 32000 && grossincome <= 33000)
                {
                    PhilHealthContri_Txtbox.Text = ((33000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 33000 && grossincome <= 34000)
                {
                    PhilHealthContri_Txtbox.Text = ((34000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 34000 && grossincome <= 35000)
                {
                    PhilHealthContri_Txtbox.Text = ((35000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 35000 && grossincome <= 36000)
                {
                    PhilHealthContri_Txtbox.Text = ((36000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 36000 && grossincome <= 37000)
                {
                    PhilHealthContri_Txtbox.Text = ((37000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 37000 && grossincome <= 38000)
                {
                    PhilHealthContri_Txtbox.Text = ((38000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 38000 && grossincome <= 39000)
                {
                    PhilHealthContri_Txtbox.Text = ((39000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 39000 && grossincome <= 40000)
                {
                    PhilHealthContri_Txtbox.Text = ((40000 * 0.05) / 2).ToString("N2");
                }
                else if (grossincome > 40000 && grossincome <= 100000)
                {
                    PhilHealthContri_Txtbox.Text = ((grossincome * 0.05) / 2).ToString("N2");
                }
                else
                {
                    // Salary cap is 100,000. Total contribution is 100,000 * 5% = 5000. Employee share is / 2.
                    PhilHealthContri_Txtbox.Text = "2500.00"; // Maximum contribution
                }

                // 3. SSS CONTRIBUTION CALCULATION
                // SSS contribution (2025 Employee Share only, based on uploaded table)
                if (grossincome < 5250.00)
                {
                    SSSContri_Txtbox.Text = "250.00";
                }
                else if (grossincome >= 5250.00 && grossincome <= 5749.99)
                {
                    SSSContri_Txtbox.Text = "275.00";
                }
                else if (grossincome >= 5750.00 && grossincome <= 6249.99)
                {
                    SSSContri_Txtbox.Text = "300.00";
                }
                else if (grossincome >= 6250.00 && grossincome <= 6749.99)
                {
                    SSSContri_Txtbox.Text = "325.00";
                }
                else if (grossincome >= 6750.00 && grossincome <= 7249.99)
                {
                    SSSContri_Txtbox.Text = "350.00";
                }
                else if (grossincome >= 7250.00 && grossincome <= 7749.99)
                {
                    SSSContri_Txtbox.Text = "375.00";
                }
                else if (grossincome >= 7750.00 && grossincome <= 8249.99)
                {
                    SSSContri_Txtbox.Text = "400.00";
                }
                else if (grossincome >= 8250.00 && grossincome <= 8749.99)
                {
                    SSSContri_Txtbox.Text = "425.00";
                }
                else if (grossincome >= 8750.00 && grossincome <= 9249.99)
                {
                    SSSContri_Txtbox.Text = "450.00";
                }
                else if (grossincome >= 9250.00 && grossincome <= 9749.99)
                {
                    SSSContri_Txtbox.Text = "475.00";
                }
                else if (grossincome >= 9750.00 && grossincome <= 10249.99)
                {
                    SSSContri_Txtbox.Text = "500.00";
                }
                else if (grossincome >= 10250.00 && grossincome <= 10749.99)
                {
                    SSSContri_Txtbox.Text = "525.00";
                }
                else if (grossincome >= 10750.00 && grossincome <= 11249.99)
                {
                    SSSContri_Txtbox.Text = "550.00";
                }
                else if (grossincome >= 11250.00 && grossincome <= 11749.99)
                {
                    SSSContri_Txtbox.Text = "575.00";
                }
                else if (grossincome >= 11750.00 && grossincome <= 12249.99)
                {
                    SSSContri_Txtbox.Text = "600.00";
                }
                else if (grossincome >= 12250.00 && grossincome <= 12749.99)
                {
                    SSSContri_Txtbox.Text = "625.00";
                }
                else if (grossincome >= 12750.00 && grossincome <= 13249.99)
                {
                    SSSContri_Txtbox.Text = "650.00";
                }
                else if (grossincome >= 13250.00 && grossincome <= 13749.99)
                {
                    SSSContri_Txtbox.Text = "675.00";
                }
                else if (grossincome >= 13750.00 && grossincome <= 14249.99)
                {
                    SSSContri_Txtbox.Text = "700.00";
                }
                else if (grossincome >= 14250.00 && grossincome <= 14749.99)
                {
                    SSSContri_Txtbox.Text = "725.00";
                }
                else if (grossincome >= 14750.00 && grossincome <= 15249.99)
                {
                    SSSContri_Txtbox.Text = "750.00";
                }
                else if (grossincome >= 15250.00 && grossincome <= 15749.99)
                {
                    SSSContri_Txtbox.Text = "775.00";
                }
                else if (grossincome >= 15750.00 && grossincome <= 16249.99)
                {
                    SSSContri_Txtbox.Text = "800.00";
                }
                else if (grossincome >= 16250.00 && grossincome <= 16749.99)
                {
                    SSSContri_Txtbox.Text = "825.00";
                }
                else if (grossincome >= 16750.00 && grossincome <= 17249.99)
                {
                    SSSContri_Txtbox.Text = "850.00";
                }
                else if (grossincome >= 17250.00 && grossincome <= 17749.99)
                {
                    SSSContri_Txtbox.Text = "875.00";
                }
                else if (grossincome >= 17750.00 && grossincome <= 18249.99)
                {
                    SSSContri_Txtbox.Text = "900.00";
                }
                else if (grossincome >= 18250.00 && grossincome <= 18749.99)
                {
                    SSSContri_Txtbox.Text = "925.00";
                }
                else if (grossincome >= 18750.00 && grossincome <= 19249.99)
                {
                    SSSContri_Txtbox.Text = "950.00";
                }
                else if (grossincome >= 19250.00 && grossincome <= 19749.99)
                {
                    SSSContri_Txtbox.Text = "975.00";
                }
                else if (grossincome >= 19750.00 && grossincome <= 20249.99)
                {
                    SSSContri_Txtbox.Text = "1000.00";
                }
                else
                {
                    // Max contribution cap at 1000 employee share (per new 2025 table)
                    SSSContri_Txtbox.Text = "1000.00";
                }

                // INCOME TAX CONTRIBUTION CALCULATION
                // First Bracket: Not over ₱20,833.33 (Annual ₱250,000)
                if (grossincome <= 20833.33)
                {
                    IncometaxContri_Txtbox.Text = "0.00";
                }
                // Second Bracket: Over ₱20,833.33 but not over ₱33,333.33
                else if (grossincome > 20833.33 && grossincome <= 33333.33)
                {
                    tax_contrib = ((grossincome - 20833.33) * 0.15);
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2"); // Added "N2" for standard two decimal places
                }
                // Third Bracket: Over ₱33,333.33 but not over ₱66,666.67
                else if (grossincome > 33333.33 && grossincome <= 66666.67)
                {

                    tax_contrib = (1875.00 + ((grossincome - 33333.33) * 0.20)); // Used 1875.00 for clarity
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Fourth Bracket: Over ₱66,666.67 but not over ₱166,666.67
                else if (grossincome > 66666.67 && grossincome <= 166666.67)
                {

                    tax_contrib = (8541.67 + ((grossincome - 66666.67) * 0.25)); // Corrected constant to 8541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Fifth Bracket: Over ₱166,666.67 but not over ₱666,666.67
                else if (grossincome > 166666.67 && grossincome <= 666666.67)
                {
                    tax_contrib = (33541.67 + ((grossincome - 166666.67) * 0.30)); // Corrected constant to 33541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Sixth Bracket: Over ₱666,666.67
                else
                {
                    tax_contrib = (183541.67 + ((grossincome - 666666.67) * 0.35)); // Corrected constant to 183541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void payslip_view_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            payslip_view_listbox.Items.Clear(); // Clear previous content
            // auto fill listbox after selecting
            payslip_view_listbox.Items.Add("");
            payslip_view_listbox.Items.Add("Employee Number:     " + "" + emp_nuTxtbox.Text);
            payslip_view_listbox.Items.Add("First Name:     " + "" + firstnameTxtbox.Text);
            payslip_view_listbox.Items.Add("Middle Name:     " + "" + MNameTxtbox.Text);
            payslip_view_listbox.Items.Add("Surname:     " + "" + surTxtbox.Text);
            payslip_view_listbox.Items.Add("Designation:     " + "" + desigTxtbox.Text);
            payslip_view_listbox.Items.Add("Employee Status:     " + "" + empStatusTxtbox.Text);
            payslip_view_listbox.Items.Add("Department:     " + "" + DeptNameTxtbox.Text);
            payslip_view_listbox.Items.Add("Pay Date:     " + "" + paydateDatePicker.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("BP Num. of Hours:     " + "P" + BIHrs_Txtbox.Text);
            payslip_view_listbox.Items.Add("BP Rate / Hr.:     " + "P" + BIRate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Basic Pay Income:     " + "P" + BIIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("HI Num. of Hrs.:     " + "P" + HHours_Txtbox.Text);
            payslip_view_listbox.Items.Add("HI Rate / Hr.:     " + "P" + HRate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Honorarium Income:     " + "P" + HIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("");
            payslip_view_listbox.Items.Add("OTI Num. of Hrs.:     " + "P" + OHours_Txtbox.Text);
            payslip_view_listbox.Items.Add("OTI Rate / Hr.:     " + "P" + ORate_Txtbox.Text);
            payslip_view_listbox.Items.Add("Other Income:     " + "P" + OIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("SSS Contribution:     " + "P" + SSSContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("Philhealth Contribution:     " + "P" + PhilHealthContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("Tax Contribution:     " + "P" + IncometaxContri_Txtbox.Text);
            payslip_view_listbox.Items.Add("SSS Loan:      " + "P" + SSSLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Pagibig Loan:     " + "P" + PagibigLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Faculty Savings Account:     " + "P" + FSD_Txtbox.Text);
            payslip_view_listbox.Items.Add("Faculty Savings Loan:     " + "P" + FSL_Txtbox.Text);
            payslip_view_listbox.Items.Add("Salary Loan:     " + "P" + SalaryLoan_Txtbox.Text);
            payslip_view_listbox.Items.Add("Other Loan:     " + "P" + otherLoanTxtbox.Text);
            payslip_view_listbox.Items.Add("---------------------------------------------------------------------------------------");
            payslip_view_listbox.Items.Add("Total Deduction:     " + "P" + TotalDeductions_Txtbox.Text);
            payslip_view_listbox.Items.Add("Gross Income:     " + "P" + SGrossIncome_Txtbox.Text);
            payslip_view_listbox.Items.Add("Net Income:     " + "P" + SNetIncome_Txtbox.Text);

        }

        private void BIIncome_Txtbox_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void BIHrs_Txtbox_TextChanged(object sender, EventArgs e)
        {
            basic_numhrs = Double.Parse(BIHrs_Txtbox.Text);
            basic_rate = Convert.ToDouble(BIRate_Txtbox.Text);
            basicnetincome = basic_numhrs * basic_rate;
            BIIncome_Txtbox.Text = basicnetincome.ToString("n");
        }

        private void HHours_Txtbox_TextChanged(object sender, EventArgs e)
        {
            //  honorarium textbox
            hono_numhrs = Double.Parse(HHours_Txtbox.Text);
            hono_rate = Convert.ToDouble(HRate_Txtbox.Text);
            hono_netincome = hono_numhrs * hono_rate;
            HIncome_Txtbox.Text = hono_netincome.ToString("n");
        }

        private void others_loanCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set other loan amount based on selected item
            switch (others_loanCombo.Text)
            {
                case "Other 1":
                    otherLoanTxtbox.Text = "500.00";
                    break;
                case "Other 2":
                    otherLoanTxtbox.Text = "550.00";
                    break;
                case "Other 3":
                    otherLoanTxtbox.Text = "1550.00";
                    break;
                case "Other 4":
                    otherLoanTxtbox.Text = "1250.00";
                    break;
                default:
                    otherLoanTxtbox.Text = "0.00";
                    break;
            }
        }

        private void PayrollDatabase_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, World!");
            // Initialize ComboBox items
            others_loanCombo.Items.Clear();
            others_loanCombo.Items.Add("Other 1");
            others_loanCombo.Items.Add("Other 2");
            others_loanCombo.Items.Add("Other 3");
            others_loanCombo.Items.Add("Other 4");

            // Optional: default text
            others_loanCombo.Text = "Select other loan";
        }
    }
}
