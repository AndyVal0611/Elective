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

namespace Elective
{
    public partial class MusicProductsReport : Form
    {
        private string connectionString = @"Data Source=LAPTOP-JLQMV6PN\SQLEXPRESS; Initial Catalog=MusicProductsDB; Integrated Security=True";
        public MusicProductsReport()
        {
            InitializeComponent();
        }

        private void MusicProductsReport_Load(object sender, EventArgs e)
        {
            // Mga filter options para sa sales report
            optionCombo.Items.Clear();
            optionCombo.Items.Add("AlbumName");
            optionCombo.Items.Add("Barcode");
            optionCombo.Items.Add("SoldBy");
            optionCombo.Items.Add("DiscountType");// Para mahanap kung sinong cashier ang nagbenta

            LoadFullReport();
            optionCombo.SelectedIndex = 0;
        }

        private void LoadFullReport()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Tinanggal na natin ang 'Artist' sa SELECT statement
                string query = "SELECT TransactionID, Barcode, AlbumName, Price, DateSold, SoldBy FROM SalesTransactions ORDER BY DateSold DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReport.DataSource = dt;
            }
        }

        private void optionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchReport_TextChanged(object sender, EventArgs e)
        {
            FilterData();

        }
        private void FilterData()
        {
            if (optionCombo.SelectedItem == null) return;
            string selectedColumn = optionCombo.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Nag-fifilter tayo sa SalesTransactions table
                    string sql = $"SELECT * FROM SalesTransactions WHERE {selectedColumn} LIKE @search ORDER BY DateSold DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearchReport.Text.Trim() + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReport.DataSource = dt;
                    }
                }
                catch (Exception)
                {
                    // Silent catch para sa smooth typing experience
                }
            }
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
