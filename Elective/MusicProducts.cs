using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.IO;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using System.Drawing.Text;

namespace Elective
{
    public partial class MusicProducts : Form
    {
        // Connection string base sa screenshot mo
        private string connectionString = @"Data Source=LAPTOP-JLQMV6PN\SQLEXPRESS; Initial Catalog=MusicProductsDB; Integrated Security=True";
        private string currentUserRole; // Default role kung i-run lang basta

        public MusicProducts(string role) // Constructor chaining para hindi maulit ang InitializeComponent
        {
            InitializeComponent();
            this.currentUserRole = role;
            ApplyRolePermissions();
            LoadInventory();
        }

        private void SetupEvents()
        {
            this.txtBarcode.TextChanged += this.txtBarcode_TextChanged;
            this.txtBarcode.KeyDown += this.txtBarcode_KeyDown;
            this.dgvInventory.CellClick += this.dgvInventory_CellClick;
        }

        private void MusicProducts_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        // DITO ANG LOGIC PARA SA PERMISSIONS
        private void ApplyRolePermissions()
        {
            // --- UNIVERSAL FUNCTIONS (Lahat pwedeng gumamit nito) ---
            txtSearch.Enabled = true;   // Search Bar
            txtBarcode.Enabled = true;  // Barcode Scanning
            button6.Enabled = true;     // CASHIER Button
            button3.Enabled = true;     // REFRESH Button

            if (currentUserRole == "Administrator")
            {
                // ADMIN: Lahat gumagana (Save, Update, Delete, Logout)
                button1.Enabled = true; // SAVE
                button5.Enabled = true; // UPDATE
                button4.Enabled = true; // DELETE
                button2.Enabled = false; // EXIT
                btnLogout.Visible = true; // KITA ang logout
            }
            else if (currentUserRole == "Cashier")
            {
                // CASHIER: Save ay gumagana, pero Update at Delete ay HINDI
                button1.Enabled = true;  // SAVE (Pwede siya magdagdag)
                button5.Enabled = false; // UPDATE (Disabled)
                button4.Enabled = false; // DELETE (Disabled)
                button2.Enabled = false;// EXIT (Disabled)
                btnLogout.Visible = true; // KITA pa rin ang logout
            }
            else // GUEST (O kapag direkta lang ni-run)
            {
                // GUEST: Search/Scan lang, bawal mag-modify at walang logout button
                button1.Enabled = false; // SAVE (Disabled)
                button5.Enabled = false; // UPDATE (Disabled)
                button4.Enabled = false; // DELETE (Disabled)
                btnLogout.Visible = false; // HINDI KITA ang logout
            }
        }
        

        public void LoadInventory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MusicAlbums", connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // Assuming your DataGridView on the right is named dataGridView1
                    dgvInventory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading inventory: " + ex.Message);
                }
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];

                // Populate textboxes from the clicked row
                txtBarcode.Text = row.Cells["Barcode"].Value.ToString();
                txtAlbumName.Text = row.Cells["AlbumName"].Value.ToString();
                txtArtist.Text = row.Cells["Artist"].Value.ToString();
                txtCategory.Text = row.Cells["Category"].Value.ToString();
                txtReleaseYear.Text = row.Cells["ReleaseYear"].Value.ToString();
                txtManufacturer.Text = row.Cells["Manufacturer"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                // DISPLAY ALBUM IMAGE MULA SA DATABASE
                if (row.Cells["AlbumImage"].Value != DBNull.Value)
                {
                    byte[] imgData = (byte[])row.Cells["AlbumImage"].Value;
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        pbAlbumImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbAlbumImage.Image = null;
                }
                // The barcode image will automatically update because txtBarcode_TextChanged is triggered
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string code = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(code)) return;

                // 1. Hanapin kung bukas na ang Cashier
                MusicProductsCashier cashier = (MusicProductsCashier)Application.OpenForms["MusicProductsCashier"];

                if (cashier == null || cashier.IsDisposed)
                {
                    cashier = new MusicProductsCashier();
                    cashier.Show(); // Dito lilitaw ang window nang kusa
                }
                else
                {
                    cashier.BringToFront();
                }

                // 2. Ipasa ang data sa cart
                cashier.ReceiveScannedBarcode(code);

                // 3. LINISIN ANG TEXTBOX agad para handa sa next scan
                txtBarcode.Clear();

                // 4. Pigilan ang "ding" sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtBarcode.Text))
                {
                    var writer = new BarcodeWriter<Bitmap>
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new EncodingOptions { Height = pictureBox1.Height, Width = pictureBox1.Width, Margin = 2 },
                        Renderer = new BitmapRenderer()
                    };
                    pictureBox1.Image = writer.Write(txtBarcode.Text.Trim());
                }
                else { pictureBox1.Image = null; }
            }
            catch { pictureBox1.Image = null; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtAlbumName.Text))
            {
                MessageBox.Show("Please fill in the Barcode and Album Name.", "Input Error");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // 1. CONVERT IMAGE TO BYTES (VARBINARY)
                    byte[] imageBytes = null;
                    if (pbAlbumImage.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Sine-save ang image sa memory stream para maging bytes
                            pbAlbumImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            imageBytes = ms.ToArray();
                        }
                    }

                    // 2. Updated SQL Query (Manufacturer & ReleaseYear included)
                    string sqlQuery = @"INSERT INTO MusicAlbums 
                (AlbumID, AlbumName, Artist, Category, Manufacturer, ReleaseYear, Quantity, Price, Barcode, AlbumImage, DateSaved) 
                VALUES (@AlbumID, @AlbumName, @Artist, @Category, @Manufacturer, @ReleaseYear, @Quantity, @Price, @Barcode, @AlbumImage, @DateSaved)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Set the AlbumID as the barcode entered in txtBarcode
                        command.Parameters.AddWithValue("@AlbumID", txtBarcode.Text.Trim());
                        command.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());

                        // Map other textboxes to parameters
                        command.Parameters.AddWithValue("@AlbumName", txtAlbumName.Text.Trim());
                        command.Parameters.AddWithValue("@Artist", txtArtist.Text.Trim());
                        command.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());

                        command.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text.Trim()); // Record Label
                        command.Parameters.AddWithValue("@ReleaseYear", txtReleaseYear.Text.Trim());

                        // Handle Quantity (Integer)
                        int quantity;
                        int.TryParse(txtQuantity.Text, out quantity);
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        // Handle Price (Decimal)
                        decimal price;
                        decimal.TryParse(txtPrice.Text, out price);
                        command.Parameters.AddWithValue("@Price", price);

                        // Automatically record the current date and time
                        command.Parameters.AddWithValue("@DateSaved", DateTime.Now);

                        // 3. IMAGE PARAMETER (DBNull kung walang napiling picture)
                        command.Parameters.Add("@AlbumImage", SqlDbType.VarBinary).Value = (object)imageBytes ?? DBNull.Value;

                        command.ExecuteNonQuery();

                        MessageBox.Show("Album record created successfully!");

                        LoadInventory(); // Refresh the grid to show the new record 
                        ClearFields();
                    }
                }
                catch (SqlException ex)
                {
                    // Error 2627 is for Primary Key / Unique Constraint violations
                    if (ex.Number == 2627)
                        MessageBox.Show("This Album ID/Barcode already exists in the database.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
            MessageBox.Show("Input cleared.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtBarcode.Clear();
            txtAlbumName.Clear();
            txtArtist.Clear();
            txtCategory.Clear();
            txtReleaseYear.Clear();
            txtManufacturer.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            pictureBox1.Image = null;
            pbAlbumImage.Image = null;
            txtBarcode.Focus(); // Balik cursor sa barcode field para sa next entry
        }

        private void pbAlbumImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbAlbumImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Gagamit tayo ng LIKE operator para mahanap ang kahit anong kaparehong letra
                    // Hahanap ito sa AlbumName, Artist, o Barcode
                    string sqlQuery = @"SELECT * FROM MusicAlbums 
                   WHERE AlbumName LIKE @search 
                   OR Artist LIKE @search 
                   OR Barcode LIKE @search 
                   OR Manufacturer LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        // Ang '%' ay wildcard para mahanap ang text kahit nasa gitna o dulo
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text.Trim() + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInventory.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search Error: " + ex.Message);
                }
            }
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tinitignan natin kung ang column na pino-process ay "Quantity"
            if (dgvInventory.Columns[e.ColumnIndex].Name == "Quantity")
            {
                if (e.Value != null)
                {
                    int qty = Convert.ToInt32(e.Value);

                    if (qty == 0)
                    {
                        // Gagawing pula ang buong row kapag 0 ang stock
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (qty <= 5)
                    {
                        // Bonus: Dilaw naman kapag "Critical Stock" na (5 pababa)
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        // Ibalik sa puti/default kung sapat ang stock
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // UPDATE
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Please select a record to update first.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Gagamitin natin ang UPDATE command base sa Barcode
                    string sqlQuery = @"UPDATE MusicAlbums SET 
                                AlbumName = @AlbumName, 
                                Artist = @Artist, 
                                Category = @Category, 
                                Manufacturer = @Manufacturer, 
                                ReleaseYear = @ReleaseYear, 
                                Quantity = @Quantity, 
                                Price = @Price 
                                WHERE Barcode = @Barcode";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@AlbumName", txtAlbumName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Artist", txtArtist.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@Manufacturer", txtManufacturer.Text.Trim());
                        cmd.Parameters.AddWithValue("@ReleaseYear", txtReleaseYear.Text.Trim());

                        int.TryParse(txtQuantity.Text, out int q);
                        cmd.Parameters.AddWithValue("@Quantity", q);

                        decimal.TryParse(txtPrice.Text, out decimal p);
                        cmd.Parameters.AddWithValue("@Price", p);

                        cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated Successfully!");
                        LoadInventory(); // Refresh ang DataGridView
                    }
                }
                catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // DELETE
            if (string.IsNullOrWhiteSpace(txtBarcode.Text)) return;

            // Magtanong muna bago mag-delete
            DialogResult result = MessageBox.Show("Are you sure you want to delete this album?",
                                                 "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string sqlQuery = "DELETE FROM MusicAlbums WHERE Barcode = @Barcode";

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Record Deleted!");
                            LoadInventory();
                            ClearFields(); // Linisin ang mga textboxes
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Kunin yung barcode na nakikita sa textbox (halimbawa: HPOP4773)
            string scannedCode = txtBarcode.Text.Trim();

            if (string.IsNullOrEmpty(scannedCode))
            {
                MessageBox.Show("Scan muna bago pindutin ang Cashier!");
                return;
            }

            // 1. I-check kung bukas na ang Cashier form sa memory
            MusicProductsCashier cashier = (MusicProductsCashier)Application.OpenForms["MusicProductsCashier"];

            if (cashier == null || cashier.IsDisposed)
            {
                cashier = new MusicProductsCashier();
                cashier.Show();
            }
            else
            {
                cashier.BringToFront();
            }

            // 2. ITO ANG PINAKA-IMPORTANTENG LINE:
            // Pinapasa natin yung barcode sa PUBLIC method na ReceiveScannedBarcode
            cashier.ReceiveScannedBarcode(scannedCode);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // REFRESH
            LoadInventory();
            MessageBox.Show("Inventory Refreshed!");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Mag-confirm muna bago mag-logout
            DialogResult res = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                // I-check kung bukas ang login form, kung hindi, gumawa ng bago
                OdysseyLogin login = new OdysseyLogin();
                login.Show();

                // Isara ang kasalukuyang MusicProducts form
                this.Dispose();
            }
        }
    }
}