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
            optionCombo.Items.Add("AlbumName");
            optionCombo.Items.Add("Artist");
            optionCombo.Items.Add("Barcode");

            LoadFullReport();
            optionCombo.SelectedIndex = 0;
            LoadFullReport();
            // Default selection para sa combo box
            optionCombo.SelectedIndex = 0;
        }

        private void LoadFullReport()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MusicAlbums", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReport.DataSource = dt; // dgvReport ang nasa pink area
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
            string selectedColumn = optionCombo.SelectedItem.ToString();

            // Ayusin ang column name base sa database schema
            if (selectedColumn == "Record Label") selectedColumn = "Manufacturer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Direct filtering based sa napiling option
                    string sql = $"SELECT * FROM MusicAlbums WHERE {selectedColumn} LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearchReport.Text.Trim() + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReport.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Hayaan lang kung walang nahanap o may typo sa simula
                }
            }
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
