using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_Prelim
{
    public partial class LoginFrm_Database : Form
    {
        // Private fields to hold user credentials and level
        private String username1, password1, user_level;

        // calling the classes
        employee_dbconnection emp_db_connect = new employee_dbconnection();
        loginDb_dbconnections login_db_connect = new loginDb_dbconnections();

        public LoginFrm_Database()
        {
            // Initialize the database connection string for login
            login_db_connect.login_connString();
            InitializeComponent();
        }

        // Method to clear the username and password textboxes
        private void cleartextboxes()
        {
            usernameTxtbox.Clear();
            usernameTxtbox.Focus(); // Set focus back to the username textbox for next input
            passwordTxtbox.Clear();
        }

        private void LoginFrm_Database_Load(object sender, EventArgs e)
        {
            // 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Cancel button to close the program
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clicking the login button depending on the user_level
            // Constructing the SQL query to check credentials and retrieve user details
            login_db_connect.login_sql =
                "SELECT pos_empRegTbl.emp_id, emp_fname, emp_surname, username, password, account_type, pos_terminal_no " +
                "FROM pos_empRegTbl INNER JOIN useraccountTbl " +
                "ON pos_empRegTbl.emp_id = useraccountTbl.emp_id " +
                "WHERE username = '" + usernameTxtbox.Text +
                "' AND password = '" + passwordTxtbox.Text + "'";

            login_db_connect.login_cmd();
            login_db_connect.login_sqladapterSelect();
            login_db_connect.login_sqldatasetSELECT();

            // Check if any rows were returned (meaning valid credentials were found)
            if (login_db_connect.login_sql_dataset.Tables[0].Rows.Count > 0)
            {
                DataRow row = login_db_connect.login_sql_dataset.Tables[0].Rows[0];
                // Extract the user's account type
                string user_level = row["account_type"].ToString();

                // Logic to open the appropriate form based on user_level
                if (user_level == "Administrator")
                {
                    MessageBox.Show("Access Granted 🎉");
                    MainFormDatabase myform = new MainFormDatabase();
                    myform.Show();
                    cleartextboxes();
                    this.Hide();
                }
                else if (user_level == "Cashier1")
                {
                    MessageBox.Show("Access Granted 🎉");
                    POS2Database myform = new POS2Database();
                    cleartextboxes();
                    myform.Show();
                }
                else if (user_level == "Cashier2")
                {
                    MessageBox.Show("Access Granted 🎉");
                    POS1Database myform = new POS1Database();
                    // Pass specific user data to the Cashier 2 form (POS1Database)
                    myform.terminal_noLbl.Text = login_db_connect.login_sql_dataset.Tables[0].Rows[0][6].ToString();
                    myform.emp_idLbl.Text = login_db_connect.login_sql_dataset.Tables[0].Rows[0][0].ToString();
                    myform.emp_fname.Text = login_db_connect.login_sql_dataset.Tables[0].Rows[0][1].ToString();
                    myform.emp_surname.Text = login_db_connect.login_sql_dataset.Tables[0].Rows[0][2].ToString();
                    cleartextboxes();
                    myform.Show();
                }
                else if (user_level == "HR Staff")
                {
                    MessageBox.Show("Access Granted 🎉");
                    employee_registration myform = new employee_registration();
                    myform.button5.Enabled = false; //delete
                    cleartextboxes();
                    myform.Show();
                }
                else if (user_level == "Accounting Staff")
                {
                    MessageBox.Show("Access Granted 🎉");
                    PayrollDatabase myform = new PayrollDatabase();
                    myform.button6.Hide(); //search-edit
                    myform.button4.Hide(); // edit
                    myform.button5.Hide(); //delete
                    cleartextboxes();
                    myform.Show();
                }
                else if (user_level == "IT Staff")
                {
                    MessageBox.Show("Access Granted 🎉");
                    user_account myform = new user_account();
                    myform.button2.Hide();
                    myform.button4.Hide();
                    myform.button3.Hide(); 
                    cleartextboxes();
                    myform.Show(); // Show IT Staff form
                }
                else
                {
                    MessageBox.Show("Access Denied.");
                    cleartextboxes();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                cleartextboxes();
            }
        }
    }
}