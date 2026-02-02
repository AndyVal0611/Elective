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
    public partial class POS1 : Form
    {
        // instantiate the pos_dbconnection, Price_Item_Value, and Variables classes
        pos_dbconnection posdb_connect = new pos_dbconnection();
        Price_Item_Value price_item_value = new Price_Item_Value();
        Variables variables = new Variables();
        POSLogic posLogic = new POSLogic(); // additional: instantiate POSLogic class
        public POS1()
        {
            // establish connection from C# forms to the SQL Server database
            posdb_connect.pos_connString();
            InitializeComponent();
        }

        private void quantityTxtbox()
        {
            // focuses the quantity textbox and clears its content
            qty_txtbox.Clear();
            qty_txtbox.Focus();
        }

        private void quantity_price_Convert()
        { // converts the quantity and price from string to numeric values
            variables.quantity = Convert.ToInt32(qty_txtbox.Text);
            variables.price = Convert.ToDouble(priceTxtbox.Text);
        }

        private void computation_Formula_and_DisplayData()
        {
            double gross = variables.quantity * variables.price;
            // Ang variables.discount_amt ay dapat value (hal. 30.00), hindi percentage.
            variables.discounted_amt = gross - variables.discount_amt;
            discount_txtbox.Text = variables.discount_amt.ToString("n2");
            discounted_txtbox.Text = variables.discounted_amt.ToString("n2");
        }

        public void GetPriceItemValue()
        {
            // gets the price and item name from the Price_Item_Value class and display it in the textboxes
            itemnameTxtbox.Text = (price_item_value.GetItemName());
            priceTxtbox.Text = (price_item_value.GetPrice());
        }

        private void cleartextboxes()
        {
            // clears the textboxes after saving the transaction
            itemnameTxtbox.Clear();
            priceTxtbox.Clear();
            qty_txtbox.Clear();
            discount_txtbox.Clear();
            discounted_txtbox.Clear();
            totalqty_txtbox.Clear();
            totaldiscg_txtbox.Clear();
            totaldiscamt_txtbox.Clear();
            cashrendered_txtbox.Clear();
            changetxtbox.Clear();
            qty_txtbox.Focus();
        }

        private void LoadPOS_ID_ComboBox()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                posdb_connect.pos_sql =
                    "SELECT DISTINCT pos_id FROM pos_nameTbl WHERE pos_id IS NOT NULL";

                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterSelect();
                posdb_connect.pos_sqldatasetSELECT();

                DataTable dt = posdb_connect.pos_sql_dataset.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["pos_id"].ToString());
                }

                // auto select first item
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading POS ID:\n" + ex.Message);
            }
        }

        private void POS1_Load(object sender, EventArgs e)
        {
            // existing code mo...
            LoadPOS_ID_ComboBox();

            // disable textboxes
            itemnameTxtbox.Enabled = false;
            priceTxtbox.Enabled = false;
            discounted_txtbox.Enabled = false;
            totalqty_txtbox.Enabled = false;
            totaldiscg_txtbox.Enabled = false;
            totaldiscamt_txtbox.Enabled = false;
            changetxtbox.Enabled = false;
            discount_txtbox.Enabled = false;

            // codes for hiding pic locations
            // code for hiding the picture location of the image thrown inside the textboxes
            picpathTxtbox1.Hide(); picpathTxtbox2.Hide(); picpathTxtbox3.Hide(); picpathTxtbox4.Hide(); picpathTxtbox5.Hide();
            picpathTxtbox6.Hide(); picpathTxtbox7.Hide(); picpathTxtbox8.Hide(); picpathTxtbox9.Hide(); picpathTxtbox10.Hide();
            picpathTxtbox11.Hide(); picpathTxtbox12.Hide(); picpathTxtbox13.Hide(); picpathTxtbox14.Hide(); picpathTxtbox15.Hide();
            picpathTxtbox16.Hide(); picpathTxtbox17.Hide(); picpathTxtbox18.Hide(); picpathTxtbox19.Hide(); picpathTxtbox20.Hide();

            // codes for retrieving data from the database and display it in the interface objects
            posdb_connect.pos_select_cashier();
            posdb_connect.pos_cmd();
            posdb_connect.pos_sqladapterSelect();
            posdb_connect.pos_sqldatasetSELECT();

            // codes for throwing data from tables inside the database to the textboxes
            name1lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][2].ToString();
            name2lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][3].ToString();
            name3lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][4].ToString();
            name4lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][5].ToString();
            name5lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][6].ToString();
            name10lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][7].ToString();
            name9lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][8].ToString();
            name8lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][9].ToString();
            name7lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][10].ToString();
            name6lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][11].ToString();
            name15lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][12].ToString();
            name14lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][13].ToString();
            name13lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][14].ToString();
            name12lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][15].ToString();
            name11lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][16].ToString();
            name16lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][17].ToString();
            name17lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][18].ToString();
            name18lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][19].ToString();
            name19lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][20].ToString();
            name20lbl.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][21].ToString();

            picpathTxtbox1.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][24].ToString();
            pictureBox1.Image = Image.FromFile(picpathTxtbox1.Text);

            picpathTxtbox2.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][25].ToString();
            pictureBox2.Image = Image.FromFile(picpathTxtbox2.Text);

            picpathTxtbox3.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][26].ToString();
            pictureBox3.Image = Image.FromFile(picpathTxtbox3.Text);

            picpathTxtbox4.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][27].ToString();
            pictureBox4.Image = Image.FromFile(picpathTxtbox4.Text);

            picpathTxtbox5.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][28].ToString();
            pictureBox5.Image = Image.FromFile(picpathTxtbox5.Text);

            picpathTxtbox6.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][29].ToString();
            pictureBox6.Image = Image.FromFile(picpathTxtbox6.Text);

            picpathTxtbox7.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][30].ToString();
            pictureBox7.Image = Image.FromFile(picpathTxtbox7.Text);

            picpathTxtbox8.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][31].ToString();
            pictureBox8.Image = Image.FromFile(picpathTxtbox8.Text);

            picpathTxtbox9.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][32].ToString();
            pictureBox9.Image = Image.FromFile(picpathTxtbox9.Text);

            picpathTxtbox10.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][33].ToString();
            pictureBox10.Image = Image.FromFile(picpathTxtbox10.Text);

            picpathTxtbox11.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][34].ToString();
            pictureBox11.Image = Image.FromFile(picpathTxtbox11.Text);

            picpathTxtbox12.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][35].ToString();
            pictureBox12.Image = Image.FromFile(picpathTxtbox12.Text);

            picpathTxtbox13.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][36].ToString();
            pictureBox13.Image = Image.FromFile(picpathTxtbox13.Text);

            picpathTxtbox14.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][37].ToString();
            pictureBox14.Image = Image.FromFile(picpathTxtbox14.Text);

            picpathTxtbox15.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][38].ToString();
            pictureBox15.Image = Image.FromFile(picpathTxtbox15.Text);

            picpathTxtbox16.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][39].ToString();
            pictureBox16.Image = Image.FromFile(picpathTxtbox16.Text);

            picpathTxtbox17.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][40].ToString();
            pictureBox17.Image = Image.FromFile(picpathTxtbox17.Text);

            picpathTxtbox18.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][41].ToString();
            pictureBox18.Image = Image.FromFile(picpathTxtbox18.Text);

            picpathTxtbox19.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][42].ToString();
            pictureBox19.Image = Image.FromFile(picpathTxtbox19.Text);

            picpathTxtbox20.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][43].ToString();
            pictureBox20.Image = Image.FromFile(picpathTxtbox20.Text);

            pricelbl1.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][46].ToString();
            pricelbl2.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][47].ToString();
            pricelbl3.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][48].ToString();
            pricelbl4.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][49].ToString();
            pricelbl5.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][50].ToString();
            pricelbl6.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][51].ToString();
            pricelbl7.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][52].ToString();
            pricelbl8.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][53].ToString();
            pricelbl9.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][54].ToString();
            pricelbl10.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][55].ToString();
            pricelbl11.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][56].ToString();
            pricelbl12.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][57].ToString();
            pricelbl13.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][58].ToString();
            pricelbl14.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][59].ToString();
            pricelbl15.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][60].ToString();
            pricelbl16.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][61].ToString();
            pricelbl17.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][62].ToString();
            pricelbl18.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][63].ToString();
            pricelbl19.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][64].ToString();
            pricelbl20.Text =
                posdb_connect.pos_sql_dataset.Tables[0].Rows[0][65].ToString();

            //codes for retrieving data from the database and display it in the interface objects
            posdb_connect.pos_select_cashier_display();
            posdb_connect.pos_cmd();
            posdb_connect.pos_sqladapterSelect();
            posdb_connect.pos_select_cashier_SELECTdisplay();

            if (posdb_connect.pos_sql_dataset.Tables.Count > 0 &&
            posdb_connect.pos_sql_dataset.Tables[0].Rows.Count > 0)
            {
                DataRow cashier = posdb_connect.pos_sql_dataset.Tables[0].Rows[0];

                terminal_noLbl.Text = cashier[3].ToString();
                emp_idLbl.Text = cashier[0].ToString();
                emp_fname.Text = cashier[1].ToString();
                emp_surname.Text = cashier[2].ToString();
            }
            else
            {
                MessageBox.Show("No cashier data found.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Double-click the Enter button to save the transaction to the database from the radio button selection
            try
            {
                string selectedDiscount = "";
                if (radioButton1.Checked) selectedDiscount = radioButton1.Text;
                else if (radioButton2.Checked) selectedDiscount = radioButton2.Text;
                else if (radioButton3.Checked) selectedDiscount = radioButton3.Text;
                else if (radioButton4.Checked) selectedDiscount = radioButton4.Text;

                if (string.IsNullOrEmpty(selectedDiscount))
                {
                    MessageBox.Show("Please select a discount option.");
                    return;
                }

                // Isang INSERT query lang para sa lahat ng cases
                posdb_connect.pos_sql = "INSERT INTO salesTbl (product_name, product_quantity_per_transaction, product_price, " +
                    "discount_option, discount_amount_per_transaction, discounted_amount_per_transaction, " +
                    "summary_total_quantity, summary_total_disc_given, summary_total_discounted_amount, " +
                    "terminal_no, time_date, emp_id) VALUES ('"
                    + itemnameTxtbox.Text + "', '" + qty_txtbox.Text + "', '" + priceTxtbox.Text + "', '"
                    + selectedDiscount + "', '" + discount_txtbox.Text + "', '" + discounted_txtbox.Text + "', '"
                    + totalqty_txtbox.Text + "', '" + totaldiscg_txtbox.Text + "', '" + totaldiscamt_txtbox.Text + "', '"
                    + terminal_noLbl.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + emp_idLbl.Text + "')";

                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterInsert();

                MessageBox.Show("Transaction Saved!");

                // Ipakita ang Receipt
                var receiptForm = new POS1Print(
                    itemnameTxtbox.Text, priceTxtbox.Text, qty_txtbox.Text,
                    discount_txtbox.Text, discounted_txtbox.Text, totalqty_txtbox.Text,
                    totaldiscg_txtbox.Text, totaldiscamt_txtbox.Text, changetxtbox.Text
                );
                receiptForm.ShowDialog();

                cleartextboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                quantity_price_Convert(); // Converts inputs to numeric
                variables.discount_amt = (variables.quantity * variables.price) * 0.30; // 30% discount
                computation_Formula_and_DisplayData();

                // Uncheck other options [cite: 12]
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Input is invalid");
                quantityTxtbox();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                quantity_price_Convert();
                variables.discount_amt = (variables.quantity * variables.price) * 0.10; // 10% discount [cite: 15]
                computation_Formula_and_DisplayData();

                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Input is invalid");
                quantityTxtbox();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                quantity_price_Convert();
                variables.discount_amt = (variables.quantity * variables.price) * 0.15; // 15% discount [cite: 18]
                computation_Formula_and_DisplayData();

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid data input in quantity");
                quantityTxtbox();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                variables.discount_amt = (variables.quantity * variables.price) * 0; // no discount [cite: 18]
                computation_Formula_and_DisplayData();

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid data input in quantity");
                quantityTxtbox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int qtyInput = Convert.ToInt32(qty_txtbox.Text);
                double discountInput = Convert.ToDouble(discount_txtbox.Text);
                double discountedInput = Convert.ToDouble(discounted_txtbox.Text);

                posLogic.AccumulateTotals(qtyInput, discountInput, discountedInput, totalqty_txtbox, totaldiscg_txtbox, totaldiscamt_txtbox, cashrendered_txtbox, changetxtbox);
            }
            catch (Exception)
            {
                MessageBox.Show("Error computing totals");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name1lbl.Text, pricelbl1.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name2lbl.Text, pricelbl2.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name3lbl.Text, pricelbl3.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name4lbl.Text, pricelbl4.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name5lbl.Text, pricelbl5.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name6lbl.Text, pricelbl6.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name7lbl.Text, pricelbl7.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name8lbl.Text, pricelbl8.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name9lbl.Text, pricelbl9.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name10lbl.Text, pricelbl10.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name11lbl.Text, pricelbl11.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name12lbl.Text, pricelbl12.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name13lbl.Text, pricelbl13.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name14lbl.Text, pricelbl14.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name15lbl.Text, pricelbl15.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name16lbl.Text, pricelbl16.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name17lbl.Text, pricelbl17.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name18lbl.Text, pricelbl18.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name19lbl.Text, pricelbl19.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue(name20lbl.Text, pricelbl20.Text);
            GetPriceItemValue();
            quantityTxtbox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleartextboxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cleartextboxes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string selectedPOS_ID = comboBox1.SelectedItem.ToString();

            // TEST ONLY – remove later if you want
            MessageBox.Show("Selected POS ID: " + selectedPOS_ID);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                string searchPosID = comboBox1.Text;

                if (string.IsNullOrEmpty(searchPosID))
                {
                    MessageBox.Show("Please select or enter a POS ID to search.");
                    return;
                }

                // Isang query para makuha lahat (Names, Pics, Prices)
                posdb_connect.pos_sql =
                    "SELECT * FROM pos_nameTbl " +
                    "INNER JOIN pos_picTbl ON pos_nameTbl.pos_id = pos_picTbl.pos_id " +
                    "INNER JOIN pos_priceTbl ON pos_nameTbl.pos_id = pos_priceTbl.pos_id " +
                    "WHERE pos_nameTbl.pos_id = '" + searchPosID + "'";

                posdb_connect.pos_cmd();
                posdb_connect.pos_sqladapterSelect();
                posdb_connect.pos_sqldatasetSELECT();

                if (posdb_connect.pos_sql_dataset.Tables.Count > 0 &&
                    posdb_connect.pos_sql_dataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = posdb_connect.pos_sql_dataset.Tables[0].Rows[0];

                    for (int i = 1; i <= 20; i++)
                    {
                        // 1. UPDATE NAMES (name1lbl, name2lbl...)
                        var label = this.Controls.Find("name" + i + "lbl", true).FirstOrDefault() as Label;
                        if (label != null) label.Text = row[i + 1].ToString();

                        // 2. UPDATE PICTURES (pictureBox1, pictureBox2...)
                        var pb = this.Controls.Find("pictureBox" + i, true).FirstOrDefault() as PictureBox;
                        if (pb != null)
                        {
                            string path = row[i + 23].ToString();
                            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                            {
                                pb.Image = Image.FromFile(path);
                                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else pb.Image = null;
                        }

                        // 3. UPDATE PRICES (pricelbl1, pricelbl2...)
                        // IMPORTANT: Siguraduhin na "pricelbl" ang Name ng labels mo sa Designer
                        var priceLabel = this.Controls.Find("pricelbl" + i, true).FirstOrDefault() as Label;
                        if (priceLabel != null)
                        {
                            // i + 45 logic: i=1 (46), i=2 (47)... base sa SQL join result mo
                            priceLabel.Text = row[i + 45].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data found for POS ID: " + searchPosID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}