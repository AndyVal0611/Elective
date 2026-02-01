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
    public partial class UserAccountReports : Form
    {
        useraccount_db_connection useraccount_db_connect = new useraccount_db_connection();
        public UserAccountReports()
        {
            // Initialize the database connection string for User Account
            useraccount_db_connect.useraccount_connString();
            InitializeComponent();
        }

        private void useraccount_select()
        {
            // retrieving the data from the database
            useraccount_db_connect.useraccount_cmd();
            useraccount_db_connect.useraccount_sqladapterSelect();
            useraccount_db_connect.useraccount_sqldatasetSELECT();
            dataGridView1.DataSource = useraccount_db_connect.useraccount_sql_dataset.Tables[0];
        }

        private void cleartextboxes1()
        {
            // clearing the textboxes after searching
            optionInputTxtbox.Clear();
            optionInputTxtbox.Focus();
        }

        private void UserAccountReports_Load(object sender, EventArgs e)
        {
            // loading the database
            useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, emp_surname, emp_age, " +
                "emp_gender, emp_department, position, user_id, username, password, user_status, account_type " +
                "FROM pos_empRegTbl INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id";
            useraccount_select();
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                // searching the options
                string baseQuery =
                    "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, emp_surname, emp_age, " +
                    "emp_gender, emp_department, position, useraccountTbl.emp_id, username, password, user_status, account_type " +
                    "FROM pos_empRegTbl " +
                    "INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id ";

                if (optionCombo.Text == "user_id")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE useraccountTbl.emp_id = '" + optionInputTxtbox.Text + "'";
                }
                else if (optionCombo.Text == "employee_number")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE pos_empRegTbl.emp_id = '" + optionInputTxtbox.Text + "'";
                }
                else if (optionCombo.Text == "surname")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE emp_surname = '" + optionInputTxtbox.Text + "'";
                }
                else if (optionCombo.Text == "firstname")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE emp_fname = '" + optionInputTxtbox.Text + "'";
                }
                else if (optionCombo.Text == "active")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE user_status = 'Active'";
                }
                else if (optionCombo.Text == "deactivate")
                {
                    useraccount_db_connect.useraccount_sql =
                        baseQuery + "WHERE user_status = 'Deactivate'";
                }
                else
                {
                    MessageBox.Show("No Available Record Found!");
                    return;
                }

                useraccount_select();
                cleartextboxes1();
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!(2)");
            }
        }

        private void BACK_Click(object sender, EventArgs e)
        {
            try
            {
                // going back to the original format after pressing the back button
                useraccount_db_connect.useraccount_sql = "SELECT pos_empRegTbl.emp_id, emp_fname, emp_mname, emp_surname, emp_age, " +
                    "emp_gender, emp_department, position, user_id, username, password, user_status, account_type " +
                    "FROM pos_empRegTbl INNER JOIN useraccountTbl ON pos_empRegTbl.emp_id = useraccountTbl.emp_id";
                useraccount_select();
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }
    }
}
