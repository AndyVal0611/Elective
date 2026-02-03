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
    public partial class Example2 : Form
    {
        public Example2()
        {
            InitializeComponent();
        }

        private void Example2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price, computed_discount;
            const double discount = 0.20D; //20% discount
            try
            {
                price = Convert.ToDouble(priceTxtbox.Text);
                if (price >= 2500)
                {
                    computed_discount = price * discount;
                    discountTxtbox.Text = computed_discount.ToString("C");
                }
                else
                {
                    computed_discount = (price * 0.12);
                    discountTxtbox.Text = computed_discount.ToString("C");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input data for price is invalid!");
                priceTxtbox.Clear();
                discountTxtbox.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            priceTxtbox.Clear();
            discountTxtbox.Clear();
            priceTxtbox.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
