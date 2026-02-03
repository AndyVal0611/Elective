using PrelimExam2_Lesson5;
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
    public partial class Prelim1 : Form
    {
        private double basicIncome;
        private double honorariumIncome;
        private double otherIncome;
        private double grossIncome;
        private double totalDeductions;
        private double netIncome;
        public Prelim1()
        {
            InitializeComponent();
        }

        private double GetValueFromTextBox(TextBox textBox)
        {
            double value;
            string cleanedText = textBox.Text.Replace(",", "");
            if (double.TryParse(cleanedText, out value))
            {
                return value;
            }
            return 0.0;
        }

        private void Prelim1_Load(object sender, EventArgs e)
        {
            //
        }

        private void btnGrossIncome_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Compute Basic Income
                double basicRate = GetValueFromTextBox(BIRate_Txtbox);
                double basicHours = GetValueFromTextBox(BIHrs_Txtbox);
                basicIncome = basicRate * basicHours;
                BIIncome_Txtbox.Text = basicIncome.ToString("N2");

                // 2. Compute Honorarium Income
                double honorariumRate = GetValueFromTextBox(HRate_Txtbox);
                double honorariumHours = GetValueFromTextBox(HHours_Txtbox);
                honorariumIncome = honorariumRate * honorariumHours;
                HIncome_Txtbox.Text = honorariumIncome.ToString("N2");

                // 3. Compute Other Income
                double otherRate = GetValueFromTextBox(ORate_Txtbox);
                double otherHours = GetValueFromTextBox(OHours_Txtbox);
                otherIncome = otherRate * otherHours;
                OIncome_Txtbox.Text = otherIncome.ToString("N2");

                // 4. Compute Gross Income
                grossIncome = basicIncome + honorariumIncome + otherIncome;
                SGrossIncome_Txtbox.Text = grossIncome.ToString("N2");

                // --- DEDUCTION CALCULATIONS ---
                double tax_contrib = 0.0;

                // SSS contribution (2025 Employee Share only, based on uploaded table)
                if (grossIncome < 5250.00)
                {
                    SSSContri_Txtbox.Text = "250.00";
                }
                else if (grossIncome >= 5250.00 && grossIncome <= 5749.99)
                {
                    SSSContri_Txtbox.Text = "275.00";
                }
                else if (grossIncome >= 5750.00 && grossIncome <= 6249.99)
                {
                    SSSContri_Txtbox.Text = "300.00";
                }
                else if (grossIncome >= 6250.00 && grossIncome <= 6749.99)
                {
                    SSSContri_Txtbox.Text = "325.00";
                }
                else if (grossIncome >= 6750.00 && grossIncome <= 7249.99)
                {
                    SSSContri_Txtbox.Text = "350.00";
                }
                else if (grossIncome >= 7250.00 && grossIncome <= 7749.99)
                {
                    SSSContri_Txtbox.Text = "375.00";
                }
                else if (grossIncome >= 7750.00 && grossIncome <= 8249.99)
                {
                    SSSContri_Txtbox.Text = "400.00";
                }
                else if (grossIncome >= 8250.00 && grossIncome <= 8749.99)
                {
                    SSSContri_Txtbox.Text = "425.00";
                }
                else if (grossIncome >= 8750.00 && grossIncome <= 9249.99)
                {
                    SSSContri_Txtbox.Text = "450.00";
                }
                else if (grossIncome >= 9250.00 && grossIncome <= 9749.99)
                {
                    SSSContri_Txtbox.Text = "475.00";
                }
                else if (grossIncome >= 9750.00 && grossIncome <= 10249.99)
                {
                    SSSContri_Txtbox.Text = "500.00";
                }
                else if (grossIncome >= 10250.00 && grossIncome <= 10749.99)
                {
                    SSSContri_Txtbox.Text = "525.00";
                }
                else if (grossIncome >= 10750.00 && grossIncome <= 11249.99)
                {
                    SSSContri_Txtbox.Text = "550.00";
                }
                else if (grossIncome >= 11250.00 && grossIncome <= 11749.99)
                {
                    SSSContri_Txtbox.Text = "575.00";
                }
                else if (grossIncome >= 11750.00 && grossIncome <= 12249.99)
                {
                    SSSContri_Txtbox.Text = "600.00";
                }
                else if (grossIncome >= 12250.00 && grossIncome <= 12749.99)
                {
                    SSSContri_Txtbox.Text = "625.00";
                }
                else if (grossIncome >= 12750.00 && grossIncome <= 13249.99)
                {
                    SSSContri_Txtbox.Text = "650.00";
                }
                else if (grossIncome >= 13250.00 && grossIncome <= 13749.99)
                {
                    SSSContri_Txtbox.Text = "675.00";
                }
                else if (grossIncome >= 13750.00 && grossIncome <= 14249.99)
                {
                    SSSContri_Txtbox.Text = "700.00";
                }
                else if (grossIncome >= 14250.00 && grossIncome <= 14749.99)
                {
                    SSSContri_Txtbox.Text = "725.00";
                }
                else if (grossIncome >= 14750.00 && grossIncome <= 15249.99)
                {
                    SSSContri_Txtbox.Text = "750.00";
                }
                else if (grossIncome >= 15250.00 && grossIncome <= 15749.99)
                {
                    SSSContri_Txtbox.Text = "775.00";
                }
                else if (grossIncome >= 15750.00 && grossIncome <= 16249.99)
                {
                    SSSContri_Txtbox.Text = "800.00";
                }
                else if (grossIncome >= 16250.00 && grossIncome <= 16749.99)
                {
                    SSSContri_Txtbox.Text = "825.00";
                }
                else if (grossIncome >= 16750.00 && grossIncome <= 17249.99)
                {
                    SSSContri_Txtbox.Text = "850.00";
                }
                else if (grossIncome >= 17250.00 && grossIncome <= 17749.99)
                {
                    SSSContri_Txtbox.Text = "875.00";
                }
                else if (grossIncome >= 17750.00 && grossIncome <= 18249.99)
                {
                    SSSContri_Txtbox.Text = "900.00";
                }
                else if (grossIncome >= 18250.00 && grossIncome <= 18749.99)
                {
                    SSSContri_Txtbox.Text = "925.00";
                }
                else if (grossIncome >= 18750.00 && grossIncome <= 19249.99)
                {
                    SSSContri_Txtbox.Text = "950.00";
                }
                else if (grossIncome >= 19250.00 && grossIncome <= 19749.99)
                {
                    SSSContri_Txtbox.Text = "975.00";
                }
                else if (grossIncome >= 19750.00 && grossIncome <= 20249.99)
                {
                    SSSContri_Txtbox.Text = "1000.00";
                }
                else
                {
                    // Max contribution cap at 1000 employee share (per new 2025 table)
                    SSSContri_Txtbox.Text = "1000.00";
                }


                // PhilHealth contribution based on 2025 table (5% rate)
                if (grossIncome < 10000)
                {
                    PhilHealthContri_Txtbox.Text = "250.00"; // Minimum contribution
                }
                else if (grossIncome >= 10000 && grossIncome <= 11000)
                {
                    PhilHealthContri_Txtbox.Text = ((11000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 11000 && grossIncome <= 12000)
                {
                    PhilHealthContri_Txtbox.Text = ((12000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 12000 && grossIncome <= 13000)
                {
                    PhilHealthContri_Txtbox.Text = ((13000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 13000 && grossIncome <= 14000)
                {
                    PhilHealthContri_Txtbox.Text = ((14000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 14000 && grossIncome <= 15000)
                {
                    PhilHealthContri_Txtbox.Text = ((15000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 15000 && grossIncome <= 16000)
                {
                    PhilHealthContri_Txtbox.Text = ((16000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 16000 && grossIncome <= 17000)
                {
                    PhilHealthContri_Txtbox.Text = ((17000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 17000 && grossIncome <= 18000)
                {
                    PhilHealthContri_Txtbox.Text = ((18000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 18000 && grossIncome <= 19000)
                {
                    PhilHealthContri_Txtbox.Text = ((19000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 19000 && grossIncome <= 20000)
                {
                    PhilHealthContri_Txtbox.Text = ((20000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 20000 && grossIncome <= 21000)
                {
                    PhilHealthContri_Txtbox.Text = ((21000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 21000 && grossIncome <= 22000)
                {
                    PhilHealthContri_Txtbox.Text = ((22000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 22000 && grossIncome <= 23000)
                {
                    PhilHealthContri_Txtbox.Text = ((23000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 23000 && grossIncome <= 24000)
                {
                    PhilHealthContri_Txtbox.Text = ((24000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 24000 && grossIncome <= 25000)
                {
                    PhilHealthContri_Txtbox.Text = ((25000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 25000 && grossIncome <= 26000)
                {
                    PhilHealthContri_Txtbox.Text = ((26000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 26000 && grossIncome <= 27000)
                {
                    PhilHealthContri_Txtbox.Text = ((27000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 27000 && grossIncome <= 28000)
                {
                    PhilHealthContri_Txtbox.Text = ((28000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 28000 && grossIncome <= 29000)
                {
                    PhilHealthContri_Txtbox.Text = ((29000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 29000 && grossIncome <= 30000)
                {
                    PhilHealthContri_Txtbox.Text = ((30000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 30000 && grossIncome <= 31000)
                {
                    PhilHealthContri_Txtbox.Text = ((31000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 31000 && grossIncome <= 32000)
                {
                    PhilHealthContri_Txtbox.Text = ((32000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 32000 && grossIncome <= 33000)
                {
                    PhilHealthContri_Txtbox.Text = ((33000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 33000 && grossIncome <= 34000)
                {
                    PhilHealthContri_Txtbox.Text = ((34000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 34000 && grossIncome <= 35000)
                {
                    PhilHealthContri_Txtbox.Text = ((35000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 35000 && grossIncome <= 36000)
                {
                    PhilHealthContri_Txtbox.Text = ((36000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 36000 && grossIncome <= 37000)
                {
                    PhilHealthContri_Txtbox.Text = ((37000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 37000 && grossIncome <= 38000)
                {
                    PhilHealthContri_Txtbox.Text = ((38000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 38000 && grossIncome <= 39000)
                {
                    PhilHealthContri_Txtbox.Text = ((39000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 39000 && grossIncome <= 40000)
                {
                    PhilHealthContri_Txtbox.Text = ((40000 * 0.05) / 2).ToString("N2");
                }
                else if (grossIncome > 40000 && grossIncome <= 100000)
                {
                    PhilHealthContri_Txtbox.Text = ((grossIncome * 0.05) / 2).ToString("N2");
                }
                else
                {
                    // Salary cap is 100,000. Total contribution is 100,000 * 5% = 5000. Employee share is / 2.
                    PhilHealthContri_Txtbox.Text = "2500.00"; // Maximum contribution
                }

                // Set fixed Pag-IBIG Contribution
                PagibigContri_Txtbox.Text = "200.00";


                // First Bracket: Not over ₱20,833.33 (Annual ₱250,000)
                if (grossIncome <= 20833.33)
                {
                    IncometaxContri_Txtbox.Text = "0.00";
                }
                // Second Bracket: Over ₱20,833.33 but not over ₱33,333.33
                else if (grossIncome > 20833.33 && grossIncome <= 33333.33)
                {
                    tax_contrib = ((grossIncome - 20833.33) * 0.15);
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2"); // Added "N2" for standard two decimal places
                }
                // Third Bracket: Over ₱33,333.33 but not over ₱66,666.67
                else if (grossIncome > 33333.33 && grossIncome <= 66666.67)
                {

                    tax_contrib = (1875.00 + ((grossIncome - 33333.33) * 0.20)); // Used 1875.00 for clarity
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Fourth Bracket: Over ₱66,666.67 but not over ₱166,666.67
                else if (grossIncome > 66666.67 && grossIncome <= 166666.67)
                {

                    tax_contrib = (8541.67 + ((grossIncome - 66666.67) * 0.25)); // Corrected constant to 8541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Fifth Bracket: Over ₱166,666.67 but not over ₱666,666.67
                else if (grossIncome > 166666.67 && grossIncome <= 666666.67)
                {
                    tax_contrib = (33541.67 + ((grossIncome - 166666.67) * 0.30)); // Corrected constant to 33541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
                // Sixth Bracket: Over ₱666,666.67
                else
                {
                    tax_contrib = (183541.67 + ((grossIncome - 666666.67) * 0.35)); // Corrected constant to 183541.67
                    IncometaxContri_Txtbox.Text = tax_contrib.ToString("N2");
                }
            }


            catch (Exception)
            {
                // Catch any unexpected errors, typically related to conversion if GetValueFromTextBox failed unexpectedly
                MessageBox.Show("Invalid data entered. Please check all income rate and hours fields.");

                // Clear and focus the 'Other Hours' box as specified in the request
                OHours_Txtbox.Clear();
                OHours_Txtbox.Focus();

                // You might also want to reset the output boxes here
                SGrossIncome_Txtbox.Clear();
                SSSContri_Txtbox.Clear();
                PhilHealthContri_Txtbox.Clear();
                IncometaxContri_Txtbox.Clear();
            }


        }

        private double GetPhilHealthContribution(double grossIncome)
        {
            double contribution = grossIncome * 0.05 / 2; // 5% shared by employee/employer
            if (contribution < 250) return 250;
            if (contribution > 2500) return 2500;
            return contribution;
        }

        private void btnNetIncome_Click(object sender, EventArgs e)
        {
            double sss = GetValueFromTextBox(SSSContri_Txtbox);
            double philhealth = GetValueFromTextBox(PhilHealthContri_Txtbox);
            double pagibig = GetValueFromTextBox(PagibigContri_Txtbox);
            double incomeTax = GetValueFromTextBox(IncometaxContri_Txtbox);

            double sssLoan = GetValueFromTextBox(SSSLoan_Txtbox);
            double pagibigLoan = GetValueFromTextBox(PagibigLoan_Txtbox);
            double facultySavingsDeposit = GetValueFromTextBox(FSD_Txtbox);
            double facultySavingsLoan = GetValueFromTextBox(FSL_Txtbox);
            double salaryLoan = GetValueFromTextBox(SalaryLoan_Txtbox);
            double otherLoans = GetValueFromTextBox(OtherLoans_Txtbox);

            totalDeductions = sss + philhealth + pagibig + incomeTax + sssLoan + pagibigLoan + facultySavingsDeposit + facultySavingsLoan + salaryLoan + otherLoans;
            TotalDeductions_Txtbox.Text = totalDeductions.ToString("N2");

            netIncome = grossIncome - totalDeductions;
            SNetIncome_Txtbox.Text = netIncome.ToString("N2");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // NEW Button
            // Clear all input textboxes
            employeeno_Txtbox.Clear();
            dept_Txtbox.Clear();
            FName_Txtbox.Clear();
            MName_Txtbox.Clear();
            SName_Txtbox.Clear();
            CivilStat_Txtbox.Clear();
            QDS_Txtbox.Clear();
            Paydate_Txtbox.Clear();
            EmpStat_Txtbox.Clear();
            Designation_Txtbox.Clear();

            BIRate_Txtbox.Clear();
            BIHrs_Txtbox.Clear();
            HRate_Txtbox.Clear();
            HHours_Txtbox.Clear();
            ORate_Txtbox.Clear();
            OHours_Txtbox.Clear();

            SSSContri_Txtbox.Clear();
            PhilHealthContri_Txtbox.Clear();
            PagibigContri_Txtbox.Clear();
            IncometaxContri_Txtbox.Clear();

            SSSLoan_Txtbox.Clear();
            PagibigLoan_Txtbox.Clear();
            FSD_Txtbox.Clear();
            FSL_Txtbox.Clear();
            SalaryLoan_Txtbox.Clear();
            OtherLoans_Txtbox.Clear();

            // Clear all output textboxes
            BIIncome_Txtbox.Clear();
            HIncome_Txtbox.Clear();
            OIncome_Txtbox.Clear();
            SGrossIncome_Txtbox.Clear();
            TotalDeductions_Txtbox.Clear();
            SNetIncome_Txtbox.Clear();

            // Reset global variables
            basicIncome = 0;
            honorariumIncome = 0;
            otherIncome = 0;
            grossIncome = 0;
            totalDeductions = 0;
            netIncome = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SELECT PICTURE Button
            // Instance of OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Image file types
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Select an Image File";

            // Show the dialog and check if the user selected a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path
                string imagePath = openFileDialog1.FileName;

                // Set the PictureBox to display the selected image
                pictureBox1.ImageLocation = imagePath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // SAVE Button
            Prelim2 payslipForm = new Prelim2
            {
                // Transfer employee and pay period data to Form2 properties
                EmployeeNumber = employeeno_Txtbox.Text,
                Department = dept_Txtbox.Text,
                EmployeeFullName = $"{FName_Txtbox.Text} {MName_Txtbox.Text} {SName_Txtbox.Text}",
                CivilStatus = CivilStat_Txtbox.Text,
                Paydate = Paydate_Txtbox.Text,

                // Transfer calculated income data
                BasicIncome = basicIncome,
                HonorariumIncome = honorariumIncome,
                OtherIncome = otherIncome,

                // Transfer hours data
                BasicHours = GetValueFromTextBox(BIHrs_Txtbox),
                HonorariumHours = GetValueFromTextBox(HHours_Txtbox),
                OtherHours = GetValueFromTextBox(OHours_Txtbox),

                // Transfer contributions data
                SSSContribution = GetValueFromTextBox(SSSContri_Txtbox),
                PhilHealthContribution = GetValueFromTextBox(PhilHealthContri_Txtbox),
                PagibigContribution = GetValueFromTextBox(PagibigContri_Txtbox),
                IncomeTaxContribution = GetValueFromTextBox(IncometaxContri_Txtbox),

                // Transfer loan data
                SSSLoan = GetValueFromTextBox(SSSLoan_Txtbox),
                PagibigLoan = GetValueFromTextBox(PagibigLoan_Txtbox),
                FacultySavingsDeposit = GetValueFromTextBox(FSD_Txtbox),
                FacultySavingsLoan = GetValueFromTextBox(FSL_Txtbox),
                SalaryLoan = GetValueFromTextBox(SalaryLoan_Txtbox),
                OtherLoans = GetValueFromTextBox(OtherLoans_Txtbox),

                // Transfer summary data
                GrossIncome = grossIncome,
                TotalDeductions = totalDeductions,
                NetIncome = netIncome
            };

            payslipForm.Show();
        }
    }
}
