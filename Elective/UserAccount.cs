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
    public partial class UserAccount : Form
    {
        // create an object for useraccount_db_connection class
        useraccount_db_connection useraccount_db_connect = new useraccount_db_connection();
        public UserAccount()
        {
            // call the function for database connection
            useraccount_db_connect.useraccount_connString();
            InitializeComponent();
        }

        private void cleartextboxes()
        {
            // clear all textboxes
            emp_idTxtbox.Clear();
            userIDTxtbox.Clear();
            firstnameTxtbox.Clear();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            // disable textboxes that are not needed to be edited
            firstnameTxtbox.Enabled = false;
            middlenameTxtbox.Enabled = false;
            surnameTxtbox.Enabled = false;
            designationTxtbox.Enabled = false;
            picpathTxtbox.Enabled = false;
            picpathTxtbox.Hide();
            useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, " +
                "emp_surname, position, user_id, username, password, user_status, account_type " +
                "FROM pos_empRegTbl INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id";
            useraccount_db_connect.useraccount_cmd();
            useraccount_db_connect.useraccount_sqladapterSelect();
            useraccount_db_connect.useraccount_sqldatasetSELECT();
            dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // search user ID
            try
            {
                useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, " +
                    "emp_surname, position, picpath, user_id, username, password, user_status, account_type FROM pos_empRegTbl " +
                    "INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id WHERE user_id = '" + userIDTxtbox.Text + "'";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterSelect();
                useraccount_db_connect.useraccount_sqldatasetSELECT();
                dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];
                firstnameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][1].ToString();
                middlenameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][2].ToString();
                surnameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][3].ToString();
                designationTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][4].ToString();
                picpathTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][5].ToString();
                pictureBox1.Image = Image.FromFile(picpathTxtbox.Text);
                usernameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][7].ToString();
                passwordTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][8].ToString();
                account_statusComboBox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][9].ToString();
                accountTypeComboBox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][10].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!(3)");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // update user account
            try
            {
                useraccount_db_connect.useraccount_sql = "UPDATE useraccountTbl SET account_type = '" + accountTypeComboBox.Text + "', username = '" + usernameTxtbox.Text + "', password = '" +
                    passwordTxtbox.Text + "', confirm_password = '" + confirmPasswordTxtbox.Text + "', user_status = '" + account_statusComboBox.Text + "' WHERE user_id = '" + userIDTxtbox.Text + "'";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterDelete();
                useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, " +
                    "emp_mname, emp_surname, position, user_id, username, password, user_status, " +
                    "account_type FROM pos_empRegTbl INNER JOIN useraccountTbl ON " +
                    "pos_empRegTbl.emp_id = useraccountTbl.emp_id";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterSelect();
                useraccount_db_connect.useraccount_sqldatasetSELECT();
                dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error in this area. Please contact your administrator!(4)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // delete user account
            try
            {
                // 1. Maglagay ng Confirmation Box para hindi aksidenteng mabura
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user account?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // 2. Gamitin ang DELETE SQL command base sa user_id
                    useraccount_db_connect.useraccount_sql = "DELETE FROM useraccountTbl WHERE user_id = '" + userIDTxtbox.Text + "'";

                    useraccount_db_connect.useraccount_cmd();

                    // Dito mo gagamitin ang adapter para sa execution (base sa class mo)
                    useraccount_db_connect.useraccount_sqladapterDelete();

                    MessageBox.Show("User account successfully deleted.");

                    // 3. Refresh ang DataGridView para makita na wala na ang binura
                    useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, " +
                        "emp_surname, position, user_id, username, " +
                        "password, user_status, account_type FROM pos_empRegTbl INNER JOIN useraccountTbl " +
                        "ON pos_empRegTbl.emp_id = useraccountTbl.emp_id";

                    useraccount_db_connect.useraccount_cmd();
                    useraccount_db_connect.useraccount_sqladapterSelect();
                    useraccount_db_connect.useraccount_sqldatasetSELECT();
                    dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];

                    // 4. Linisin ang mga textboxes pagkatapos mag-delete
                    cleartextboxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deletion: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // add user account
            try
            {
                useraccount_db_connect.useraccount_sql = "INSERT INTO useraccountTbl (user_id, account_type, username, password, confirm_password, user_status, emp_id) " +
                    "VALUES ('" + userIDTxtbox.Text + "', '" + accountTypeComboBox.Text + "', '" + usernameTxtbox.Text + "', '" +
                    passwordTxtbox.Text + "', '" + confirmPasswordTxtbox.Text + "', '" + account_statusComboBox.Text + "', '" + emp_idTxtbox.Text + "')";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterInsert();
                useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, " +
                    "emp_mname, emp_surname, position, " +
                    "user_id, username, password, user_status, account_type FROM pos_empRegTbl " +
                    "INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterSelect();
                useraccount_db_connect.useraccount_sqldatasetSELECT();
                dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error in this area. Please contact your administrator!(6)");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // clear all textboxes
            cleartextboxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // search employee ID
            try
            {
                useraccount_db_connect.useraccount_sql = "SELECT emp_id, emp_fname, emp_mname, " +
                    "emp_surname, position, picpath FROM pos_empRegTbl WHERE emp_id = '" + emp_idTxtbox.Text + "'";
                useraccount_db_connect.useraccount_cmd();
                useraccount_db_connect.useraccount_sqladapterSelect();
                useraccount_db_connect.useraccount_sqldatasetSELECT();
                firstnameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][1].ToString();
                middlenameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][2].ToString();
                surnameTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][3].ToString();
                designationTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][4].ToString();
                picpathTxtbox.Text = useraccount_db_connect.useraccount_sql_dataset.Tables[0].Rows[0][5].ToString();
                pictureBox1.Image = Image.FromFile(picpathTxtbox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error in this area. Please contact your administrator!(2)");
            }
        }
    }
}