using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elective
{
    public partial class POSAdmin : Form
    {
        pos_dbconnection pos_dbconnect = new pos_dbconnection();
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private string picpath;
        private Image pic;

        public POSAdmin()
        {
            pos_dbconnect.pos_connString();
            InitializeComponent();
        }

        private void cleartextboxes()
        {
            try
            {
                // Load the default image (adjust path if necessary)
                string defaultImagePath = "C:\\Users\\andy1\\source\\repos\\AndyVal0611\\ActivityNo1\\UserProf.jpg";
                if (File.Exists(defaultImagePath))
                {
                    pic = Image.FromFile(defaultImagePath);
                }
                else
                {
                    pic = null;
                }

                // Clear picpath textboxes
                picpathTxtbox1.Clear(); picpathTxtbox2.Clear(); picpathTxtbox3.Clear(); picpathTxtbox4.Clear(); picpathTxtbox5.Clear(); picpathTxtbox6.Clear(); picpathTxtbox7.Clear(); picpathTxtbox8.Clear(); picpathTxtbox9.Clear(); picpathTxtbox10.Clear();
                picpathTxtbox11.Clear(); picpathTxtbox12.Clear(); picpathTxtbox13.Clear(); picpathTxtbox14.Clear(); picpathTxtbox15.Clear(); picpathTxtbox16.Clear(); picpathTxtbox17.Clear(); picpathTxtbox18.Clear(); picpathTxtbox19.Clear(); picpathTxtbox20.Clear();

                // Clear price textboxes
                priceTxtbox1.Clear(); priceTxtbox2.Clear(); priceTxtbox3.Clear(); priceTxtbox4.Clear(); priceTxtbox5.Clear(); priceTxtbox6.Clear(); priceTxtbox7.Clear(); priceTxtbox8.Clear(); priceTxtbox9.Clear(); priceTxtbox10.Clear();
                priceTxtbox11.Clear(); priceTxtbox12.Clear(); priceTxtbox13.Clear(); priceTxtbox14.Clear(); priceTxtbox15.Clear(); priceTxtbox16.Clear(); priceTxtbox17.Clear(); priceTxtbox18.Clear(); priceTxtbox19.Clear(); priceTxtbox20.Clear();

                // Clear name textboxes
                nameTxtbox1.Clear(); nameTxtbox2.Clear(); nameTxtbox3.Clear(); nameTxtbox4.Clear(); nameTxtbox5.Clear(); nameTxtbox6.Clear(); nameTxtbox7.Clear(); nameTxtbox8.Clear(); nameTxtbox9.Clear(); nameTxtbox10.Clear();
                nameTxtbox11.Clear(); nameTxtbox12.Clear(); nameTxtbox13.Clear(); nameTxtbox14.Clear(); nameTxtbox15.Clear(); nameTxtbox16.Clear(); nameTxtbox17.Clear(); nameTxtbox18.Clear(); nameTxtbox19.Clear(); nameTxtbox20.Clear();

                // Reset all picture boxes to default image if default exists
                if (pic != null)
                {
                    pictureBox1.Image = pic; pictureBox2.Image = pic; pictureBox3.Image = pic; pictureBox4.Image = pic;
                    pictureBox5.Image = pic; pictureBox6.Image = pic; pictureBox7.Image = pic; pictureBox8.Image = pic;
                    pictureBox9.Image = pic; pictureBox10.Image = pic; pictureBox11.Image = pic; pictureBox12.Image = pic;
                    pictureBox13.Image = pic; pictureBox14.Image = pic; pictureBox15.Image = pic; pictureBox16.Image = pic;
                    pictureBox17.Image = pic; pictureBox18.Image = pic; pictureBox19.Image = pic; pictureBox20.Image = pic;
                }
                else
                {
                    // If default image not found, set image to null to avoid exceptions
                    pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null;
                    pictureBox5.Image = null; pictureBox6.Image = null; pictureBox7.Image = null; pictureBox8.Image = null;
                    pictureBox9.Image = null; pictureBox10.Image = null; pictureBox11.Image = null; pictureBox12.Image = null;
                    pictureBox13.Image = null; pictureBox14.Image = null; pictureBox15.Image = null; pictureBox16.Image = null;
                    pictureBox17.Image = null; pictureBox18.Image = null; pictureBox19.Image = null; pictureBox20.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!\n\n" + ex.Message);
            }
        }

        private void open_file_image()
        {
            openFileDialog1.Filter = "Image Files|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.ShowDialog(); // to display the located file in the textbox
        }

        private void LoadComboBoxIDs()
        {
            try
            {
                // Clear previous items to avoid duplicates
                comboBox1.Items.Clear();

                // Query all available pos_id values from the database
                pos_dbconnect.pos_sql = "SELECT pos_id FROM pos_nameTbl ORDER BY pos_id ASC";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();

                // If data exists, add them to comboBox
                if (pos_dbconnect.pos_sql_dataset != null &&
                    pos_dbconnect.pos_sql_dataset.Tables.Count > 0 &&
                    pos_dbconnect.pos_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in pos_dbconnect.pos_sql_dataset.Tables[0].Rows)
                    {
                        comboBox1.Items.Add(row["pos_id"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No POS IDs found in the database.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load POS IDs.");
            }
        }

        private void POSAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                picpathTxtbox1.Hide(); picpathTxtbox2.Hide(); picpathTxtbox3.Hide(); picpathTxtbox4.Hide(); picpathTxtbox5.Hide(); picpathTxtbox6.Hide(); picpathTxtbox7.Hide(); picpathTxtbox8.Hide(); picpathTxtbox9.Hide(); picpathTxtbox10.Hide();
                picpathTxtbox11.Hide(); picpathTxtbox12.Hide(); picpathTxtbox13.Hide(); picpathTxtbox14.Hide(); picpathTxtbox15.Hide(); picpathTxtbox16.Hide(); picpathTxtbox17.Hide(); picpathTxtbox18.Hide(); picpathTxtbox19.Hide(); picpathTxtbox20.Hide();

                // Load ComboBox IDs here
                LoadComboBoxIDs();

                // accessing the pos_dbconnection class which consists of codes to connect to the database
                pos_dbconnect.pos_select();
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();
                gridView.DataSource = pos_dbconnect.pos_sql_dataset.Tables[0];

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SEARCH BUTTON
            try
            {
                // 1. Tiyakin na may laman ang ComboBox1 (POS ID)
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Please enter a POS ID to search.", "Missing ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cleartextboxes(); // Clear
                    return; // Stops execution
                }

                // clearing for new searcg
                cleartextboxes();

                // SQL Query
                pos_dbconnect.pos_sql = "SELECT * FROM pos_nameTbl INNER JOIN pos_picTbl ON pos_nameTbl.pos_id = pos_picTbl.pos_id " +
                    "INNER JOIN pos_priceTbl ON pos_nameTbl.pos_id = pos_priceTbl.pos_id WHERE pos_nameTbl.pos_id = '" + comboBox1.Text + "'";

                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();

                // Updates the DataGridView
                gridView.DataSource = pos_dbconnect.pos_sql_dataset.Tables[0];

                // Check if there's a row indicated
                if (pos_dbconnect.pos_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = pos_dbconnect.pos_sql_dataset.Tables[0].Rows[0];

                    // I-display ang NAMEs (Columns 2 hanggang 21)
                    nameTxtbox1.Text = row[2].ToString(); nameTxtbox2.Text = row[3].ToString(); nameTxtbox3.Text = row[4].ToString(); nameTxtbox4.Text = row[5].ToString();
                    nameTxtbox5.Text = row[6].ToString(); nameTxtbox6.Text = row[7].ToString(); nameTxtbox7.Text = row[8].ToString(); nameTxtbox8.Text = row[9].ToString();
                    nameTxtbox9.Text = row[10].ToString(); nameTxtbox10.Text = row[11].ToString(); nameTxtbox11.Text = row[12].ToString(); nameTxtbox12.Text = row[13].ToString();
                    nameTxtbox13.Text = row[14].ToString(); nameTxtbox14.Text = row[15].ToString(); nameTxtbox15.Text = row[16].ToString(); nameTxtbox16.Text = row[17].ToString();
                    nameTxtbox17.Text = row[18].ToString(); nameTxtbox18.Text = row[19].ToString(); nameTxtbox19.Text = row[20].ToString(); nameTxtbox20.Text = row[21].ToString();

                    // I-display ang PICs (Columns 24 hanggang 43)
                    picpathTxtbox1.Text = row[24].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox1.Text)) { pictureBox1.Image = Image.FromFile(picpathTxtbox1.Text); } else { pictureBox1.Image = null; }
                    picpathTxtbox2.Text = row[25].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox2.Text)) { pictureBox2.Image = Image.FromFile(picpathTxtbox2.Text); } else { pictureBox2.Image = null; }
                    picpathTxtbox3.Text = row[26].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox3.Text)) { pictureBox3.Image = Image.FromFile(picpathTxtbox3.Text); } else { pictureBox3.Image = null; }
                    picpathTxtbox4.Text = row[27].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox4.Text)) { pictureBox4.Image = Image.FromFile(picpathTxtbox4.Text); } else { pictureBox4.Image = null; }
                    picpathTxtbox5.Text = row[28].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox5.Text)) { pictureBox5.Image = Image.FromFile(picpathTxtbox5.Text); } else { pictureBox5.Image = null; }
                    picpathTxtbox6.Text = row[29].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox6.Text)) { pictureBox6.Image = Image.FromFile(picpathTxtbox6.Text); } else { pictureBox6.Image = null; }
                    picpathTxtbox7.Text = row[30].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox7.Text)) { pictureBox7.Image = Image.FromFile(picpathTxtbox7.Text); } else { pictureBox7.Image = null; }
                    picpathTxtbox8.Text = row[31].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox8.Text)) { pictureBox8.Image = Image.FromFile(picpathTxtbox8.Text); } else { pictureBox8.Image = null; }
                    picpathTxtbox9.Text = row[32].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox9.Text)) { pictureBox9.Image = Image.FromFile(picpathTxtbox9.Text); } else { pictureBox9.Image = null; }
                    picpathTxtbox10.Text = row[33].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox10.Text)) { pictureBox10.Image = Image.FromFile(picpathTxtbox10.Text); } else { pictureBox10.Image = null; }
                    picpathTxtbox11.Text = row[34].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox11.Text)) { pictureBox11.Image = Image.FromFile(picpathTxtbox11.Text); } else { pictureBox11.Image = null; }
                    picpathTxtbox12.Text = row[35].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox12.Text)) { pictureBox12.Image = Image.FromFile(picpathTxtbox12.Text); } else { pictureBox12.Image = null; }
                    picpathTxtbox13.Text = row[36].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox13.Text)) { pictureBox13.Image = Image.FromFile(picpathTxtbox13.Text); } else { pictureBox13.Image = null; }
                    picpathTxtbox14.Text = row[37].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox14.Text)) { pictureBox14.Image = Image.FromFile(picpathTxtbox14.Text); } else { pictureBox14.Image = null; }
                    picpathTxtbox15.Text = row[38].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox15.Text)) { pictureBox15.Image = Image.FromFile(picpathTxtbox15.Text); } else { pictureBox15.Image = null; }
                    picpathTxtbox16.Text = row[39].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox16.Text)) { pictureBox16.Image = Image.FromFile(picpathTxtbox16.Text); } else { pictureBox16.Image = null; }
                    picpathTxtbox17.Text = row[40].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox17.Text)) { pictureBox17.Image = Image.FromFile(picpathTxtbox17.Text); } else { pictureBox17.Image = null; }
                    picpathTxtbox18.Text = row[41].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox18.Text)) { pictureBox18.Image = Image.FromFile(picpathTxtbox18.Text); } else { pictureBox18.Image = null; }
                    picpathTxtbox19.Text = row[42].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox19.Text)) { pictureBox19.Image = Image.FromFile(picpathTxtbox19.Text); } else { pictureBox19.Image = null; }
                    picpathTxtbox20.Text = row[43].ToString(); if (!string.IsNullOrEmpty(picpathTxtbox20.Text)) { pictureBox20.Image = Image.FromFile(picpathTxtbox20.Text); } else { pictureBox20.Image = null; }

                    // I-display ang PRICEs (Columns 46 hanggang 65)
                    priceTxtbox1.Text = row[46].ToString(); priceTxtbox2.Text = row[47].ToString(); priceTxtbox3.Text = row[48].ToString(); priceTxtbox4.Text = row[49].ToString();
                    priceTxtbox5.Text = row[50].ToString(); priceTxtbox6.Text = row[51].ToString(); priceTxtbox7.Text = row[52].ToString(); priceTxtbox8.Text = row[53].ToString();
                    priceTxtbox9.Text = row[54].ToString(); priceTxtbox10.Text = row[55].ToString(); priceTxtbox11.Text = row[56].ToString(); priceTxtbox12.Text = row[57].ToString();
                    priceTxtbox13.Text = row[58].ToString(); priceTxtbox14.Text = row[59].ToString(); priceTxtbox15.Text = row[60].ToString(); priceTxtbox16.Text = row[61].ToString();
                    priceTxtbox17.Text = row[62].ToString(); priceTxtbox18.Text = row[63].ToString(); priceTxtbox19.Text = row[64].ToString(); priceTxtbox20.Text = row[65].ToString();
                }
                else
                {
                    // Walang nahanap na record
                    MessageBox.Show("No record found for POS ID: " + comboBox1.Text, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Mas specific na error handling. Maaaring may problema sa Image.FromFile kung hindi valid ang path.
                if (ex is System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Error loading image file. One of the image paths is invalid or missing.", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An unexpected error occurred during search: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SAVE BUTTON
            try
            {
                // ===== INSERT into pos_nameTbl =====
                pos_dbconnect.pos_sql = "INSERT INTO pos_nameTbl " +
                    "(pos_id, name1, name2, name3, name4, name5, name6, name7, name8, name9, name10, " +
                    "name11, name12, name13, name14, name15, name16, name17, name18, name19, name20) VALUES " +
                    "('" + comboBox1.Text + "', '" + nameTxtbox1.Text + "', '" + nameTxtbox2.Text + "', '" + nameTxtbox3.Text + "', '" +
                    nameTxtbox4.Text + "', '" + nameTxtbox5.Text + "', '" + nameTxtbox6.Text + "', '" + nameTxtbox7.Text + "', '" +
                    nameTxtbox8.Text + "', '" + nameTxtbox9.Text + "', '" + nameTxtbox10.Text + "', '" + nameTxtbox11.Text + "', '" +
                    nameTxtbox12.Text + "', '" + nameTxtbox13.Text + "', '" + nameTxtbox14.Text + "', '" + nameTxtbox15.Text + "', '" +
                    nameTxtbox16.Text + "', '" + nameTxtbox17.Text + "', '" + nameTxtbox18.Text + "', '" + nameTxtbox19.Text + "', '" +
                    nameTxtbox20.Text + "')";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterInsert();

                // ===== INSERT into pos_priceTbl =====
                pos_dbconnect.pos_sql = "INSERT INTO pos_priceTbl " +
                    "(price1, price2, price3, price4, price5, price6, price7, price8, price9, price10, " +
                    "price11, price12, price13, price14, price15, price16, price17, price18, price19, price20, pos_id) VALUES " +
                    "('" + priceTxtbox1.Text + "', '" + priceTxtbox2.Text + "', '" + priceTxtbox3.Text + "', '" + priceTxtbox4.Text + "', '" +
                    priceTxtbox5.Text + "', '" + priceTxtbox6.Text + "', '" + priceTxtbox7.Text + "', '" + priceTxtbox8.Text + "', '" +
                    priceTxtbox9.Text + "', '" + priceTxtbox10.Text + "', '" + priceTxtbox11.Text + "', '" + priceTxtbox12.Text + "', '" +
                    priceTxtbox13.Text + "', '" + priceTxtbox14.Text + "', '" + priceTxtbox15.Text + "', '" + priceTxtbox16.Text + "', '" +
                    priceTxtbox17.Text + "', '" + priceTxtbox18.Text + "', '" + priceTxtbox19.Text + "', '" + priceTxtbox20.Text + "', '" +
                    comboBox1.Text + "')";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterInsert();

                // ===== INSERT into pos_picTbl =====
                pos_dbconnect.pos_sql = "INSERT INTO pos_picTbl " +
                    "(pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, " +
                    "pic11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20, pos_id) VALUES " +
                    "('" + picpathTxtbox1.Text + "', '" + picpathTxtbox2.Text + "', '" + picpathTxtbox3.Text + "', '" + picpathTxtbox4.Text + "', '" +
                    picpathTxtbox5.Text + "', '" + picpathTxtbox6.Text + "', '" + picpathTxtbox7.Text + "', '" + picpathTxtbox8.Text + "', '" +
                    picpathTxtbox9.Text + "', '" + picpathTxtbox10.Text + "', '" + picpathTxtbox11.Text + "', '" + picpathTxtbox12.Text + "', '" +
                    picpathTxtbox13.Text + "', '" + picpathTxtbox14.Text + "', '" + picpathTxtbox15.Text + "', '" + picpathTxtbox16.Text + "', '" +
                    picpathTxtbox17.Text + "', '" + picpathTxtbox18.Text + "', '" + picpathTxtbox19.Text + "', '" + picpathTxtbox20.Text + "', '" +
                    comboBox1.Text + "')";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterInsert();

                // ===== REFRESH DataGridView =====
                pos_dbconnect.pos_select();
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();

                gridView.DataSource = pos_dbconnect.pos_sql_dataset.Tables[0];

                // ===== CLEAR INPUTS =====
                cleartextboxes();

                MessageBox.Show("Record successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // ===== UPDATE pos_nameTbl, pos_priceTbl, pos_picTbl =====
                pos_dbconnect.pos_sql = "UPDATE pos_nameTbl SET " +
                "name1 = '" + nameTxtbox1.Text + "', name2 = '" + nameTxtbox2.Text + "', name3 = '" + nameTxtbox3.Text + "', name4 = '" + nameTxtbox4.Text + "', name5 = '" + nameTxtbox5.Text + "', " +
                "name6 = '" + nameTxtbox6.Text + "', name7 = '" + nameTxtbox7.Text + "', name8 = '" + nameTxtbox8.Text + "', name9 = '" + nameTxtbox9.Text + "', name10 = '" + nameTxtbox10.Text + "', " +
                "name11 = '" + nameTxtbox11.Text + "', name12 = '" + nameTxtbox12.Text + "', name13 = '" + nameTxtbox13.Text + "', name14 = '" + nameTxtbox14.Text + "', name15 = '" + nameTxtbox15.Text + "', " +
                "name16 = '" + nameTxtbox16.Text + "', name17 = '" + nameTxtbox17.Text + "', name18 = '" + nameTxtbox18.Text + "', name19 = '" + nameTxtbox19.Text + "', name20 = '" + nameTxtbox20.Text + "' " +
                "WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterUpdate();

                pos_dbconnect.pos_sql = "UPDATE pos_picTbl SET " +
                    "pic1 = '" + picpathTxtbox1.Text + "', pic2 = '" + picpathTxtbox2.Text + "', pic3 = '" + picpathTxtbox3.Text + "', pic4 = '" + picpathTxtbox4.Text + "', pic5 = '" + picpathTxtbox5.Text + "', " +
                    "pic6 = '" + picpathTxtbox6.Text + "', pic7 = '" + picpathTxtbox7.Text + "', pic8 = '" + picpathTxtbox8.Text + "', pic9 = '" + picpathTxtbox9.Text + "', pic10 = '" + picpathTxtbox10.Text + "', " +
                    "pic11 = '" + picpathTxtbox11.Text + "', pic12 = '" + picpathTxtbox12.Text + "', pic13 = '" + picpathTxtbox13.Text + "', pic14 = '" + picpathTxtbox14.Text + "', pic15 = '" + picpathTxtbox15.Text + "', " +
                    "pic16 = '" + picpathTxtbox16.Text + "', pic17 = '" + picpathTxtbox17.Text + "', pic18 = '" + picpathTxtbox18.Text + "', pic19 = '" + picpathTxtbox19.Text + "', pic20 = '" + picpathTxtbox20.Text + "' " +
                    "WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterUpdate();

                pos_dbconnect.pos_sql = "UPDATE pos_priceTbl SET " +
                    "price1 = '" + priceTxtbox1.Text + "', price2 = '" + priceTxtbox2.Text + "', price3 = '" + priceTxtbox3.Text + "', price4 = '" + priceTxtbox4.Text + "', price5 = '" + priceTxtbox5.Text + "', " +
                    "price6 = '" + priceTxtbox6.Text + "', price7 = '" + priceTxtbox7.Text + "', price8 = '" + priceTxtbox8.Text + "', price9 = '" + priceTxtbox9.Text + "', price10 = '" + priceTxtbox10.Text + "', " +
                    "price11 = '" + priceTxtbox11.Text + "', price12 = '" + priceTxtbox12.Text + "', price13 = '" + priceTxtbox13.Text + "', price14 = '" + priceTxtbox14.Text + "', price15 = '" + priceTxtbox15.Text + "', " +
                    "price16 = '" + priceTxtbox16.Text + "', price17 = '" + priceTxtbox17.Text + "', price18 = '" + priceTxtbox18.Text + "', price19 = '" + priceTxtbox19.Text + "', price20 = '" + priceTxtbox20.Text + "' " +
                    "WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterUpdate();

                // ===== REFRESH DataGridView =====
                pos_dbconnect.pos_select();
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();

                gridView.DataSource = pos_dbconnect.pos_sql_dataset.Tables[0];

                // ===== CLEAR INPUTS =====
                cleartextboxes();

                MessageBox.Show("Record successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // DELETE BUTTON
            try
            {
                // ===== DELETE from pos_nameTbl, pos_priceTbl, pos_picTbl =====
                pos_dbconnect.pos_sql = "DELETE FROM pos_nameTbl WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterDelete();

                pos_dbconnect.pos_sql = "DELETE FROM pos_picTbl WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterDelete();

                pos_dbconnect.pos_sql = "DELETE FROM pos_priceTbl WHERE pos_id = '" + comboBox1.Text + "'";
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterDelete();

                // ===== REFRESH DataGridView =====
                pos_dbconnect.pos_select();
                pos_dbconnect.pos_cmd();
                pos_dbconnect.pos_sqladapterSelect();
                pos_dbconnect.pos_sqldatasetSELECT();
                gridView.DataSource = pos_dbconnect.pos_sql_dataset.Tables[0];

                // ===== CLEAR INPUTS =====
                cleartextboxes();
                MessageBox.Show("Record successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administrator!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open_file_image();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            picpathTxtbox1.Text = openFileDialog1.FileName;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            open_file_image();
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            picpathTxtbox2.Text = openFileDialog1.FileName;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cleartextboxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
