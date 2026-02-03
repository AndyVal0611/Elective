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
    public partial class Prelim2 : Form
    {
        // Personal Info
        public string EmployeeNumber { get; set; }
        public string Department { get; set; }
        public string EmployeeFullName { get; set; }
        public string CivilStatus { get; set; }
        public string Paydate { get; set; }

        // Earnings
        public double BasicIncome { get; set; }
        public double HonorariumIncome { get; set; }
        public double OtherIncome { get; set; }

        // Regular Deductions
        public double SSSContribution { get; set; }
        public double PhilHealthContribution { get; set; }
        public double PagibigContribution { get; set; }
        public double IncomeTaxContribution { get; set; }

        // Other Deductions
        public double SSSLoan { get; set; }
        public double PagibigLoan { get; set; }
        public double FacultySavingsDeposit { get; set; }
        public double FacultySavingsLoan { get; set; }
        public double SalaryLoan { get; set; }
        public double OtherLoans { get; set; }

        // Additional properties for hours
        public double BasicHours { get; set; }
        public double HonorariumHours { get; set; }
        public double OtherHours { get; set; }

        // Summary
        public double GrossIncome { get; set; }
        public double TotalDeductions { get; set; }
        public double NetIncome { get; set; }
        public Prelim2()
        {
            InitializeComponent();
        }

        private void Prelim2_Load(object sender, EventArgs e)
        {
            // Set Company Name
            Company_Txtbox.Text = "Lyceum of the Philippines University Cavite";

            // Set Employee ang Pay Period Information
            EmployeeCode_Txtbox.Text = EmployeeNumber;
            EmployeeName_Txtbox.Text = EmployeeFullName;
            Department_Txtbox.Text = Department;
            CutOff_Txtbox.Text = Paydate;
            PayPeriod_Txtbox.Text = Paydate;

            // EARNINGS
            // Basic Pay
            textBox1.Text = BasicHours.ToString("N0");
            textBox12.Text = BasicIncome.ToString("N2");
            textBox18.Text = "0.00";

            // Overtime
            textBox2.Text = OtherHours.ToString("N0");
            textBox11.Text = OtherIncome.ToString("N2");
            textBox17.Text = "0.00";

            // Honorarium
            textBox3.Text = HonorariumHours.ToString("N0");
            textBox10.Text = HonorariumIncome.ToString("N2");
            textBox16.Text = "0.00";

            // Honorarium Adjustment
            textBox4.Text = "0";
            textBox9.Text = "0.00";
            textBox15.Text = "0.00";

            // Substitution (Lab)
            textBox5.Text = "0";
            textBox8.Text = "0.00";
            textBox14.Text = "0.00";

            // Tardy
            textBox6.Text = "0";
            textBox7.Text = "0.00";
            textBox13.Text = "0.00";

            // Total Earnings
            EarningsTxtbox.Text = GrossIncome.ToString("N2");

            // DEDUCTIONS
            // Amounts
            textBox24.Text = IncomeTaxContribution.ToString("N2");
            textBox23.Text = SSSContribution.ToString("N2");
            textBox22.Text = "200.00"; // Fixed HDMF (Pagibig) from the stated given
            textBox21.Text = PhilHealthContribution.ToString("N2");
            textBox20.Text = "750.00"; // Fixed SSS WISP from the stated given

            // Total Regular Deductions
            DeductionsTxtbox.Text = TotalDeductions.ToString("N2");

            // OVERTIME AND NIGHT DIFFERENTIAL
            // Total Overtime
            OvertimeTxtbox.Text = OtherIncome.ToString("N2");

            // Total of ALL (Gross Income, Deductions, Net Pay)
            GETxtbox.Text = GrossIncome.ToString("N2");
            DEDUCTTxtbox.Text = TotalDeductions.ToString("N2");
            NETPAYTxtbox.Text = NetIncome.ToString("N2");
        }
    }
}
