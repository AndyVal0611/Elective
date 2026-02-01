using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Activity6;

namespace DSAL_Prelim
{
    public partial class POS2Database : Form
    {

        pos_dbconnection posdb_connect = new pos_dbconnection();
        Variables variables = new Variables();
        Price_Item_Value price_discountamount_value = new Price_Item_Value();

        // setting the values
        Double currentPrice = 0;
        Double currentDiscount = 0;

        public POS2Database()
        {
            posdb_connect.pos_connString();
            InitializeComponent();
        }

        private void quantityTxtbox()
        {
            qtyTextBox.Text = "0";
            qtyTextBox.Focus();
        }

        private void GetPriceDiscountAmount()
        {
            priceTextBox.Text = (price_discountamount_value.GetPriceItem());
            discountAmt_TextBox.Text = (price_discountamount_value.GetDiscountAmount());
            variables.price = Convert.ToDouble(priceTextBox.Text);
        }

        // ================= UPDATE TOTALS =================
        private void UpdateTotals()
        {
            // 1. Reset totals
            variables.qty_total = 0;
            variables.total_amountPaid = 0;

            // 2. Loop through all 20 items
            for (int i = 1; i <= 20; i++)
            {
                // Find CheckBox and Price Label dynamically
                CheckBox chk = this.Controls.Find("checkBox" + i, true).FirstOrDefault() as CheckBox;

                Label lblPrice = this.Controls.Find("pricelbl" + i, true).FirstOrDefault() as Label;

                // If checked, add to totals
                if (chk != null && chk.Checked && lblPrice != null)
                {
                    double priceValue;

                    if (double.TryParse(lblPrice.Text, out priceValue))
                    {
                        variables.qty_total += 1;
                        variables.total_amountPaid += priceValue;
                    }
                }
            }

            // 3. Display totals
            totalQty_TextBox.Text = variables.qty_total.ToString();
            totalBills_TextBox.Text = variables.total_amountPaid.ToString("n");
        }


        private void LoadPOS_ID_ComboBox()
        {
            // loading POS ID from the database to the combobox
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

        private void POS2Database_Load(object sender, EventArgs e)
        {
            try
            {
                // loading the POS ID combobox
                LoadPOS_ID_ComboBox();

                // disabling textboxes
                priceTextBox.Enabled = false;
                discountedAmt_TextBox.Enabled = false;
                changeTextBox.Enabled = false;
                totalBills_TextBox.Enabled = false;
                discountAmt_TextBox.Enabled = false;
                totalQty_TextBox.Enabled = false;

                posdb_connect.pos_select_cashier1(); posdb_connect.pos_cmd(); posdb_connect.pos_sqladapterSelect(); posdb_connect.pos_sqldatasetSELECT();

                checkBox1.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][2].ToString(); checkBox2.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][3].ToString();
                checkBox3.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][4].ToString(); checkBox4.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][5].ToString();
                checkBox5.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][6].ToString(); checkBox6.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][7].ToString();
                checkBox7.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][8].ToString(); checkBox8.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][9].ToString();
                checkBox9.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][10].ToString(); checkBox10.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][11].ToString();
                checkBox11.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][12].ToString(); checkBox12.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][13].ToString();
                checkBox13.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][14].ToString(); checkBox14.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][15].ToString();
                checkBox15.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][16].ToString(); checkBox16.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][17].ToString();
                checkBox17.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][18].ToString(); checkBox18.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][19].ToString();
                checkBox19.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][20].ToString(); checkBox20.Text = posdb_connect.pos_sql_dataset.Tables[0].Rows[0][21].ToString();

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

                // code for hiding the picture location of the image thrown inside the textboxes
                picpathTxtbox1.Hide(); picpathTxtbox2.Hide(); picpathTxtbox3.Hide(); picpathTxtbox4.Hide(); picpathTxtbox5.Hide();
                picpathTxtbox6.Hide(); picpathTxtbox7.Hide(); picpathTxtbox8.Hide(); picpathTxtbox9.Hide(); picpathTxtbox10.Hide();
                picpathTxtbox11.Hide(); picpathTxtbox12.Hide(); picpathTxtbox13.Hide(); picpathTxtbox14.Hide(); picpathTxtbox15.Hide();
                picpathTxtbox16.Hide(); picpathTxtbox17.Hide(); picpathTxtbox18.Hide(); picpathTxtbox19.Hide(); picpathTxtbox20.Hide();

                // codes to uncheck all the checkboxes
                A_FriedChickenCheckBox.Checked = false;
                A_FriesCheckBox.Checked = false;
                A_CokeCheckBox.Checked = false;
                A_SideDishCheckBox.Checked = false;
                A_SpecialPizzaCheckBox.Checked = false;
                B_HalohaloCheckBox.Checked = false;
                B_ChickenCheckBox.Checked = false;
                B_CarbonaraCheckBox.Checked = false;
                B_FriesCheckBox.Checked = false;
                B_HawaiianCheckBox.Checked = false;
            }

            catch (Exception)
            {
                MessageBox.Show("Error occur during the loading of the application. Kindly contact your administrator");
            }


        }

        // checking each checkboxes if checked or not
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl1.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox1.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(1)");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl2.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox2.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(2)");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl3.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox3.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(3)");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl4.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox4.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(4)");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl5.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox5.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(5)");
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl6.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox10.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(6)");
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl7.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox9.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(7)");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl8.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox7.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(8)");
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl9.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox8.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(9)");
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl10.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox6.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(10)");
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl11.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox15.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(11)");
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl12.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox14.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(12)");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl13.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox12.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(13)");
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl14.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox13.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(14)");
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl15.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox11.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(15)");
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl16.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox20.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(16)");
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl17.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox19.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(17)");
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl18.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox17.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(18)");
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl19.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox18.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(19)");
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                price_discountamount_value.SetPriceDiscountAmountValue("0.00", pricelbl20.Text);
                GetPriceDiscountAmount();
                quantityTxtbox();
                displayListbox.Items.Add(checkBox16.Text + "" + priceTextBox.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area of the application. Kindly contact your administrator!(20)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close the POS form
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Calculate Total Bills
            try
            {
                // get cash
                variables.cash_given = Convert.ToDouble(cashgiven_TextBox.Text);

                // FINAL amount to pay (galing sa qty + discount computation)
                variables.total_amountPaid = variables.discounted_amt;

                // compute change
                variables.change = variables.cash_given - variables.total_amountPaid;

                if (variables.change < 0)
                {
                    MessageBox.Show("Insufficient cash.");
                    return;
                }

                // display
                changeTextBox.Text = variables.change.ToString("n");

                displayListbox.Items.Add("Total Bills:              " + variables.total_amountPaid.ToString("n"));
                displayListbox.Items.Add("Cash Given:               " + variables.cash_given.ToString("n"));
                displayListbox.Items.Add("Change:                   " + changeTextBox.Text);
                displayListbox.Items.Add("Total No. of Items:       " + totalQty_TextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid cash amount.");
            }
        }

        private void foodARdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!foodARdbtn.Checked) return;

            this.BackColor = Color.LightSalmon;
            foodBRdbtn.Checked = false;

            // bundle A items
            A_CokeCheckBox.Checked = true;
            A_FriedChickenCheckBox.Checked = true;
            A_FriesCheckBox.Checked = true;
            A_SideDishCheckBox.Checked = true;
            A_SpecialPizzaCheckBox.Checked = true;

            // uncheck bundle B
            B_HalohaloCheckBox.Checked = false;
            B_ChickenCheckBox.Checked = false;
            B_CarbonaraCheckBox.Checked = false;
            B_FriesCheckBox.Checked = false;
            B_HawaiianCheckBox.Checked = false;

            // base computation
            UpdateTotals();

            // discount for bundle A (10%)
            variables.discount_amt = variables.total_amountPaid * 0.10;

            // quantity
            if (string.IsNullOrWhiteSpace(qtyTextBox.Text))
                qtyTextBox.Text = "1";

            variables.quantity = Convert.ToInt32(qtyTextBox.Text);

            // final totals
            variables.amount_paid = variables.total_amountPaid * variables.quantity;
            variables.discounted_amt = variables.amount_paid - variables.discount_amt;

            // display
            priceTextBox.Text = variables.amount_paid.ToString("n");
            discountAmt_TextBox.Text = variables.discount_amt.ToString("n");
            discountedAmt_TextBox.Text = variables.discounted_amt.ToString("n");
            totalQty_TextBox.Text = variables.quantity.ToString();

            displayListbox.Items.Clear();
            displayListbox.Items.Add(foodARdbtn.Text + "   " + priceTextBox.Text);
            displayListbox.Items.Add("Discount Amount:   " + discountAmt_TextBox.Text);

            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\AndyVal0611\ActivityNo1\FoodBundleA.png");

            qtyTextBox.Focus();
        }

        private void foodBRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!foodBRdbtn.Checked) return;

            this.BackColor = Color.Salmon;
            foodARdbtn.Checked = false;

            // uncheck bundle A
            A_CokeCheckBox.Checked = false;
            A_FriedChickenCheckBox.Checked = false;
            A_FriesCheckBox.Checked = false;
            A_SideDishCheckBox.Checked = false;
            A_SpecialPizzaCheckBox.Checked = false;

            // bundle B items
            B_HalohaloCheckBox.Checked = true;
            B_ChickenCheckBox.Checked = true;
            B_CarbonaraCheckBox.Checked = true;
            B_FriesCheckBox.Checked = true;
            B_HawaiianCheckBox.Checked = true;

            // base computation
            UpdateTotals();

            // discount for bundle B (15%)
            variables.discount_amt = variables.total_amountPaid * 0.15;

            // quantity
            if (string.IsNullOrWhiteSpace(qtyTextBox.Text))
                qtyTextBox.Text = "1";

            variables.quantity = Convert.ToInt32(qtyTextBox.Text);

            // final totals
            variables.amount_paid = variables.total_amountPaid * variables.quantity;
            variables.discounted_amt = variables.amount_paid - variables.discount_amt;

            // display
            priceTextBox.Text = variables.amount_paid.ToString("n");
            discountAmt_TextBox.Text = variables.discount_amt.ToString("n");
            discountedAmt_TextBox.Text = variables.discounted_amt.ToString("n");
            totalQty_TextBox.Text = variables.quantity.ToString();

            displayListbox.Items.Clear();
            displayListbox.Items.Add(foodBRdbtn.Text + "   " + priceTextBox.Text);
            displayListbox.Items.Add("Discount Amount:   " + discountAmt_TextBox.Text);

            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\AndyVal0611\ActivityNo1\FoodBundleB.png");

            qtyTextBox.Focus();
        }

        private void qtyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(qtyTextBox.Text))
                return;

            int qty;

            if (!int.TryParse(qtyTextBox.Text, out qty))
            {
                qtyTextBox.Text = "1";
                qtyTextBox.SelectionStart = qtyTextBox.Text.Length;
                return;
            }

            if (qty <= 0)
            {
                qty = 1;
                qtyTextBox.Text = "1";
            }

            // store quantity
            variables.quantity = qty;

            // compute total amount with quantity
            variables.amount_paid = variables.total_amountPaid * variables.quantity;

            // subtract discount
            variables.discounted_amt = variables.amount_paid - variables.discount_amt;

            // display
            totalQty_TextBox.Text = variables.quantity.ToString();
            totalBills_TextBox.Text = variables.amount_paid.ToString("n");
            discountedAmt_TextBox.Text = variables.discounted_amt.ToString("n");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Activity6_2 print = new Activity6_2(this.displayListbox.Items);
            // Displays the Form2
            print.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quantityTxtbox();
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

                // Query: Name + Picture + Price tables
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
                        // 1️⃣ UPDATE CHECKBOX TEXT (Item Names)
                        CheckBox chk = this.Controls.Find("checkBox" + i, true).FirstOrDefault() as CheckBox;

                        if (chk != null)
                        {
                            chk.Text = row[i + 1].ToString(); // name1 → name20
                            chk.Checked = false;
                        }

                        // 2️⃣ UPDATE PICTURES
                        PictureBox pb = this.Controls.Find("pictureBox" + i, true).FirstOrDefault() as PictureBox;

                        if (pb != null)
                        {
                            string path = row[i + 23].ToString(); // pic1 → pic20

                            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                            {
                                pb.Image = Image.FromFile(path);
                                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                pb.Image = null;
                            }
                        }

                        // 3️⃣ UPDATE PRICE LABELS
                        Label priceLabel = this.Controls.Find("pricelbl" + i, true).FirstOrDefault() as Label;

                        if (priceLabel != null)
                        {
                            priceLabel.Text = row[i + 45].ToString(); // price1 → price20
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

        private void button6_Click(object sender, EventArgs e)
        {
            // SUBMIT Button to save the POS Data in the database
            try
            {
                // 1. I-check muna kung may laman ang listbox bago i-save
                if (displayListbox.Items.Count == 0)
                {
                    MessageBox.Show("No transactions were saved.");
                    return;
                }

                // 2. I-prepare ang SQL Insert statement. 
                // Siguraduhin na ang column names (product_name, total_qty, etc.) ay tugma sa iyong actual database table.
                posdb_connect.pos_sql = "INSERT INTO salesTbl (product_name, product_quantity, product_price, " +
                    "discount_amount, discounted_amount, total_bill, transaction_date) " +
                    "VALUES ('"
                    + (foodARdbtn.Checked ? foodARdbtn.Text : foodBRdbtn.Text) + "', '"
                    + totalQty_TextBox.Text + "', '"
                    + priceTextBox.Text + "', '"
                    + discountAmt_TextBox.Text + "', '"
                    + discountedAmt_TextBox.Text + "', '"
                    + totalBills_TextBox.Text + "', '"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                // 3. I-execute ang command [cite: 201]
                posdb_connect.pos_cmd();
                MessageBox.Show("Successfully saved in the database!");

                // 4. Optional: I-clear ang form pagkatapos i-save
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Helper method para i-reset ang UI
        private void ClearForm()
        {
            displayListbox.Items.Clear();
            qtyTextBox.Text = "0";
            cashgiven_TextBox.Clear();
            changeTextBox.Clear();
            totalBills_TextBox.Clear();
            discountAmt_TextBox.Clear();
            discountedAmt_TextBox.Clear();
            totalQty_TextBox.Clear();

            // Uncheck bundles
            foodARdbtn.Checked = false;
            foodBRdbtn.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foodARdbtn.Checked = false;
            foodBRdbtn.Checked = false;
            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\AndyVal0611\ActivityNo1\DSAL_Prelim\ActivityNo1\TCF.png");

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    cb.Checked = false;
                }
            }

            priceTextBox.Clear();
            qtyTextBox.Clear();
            displayListbox.Items.Clear();
        }
    }
}