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
    public partial class Activity2 : Form
    {
        // declaration of global variables
        private double amount_paid, price, cash_given, change;
        private int quantity;
        public Activity2()
        {
            InitializeComponent();
        }

        private void Activity2_Load(object sender, EventArgs e)
        {
            // code for changing the form size
            changeTextBox.Enabled = false;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code for inserting or assigning a value to the Text property of a textbox
            itemnameTxtbox.Text = "Chocolate Cake";
            priceTxtbox.Text = "200.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Oreo Cheesecake";
            priceTxtbox.Text = "220.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Carrot Cake";
            priceTxtbox.Text = "180.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Chocolate Cheesecake";
            priceTxtbox.Text = "210.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Truffle Cake";
            priceTxtbox.Text = "230.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Classic Cheesecake";
            priceTxtbox.Text = "190.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Banana Cream Cake";
            priceTxtbox.Text = "170.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Vanilla Cheesecake";
            priceTxtbox.Text = "185.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Caramel Cake";
            priceTxtbox.Text = "195.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Strawberry Cheesecake";
            priceTxtbox.Text = "210.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Salted Caramel Cake";
            priceTxtbox.Text = "225.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Chocolate Mousse Cake";
            priceTxtbox.Text = "240.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cash_givenTxtbox.Text) && !string.IsNullOrEmpty(amount_PaidTxtbox.Text))
            {
                // Remove the commas and then convert to double.
                string cashGivenString = cash_givenTxtbox.Text.Replace(",", "");
                string amountPaidString = amount_PaidTxtbox.Text.Replace(",", "");

                double cash_given = Convert.ToDouble(cashGivenString);
                double amount_paid = Convert.ToDouble(amountPaidString);

                // Calculate the change.
                double change = cash_given - amount_paid;

                // Display the change in the textbox, formatted with two decimal places.
                changeTextBox.Text = change.ToString("n2");
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            // Clear all textboxes for New/Cancel button to start a new transaction
            qtyTextBox.Clear();
            amount_PaidTxtbox.Clear();
            cash_givenTxtbox.Clear();
            changeTextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qtyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(qtyTextBox.Text))
            {
                // Convert price from the textbox to a number.
                // Convert quantity from the textbox to a number.
                double price = Convert.ToDouble(priceTxtbox.Text);
                int quantity = Convert.ToInt32(qtyTextBox.Text);

                // Calculate the amount paid.
                amount_paid = price * quantity;

                // Display the result in the Amount Paid textbox.
                amount_PaidTxtbox.Text = amount_paid.ToString("n2");
            }
            else
            {
                // Clear the textbox if quantity is empty.
                amount_PaidTxtbox.Clear();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Red Velvet Cake";
            priceTxtbox.Text = "200.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Blueberry Cheesecake";
            priceTxtbox.Text = "215.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Mango Cheesecake";
            priceTxtbox.Text = "205.00";
            qtyTextBox.Focus();
            qtyTextBox.Clear();
        }
    }
}
