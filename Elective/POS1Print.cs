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
    public partial class POS1Print : Form
    {
        public POS1Print(string itemName,
            string quantity,
            string price,
            string discountAmount,
            string discountedAmount,
            string totalQuantity,
            string totalDiscountGiven,
            string totalDiscountedAmount,
            string change)
        {
            InitializeComponent();

            itemnameTxtbox.Text = itemName;
            qty_txtbox.Text = quantity;
            priceTxtbox.Text = price;
            discount_txtbox.Text = discountAmount;
            discounted_txtbox.Text = discountedAmount;
            totalqty_txtbox.Text = totalQuantity;
            totaldiscg_txtbox.Text = totalDiscountGiven;
            totaldiscamt_txtbox.Text = totalDiscountedAmount;
            changetxtbox.Text = change;
        }

        private void POS1Print_Load(object sender, EventArgs e)
        {
            //
        }
    }
}
