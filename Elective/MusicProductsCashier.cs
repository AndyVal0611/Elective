using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elective
{
    public partial class MusicProductsCashier : Form
    {
        // Connection string based on your SQL Server screenshot
        private string connectionString = @"Data Source=LAPTOP-JLQMV6PN\SQLEXPRESS; Initial Catalog=MusicProductsDB; Integrated Security=True";
        string userRole;
        decimal grossTotal = 0;
        decimal finalTotal = 0;

        public MusicProductsCashier(string role)
        {
            InitializeComponent();
            this.userRole = role; // Dito papasok kung sino ang nag-login
        }

        private void MusicProductsCashier_Load(object sender, EventArgs e)
        {
            // Set up your DataGridView columns if you haven't in the Designer
            if (dgvCart.ColumnCount == 0)
            {
                dgvCart.Columns.Add("Barcode", "Barcode");
                dgvCart.Columns.Add("AlbumName", "Album Name");
                dgvCart.Columns.Add("Price", "Price");
            }
            txtScanReceiver.Focus();
        }

        public void ReceiveScannedBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                AddItemToCart(barcode);
            }
        }

        private void AddItemToCart(string barcode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Kunin ang info ng album base sa barcode
                    string sql = "SELECT AlbumName, Price, Quantity FROM MusicAlbums WHERE Barcode = @Barcode";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Barcode", barcode.Trim());
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int stock = Convert.ToInt32(reader["Quantity"]);

                            if (stock > 0)
                            {
                                // Dagdag sa DataGridView
                                string albumName = reader["AlbumName"].ToString();
                                string price = reader["Price"].ToString();

                                dgvCart.Rows.Add(barcode, albumName, price);

                                // Automatic Scroll sa pinakababa para makita yung bagong add
                                dgvCart.FirstDisplayedScrollingRowIndex = dgvCart.RowCount - 1;

                                CalculateTotal();
                            }
                            else
                            {
                                MessageBox.Show($"Out of stock na ang '{reader["AlbumName"]}'!", "Inventory Warning");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Barcode not found sa inventory! Check your records.", "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding to cart: " + ex.Message);
                }
            }
        }

        // Event for the text box at the top left where the cashier will scan the barcode
        private void txtScanReceiver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtScanReceiver.Text.Trim();
                if (!string.IsNullOrEmpty(barcode))
                {
                    AddItemToCart(barcode);
                }
                txtScanReceiver.Clear();
                e.SuppressKeyPress = true;
            }
        }


        private void CalculateTotal()
        {
            grossTotal = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells[2].Value != null)
                    grossTotal += Convert.ToDecimal(row.Cells[2].Value);
            }

            if (seniorradioButton2.Checked) // Senior/PWD: VAT-Exempt + 20% Off
            {
                decimal netOfVat = grossTotal / 1.12m;
                finalTotal = netOfVat * 0.80m;
            }
            else if (empradioButton3.Checked) // Employee: 25% Off
            {
                finalTotal = grossTotal * 0.75m;
            }
            else if (promoradioButton4.Checked) // Promo: 15% Off
            {
                finalTotal = grossTotal * 0.85m;
            }
            else // Regular
            {
                finalTotal = grossTotal;
            }

            lblTotal.Text = "₱" + finalTotal.ToString("N2");
        }

        // Re-calculate kapag nagpalit ng RadioButton
        private void Discount_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0) return;

            string discountType = "Regular";
            if (seniorradioButton2.Checked) discountType = "Senior/PWD";
            if (empradioButton3.Checked) discountType = "Employee";
            if (promoradioButton4.Checked) discountType = "Promo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // I-initialize ang Receipt Form bago ang loop
                        MusicProductsReceipt receiptForm = new MusicProductsReceipt();
                        receiptForm.priDisplaylistbox.Items.Add("      ODYSSEY MUSIC STORE");
                        receiptForm.priDisplaylistbox.Items.Add("--------------------------------");
                        receiptForm.priDisplaylistbox.Items.Add($"Date: {DateTime.Now.ToString("MM/dd/yyyy HH:mm")}");
                        receiptForm.priDisplaylistbox.Items.Add($"Cashier: {this.userRole}");
                        receiptForm.priDisplaylistbox.Items.Add("--------------------------------");

                        foreach (DataGridViewRow row in dgvCart.Rows)
                        {
                            if (row.Cells["Barcode"].Value == null) continue;

                            string barcode = row.Cells["Barcode"].Value.ToString();
                            string albumName = row.Cells["AlbumName"].Value.ToString();
                            decimal origPrice = Convert.ToDecimal(row.Cells["Price"].Value);

                            // Idagdag ang item sa receipt form
                            receiptForm.priDisplaylistbox.Items.Add($"{albumName.PadRight(15)} P{origPrice:N2}");

                            // 1. UPDATE Inventory
                            string updateSql = "UPDATE MusicAlbums SET Quantity = Quantity - 1 WHERE Barcode = @Barcode";
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@Barcode", barcode);
                                updateCmd.ExecuteNonQuery();
                            }

                            // 2. INSERT Sales Record
                            string insertSql = @"INSERT INTO SalesTransactions 
                                               (Barcode, AlbumName, Price, DateSold, SoldBy, DiscountType) 
                                               VALUES (@barcode, @name, @price, GETDATE(), @user, @dtype)";

                            using (SqlCommand cmdInsert = new SqlCommand(insertSql, connection, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@barcode", barcode);
                                cmdInsert.Parameters.AddWithValue("@name", albumName);
                                cmdInsert.Parameters.AddWithValue("@price", finalTotal); // Recorded price
                                cmdInsert.Parameters.AddWithValue("@user", this.userRole); //
                                cmdInsert.Parameters.AddWithValue("@dtype", discountType);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                        // Footer ng Receipt
                        receiptForm.priDisplaylistbox.Items.Add("--------------------------------");
                        receiptForm.priDisplaylistbox.Items.Add($"Discount: {discountType}");
                        receiptForm.priDisplaylistbox.Items.Add($"TOTAL DUE: {lblTotal.Text}");
                        receiptForm.priDisplaylistbox.Items.Add($"Cash:      P{textBox1.Text}");
                        receiptForm.priDisplaylistbox.Items.Add($"Change:    P{textBox2.Text}");
                        receiptForm.priDisplaylistbox.Items.Add("--------------------------------");
                        receiptForm.priDisplaylistbox.Items.Add("   Thank you for shopping!");

                        transaction.Commit();
                        // ITO ANG MAGPAPALABAS NG RESIBO BES!
                        receiptForm.Show();
                        MessageBox.Show("Transaction Successful!");
                        dgvCart.Rows.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
                        CalculateTotal();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // Double Click to Remove Item
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Remove this item from cart?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                    CalculateTotal(); // I-recompute ang total pagkabura
                }
            }
        }

        private void txtScanReceiver_TextChanged(object sender, EventArgs e)
        {

        }

        // calculate button
        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal cash))
            {
                if (cash >= finalTotal)
                {
                    decimal change = cash - finalTotal;
                    textBox2.Text = change.ToString("N2");
                }
                else
                {
                    MessageBox.Show("Insufficient Cash!");
                }
            }
        }

        // change textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void regradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void seniorradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void empradioButton3_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void promoradioButton4_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}
