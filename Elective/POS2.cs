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
    public partial class POS2 : Form
    {
        pos_dbconnection posdb_connect = new pos_dbconnection();
        Variables variables = new Variables();
        Price_Item_Value price_discountamount_value = new Price_Item_Value();

        /// setting the values
        Double currentPrice = 0;
        Double currentDiscount = 0;

        public POS2()
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

        private void POS2_Load(object sender, EventArgs e)
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
    }
}
