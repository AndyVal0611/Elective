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
    public partial class OdysseyLogin : Form
    {
        public OdysseyLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string role = "";

            // 1. Hardcoded Validation
            if (user == "admin" && pass == "admin123")
            {
                role = "Administrator";
            }
            else if ((user == "cashier1" && pass == "pass1") || (user == "cashier2" && pass == "pass2"))
            {
                role = "Cashier";
            }
            else
            {
                MessageBox.Show("Mali ang Username o Password!", "Login Failed");
                return;
            }

            // 2. ANG CONDITIONAL NAVIGATION (Admin vs Cashier)
            if (role == "Administrator")
            {
                // ADMIN: Pupunta muna sa Main Form
                OdysseyMainForm mainForm = new OdysseyMainForm(role);
                mainForm.Show();
            }
            else
            {
                // CASHIER: Diretso agad sa MusicProducts screen
                MusicProducts musicForm = new MusicProducts(role);
                musicForm.Show();
            }

            this.Hide(); // Itatago ang Login form pagkatapos
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OdysseyLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtUsername.Focus();
        }
    }
}
