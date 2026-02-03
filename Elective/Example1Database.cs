using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Elective
{
    public partial class Example1Database : Form
    {
        //global variable declaration
        string picpath;
        string connectionString = null;
        SqlConnection connection;
        SqlCommand command;
        DataSet dset;
        SqlDataAdapter adaptersql;
        string sql = null;

        public Example1Database()
        {
            //codes in creating and establishing SQL connection object
            connectionString = "Data Source=192.168.1.100,41414;Initial Catalog=sampleDatabaseDb;User ID=Andyval0612;Password=Andyval0612;";
            connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        // Function for clearing textboxes
        private void clrtextboxes()
        {
            picturepathTxtbox.Clear();
            studentNumTxtbox.Clear();
            studentNameTxtbox.Clear();
            departmentTxtbox.Clear();
        }

        private void cmd()
        {
            command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
        }

        //Function for the SQL query code to retrieve data from the database
        private void sqlSelect()
        {
            sql = "SELECT * FROM StudentTbl";
        }

        //Function for codes in SqlDataAdapter SELECT sql command
        private void sqladapterSelect()
        {
            adaptersql = new SqlDataAdapter();
            adaptersql.SelectCommand = command;
            command.ExecuteNonQuery();
        }

        //Function for codes in SqlDataAdapter DELETE sql command
        private void sqladapterDelete()
        {
            adaptersql = new SqlDataAdapter();
            adaptersql.DeleteCommand = command;
            command.ExecuteNonQuery();
        }

        //Function for codes in SqlDataAdapter UPDATE sql command
        private void sqladapterUpdate()
        {
            adaptersql = new SqlDataAdapter();
            adaptersql.UpdateCommand = command;
            command.ExecuteNonQuery();
        }

        //Function for codes in SqlDataAdapter INSERT sql command
        private void sqladapterInsert()
        {
            adaptersql = new SqlDataAdapter();
            adaptersql.InsertCommand = command;
            command.ExecuteNonQuery();
        }

        //Function for codes in SQL DataSet
        private void sqldataset()
        {
            dset = new DataSet();
            adaptersql.Fill(dset, "studentTbl");
            gridView.DataSource = dset.Tables[0];
        }

        private void Example1Database_Load(object sender, EventArgs e)
        {
            picturepathTxtbox.Hide(); // hides the picturepath TextBox
            try
            {
                connection.Open();
                sqlSelect();        // 1. Sets the SELECT SQL query.
                cmd();              // 2. Creates the SqlCommand object.
                sqladapterSelect(); // 3. Creates SqlDataAdapter and executes the SELECT command.
                sqldataset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // PICTURE SELECT In the pictureBox
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog1.ShowDialog();

            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            picturepathTxtbox.Text = openFileDialog1.FileName;

            picpath = openFileDialog1.FileName; // to display the located file in the textbox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SAVE BUTTON
            try
            {
                connection.Open();
                sql = "INSERT INTO studentTbl (student_id, studentName, department, picpath) VALUES ('" + studentNumTxtbox.Text + "','" + studentNameTxtbox.Text + "','" + departmentTxtbox.Text + "','" + picturepathTxtbox.Text + "')";
                cmd();
                sqladapterInsert();
                sqlSelect();
                cmd();
                sqladapterSelect();
                sqldataset();
                clrtextboxes();
                pictureBox1.Image = Image.FromFile("C:\\Users\\andy1\\Downloads\\aaa4555700870356d5bfa5af3e88dd1b.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SEARCH BUTTON
            try
            {
                connection.Open();
                sql = "SELECT * FROM studentTbl WHERE student_id = '" + studentNumTxtbox.Text + "'";
                cmd();
                sqladapterSelect();
                sqldataset();

                studentNameTxtbox.Text = dset.Tables[0].Rows[0][1].ToString();
                departmentTxtbox.Text = dset.Tables[0].Rows[0][2].ToString();
                picturepathTxtbox.Text = dset.Tables[0].Rows[0][3].ToString();
                pictureBox1.Image = Image.FromFile(picturepathTxtbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DELETE BUTTON
            try
            {
                connection.Open();
                sql = "DELETE FROM studentTbl WHERE student_id = '" + studentNumTxtbox.Text + "'";
                cmd();
                sqladapterDelete();
                sqlSelect();
                cmd();
                sqladapterSelect();
                sqldataset();
                clrtextboxes();
                pictureBox1.Image = Image.FromFile("C:\\Users\\andy1\\Downloads\\61f98fa0ae1182727af80db4d4ce4fa4.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // UPDATE/EDIT BUTTON
            try
            {
                connection.Open();
                sql = "UPDATE studentTbl SET studentName = '" + studentNameTxtbox.Text + "', department = '" + departmentTxtbox.Text + "', picpath = '" + picturepathTxtbox.Text + "' WHERE student_id = '" + studentNumTxtbox.Text + "'";
                cmd();
                sqladapterUpdate();
                sqlSelect();
                cmd();
                sqladapterSelect();
                sqldataset();
                clrtextboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close(); // CANCEL BUTTON that will terminate the whole form
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clrtextboxes(); // NEW BUTTON
        }
    }
}
