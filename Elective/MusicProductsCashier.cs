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
    public partial class MusicProductsCashier : Form
    {
        // Connection string based on your SQL Server screenshot
        private string connectionString = @"Data Source=LAPTOP-JLQMV6PN\SQLEXPRESS; Initial Catalog=MusicProductsDB; Integrated Security=True";
        string userRole;

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
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells[2].Value != null)
                    total += Convert.ToDecimal(row.Cells[2].Value);
            }
            lblTotal.Text = "₱" + total.ToString("N2");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Walang laman ang cart!", "System Message");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to checkout?", "Confirm Purchase", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dgvCart.Rows)
                            {
                                if (row.Cells["Barcode"].Value != null)
                                {
                                    // FIXED: Kinuha ang values mula sa kasalukuyang 'row' sa loop
                                    string barcode = row.Cells["Barcode"].Value.ToString();
                                    string albumName = row.Cells["AlbumName"].Value.ToString();
                                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                                    // 1. UPDATE Inventory
                                    string updateQuery = "UPDATE MusicAlbums SET Quantity = Quantity - 1 WHERE Barcode = @Barcode";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Barcode", barcode);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    // 2. INSERT Sales Record
                                    string insertSql = @"INSERT INTO SalesTransactions (Barcode, AlbumName, Price, DateSold, SoldBy) 
                                                       VALUES (@barcode, @name, @price, GETDATE(), @user)";

                                    using (SqlCommand cmdInsert = new SqlCommand(insertSql, connection, transaction))
                                    {
                                        cmdInsert.Parameters.AddWithValue("@barcode", barcode);
                                        cmdInsert.Parameters.AddWithValue("@name", albumName);
                                        cmdInsert.Parameters.AddWithValue("@price", price);
                                        // DYNAMIC: Ito ang magre-reflect kung sino ang naka-login
                                        cmdInsert.Parameters.AddWithValue("@user", this.userRole);
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Checkout Successful! Recorded by: {this.userRole}", "Success");

                            dgvCart.Rows.Clear();
                            lblTotal.Text = "₱0.00";
                            txtScanReceiver.Focus();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error during transaction: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
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
    }
}
