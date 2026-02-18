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
    public partial class OdysseyMainForm : Form
    {
        private string loggedInRole;
        public OdysseyMainForm(string role)
        {
            InitializeComponent();
            this.loggedInRole = role;
            this.IsMdiContainer = true;
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicProductsReport frm1 = new MusicProductsReport();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void simplePOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ipasa ang 'this.loggedInRole' sa loob ng parenthesis ()
            MusicProductsCashier frm = new MusicProductsCashier(this.loggedInRole);
            frm.MdiParent = this;
            frm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jEEPOSOrderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicProducts adminForm = new MusicProducts(this.loggedInRole);
            adminForm.Show(); // Lalabas na ang Odyssey Music window
        }
    }
}
