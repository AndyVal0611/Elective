using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Example3;
using Activity3;
using Example4;
using PrelimExam2_Lesson5;
using PrelimNo2;
using Activity4;
using Activity5;
using ActivityNo1;
using Quiz1;
using Activity6;

using System.Diagnostics;

namespace DSAL_Prelim
{
    public partial class MainFormDatabase : Form
    {
        public MainFormDatabase()
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
            POS1Database frm1 = new POS1Database();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void jEEPOSOrderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS2Database frm1 = new POS2Database();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void simplePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS_Admin frm1 = new POS_Admin();
            frm1.MdiParent = this;
            frm1.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payrollApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollDatabase frm1 = new PayrollDatabase();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollDatabase frm1 = new PayrollDatabase();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void hRAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_registration frm1 = new employee_registration();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void userAccountPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_account frm = new user_account();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeRegistrationPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_registration frm1 = new employee_registration();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void iTAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_account frm = new user_account();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales_reports frm1 = new sales_reports();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void employeeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee_reports frm = new employee_reports();
            frm.MdiParent = this;
            frm.Show();
        }

        private void payrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            payroll_report frm = new payroll_report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void userReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useraccount_report frm = new useraccount_report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void example1DatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example1Database frm = new Example1Database();
            frm.MdiParent = this;
            frm.Show();
        }

        private void activity1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            form1.Show();

        }

        private void aCTI2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ACTI2 form = new ACTI2();
            form.MdiParent = this;
            form.Show();
        }

        private void act3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act3 form = new Act3();
            form.MdiParent = this;
            form.Show();
        }

        private void act4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act4 form = new Act4();
            form.MdiParent = this;
            form.Show();
        }

        private void act5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Act5 form = new Act5();
            form.MdiParent = this;
            form.Show();
        }

        private void act61ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity6_1 frm = new Activity6_1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void act62ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity6_2 frm = new Activity6_2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ex4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ex4 form = new Ex4();
            form.MdiParent = this;
            form.Show();
        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ex5_Prelim frm = new Ex5_Prelim();
            frm.MdiParent = this;
            frm.Show();
        }

        private void example31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example3_1 frm = new Example3_1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void example5PrelimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example5_Prelim frm = new Example5_Prelim();
            frm.MdiParent = this;
            frm.Show();
        }

        private void payrollFunctionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollFunctionForm frm = new PayrollFunctionForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void prelimForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrelimForm1 frm = new PrelimForm1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quizFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuizForm form = new QuizForm();
            form.MdiParent = this;
            form.Show();
        }

        private void example1FuncDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Example1FuncDatabase frm = new Example1FuncDatabase(); 
            frm.MdiParent = this;
            frm.Show();
        }

        private void ifSample21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            If_Sample_2_1 frm = new If_Sample_2_1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void prelimForm2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrelimForm2 frm = new PrelimForm2();
            frm.MdiParent = this;
            frm.Show();
            
        }
    }
}
