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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == tileVerticalToolStripMenuItem)
                this.LayoutMdi(MdiLayout.TileVertical);
            else if (sender == tileHorizontalToolStripMenuItem)
                this.LayoutMdi(MdiLayout.TileHorizontal);
            else if (sender == cascadeToolStripMenuItem)
                this.LayoutMdi(MdiLayout.Cascade);
        }

        private void jEEPOSIncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS1 frm1 = new POS1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void jEEPOSOrderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS2 frm1 = new POS2();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void simplePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POSAdmin frm1 = new POSAdmin();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payrollApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll frm1 = new Payroll();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payroll frm1 = new Payroll();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void employeeRegistrationPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeRegistration frm1 = new EmployeeRegistration();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void hRAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeRegistration frm1 = new EmployeeRegistration();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void userAccountPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccount frm1 = new UserAccount();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void iTAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccount frm1 = new UserAccount();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReports frm1 = new SalesReports();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void employeeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReports frm1 = new EmployeeReports();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void payrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PayrollReports frm1 = new PayrollReports();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void userReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccountReports frm1 = new UserAccountReports();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void example1DatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example1Database frm1 = new Example1Database();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void aCTI2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity2 frm1 = new Activity2();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void act3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity3 frm1 = new Activity3();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void act4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity4 frm1 = new Activity4();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void prelimForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prelim1 frm1 = new Prelim1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void prelimForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prelim2 frm1 = new Prelim2();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void example2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example2 frm1 = new Example2();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void example3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example3 frm1 = new Example3();
            frm1.MdiParent = this;
            frm1.Show();
        }
    }
}
