using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    public class POSClasses
    {
        // instance variables
        public int qty = 0;
        public double price = 0;
        public double discount_amt = 0;
        public double discounted_amt = 0;
        public int qty_total = 0;
        public double discount_totalgiven = 0;
        public double discounted_total = 0;

        public int total_qty = 0;        // for POS2
        public double total_amount = 0;
        public double currentPrice = 0;
        public double currentDiscount = 0;

        // instance methods for POS1
        public void SetItem(string itemName, string itemPrice, System.Windows.Forms.TextBox itemNameTxtBox, System.Windows.Forms.TextBox priceTxtBox)
        {
            itemNameTxtBox.Text = itemName;
            priceTxtBox.Text = itemPrice;
        }

        public bool ConvertQtyPrice(System.Windows.Forms.TextBox qtyTxtBox, System.Windows.Forms.TextBox priceTxtBox, out int outQty, out double outPrice)
        {
            outQty = 0;
            outPrice = 0;
            try
            {
                outQty = Convert.ToInt32(qtyTxtBox.Text);
                outPrice = Convert.ToDouble(priceTxtBox.Text);
                return true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Input is invalid. Try again!");
                qtyTxtBox.Clear();
                qtyTxtBox.Focus();
                return false;
            }
        }

        public void ComputeDiscount(int qtyInput, double priceInput, double discountPercentage, System.Windows.Forms.TextBox discountTxtBox, System.Windows.Forms.TextBox discountedTxtBox)
        {
            discount_amt = (qtyInput * priceInput) * discountPercentage;
            discounted_amt = (qtyInput * priceInput) - discount_amt;
            discountTxtBox.Text = discount_amt.ToString("n");
            discountedTxtBox.Text = discounted_amt.ToString("n");
        }

        public void AccumulateTotals(int qtyInput, double discountAmtInput, double discountedAmtInput, System.Windows.Forms.TextBox totalQtyTxtBox, System.Windows.Forms.TextBox totalDiscGivTxtBox, System.Windows.Forms.TextBox totalDiscAmtTxtBox, System.Windows.Forms.TextBox cashTxtBox, System.Windows.Forms.TextBox changeTxtBox)
        {
            qty_total += qtyInput;
            discount_totalgiven += discountAmtInput;
            discounted_total += discountedAmtInput;

            double cashRendered = 0;
            double change = 0;

            try
            {
                cashRendered = Convert.ToDouble(cashTxtBox.Text);
            }
            catch
            {
                cashRendered = 0;
            }

            change = cashRendered - discounted_total;

            totalQtyTxtBox.Text = qty_total.ToString();
            totalDiscGivTxtBox.Text = discount_totalgiven.ToString("n");
            totalDiscAmtTxtBox.Text = discounted_total.ToString("n");
            changeTxtBox.Text = change.ToString("n");
        }

        // instance methods for POS2
        public void SetItemForPOS2(string itemName, string itemPrice, System.Windows.Forms.TextBox priceTxtBox, System.Windows.Forms.TextBox discountTxtBox, System.Windows.Forms.ListBox displayListBox)
        {
            priceTxtBox.Text = itemPrice;
            discountTxtBox.Text = "0.00";
            displayListBox.Items.Add(itemName + "              " + itemPrice);
        }

        public void ComputePOS2Totals(System.Windows.Forms.CheckBox[] checkBoxes, System.Windows.Forms.TextBox totalQtyTxtBox, System.Windows.Forms.TextBox totalBillTxtBox)
        {
            total_qty = 0;
            total_amount = 0;

            foreach (System.Windows.Forms.CheckBox cb in checkBoxes)
            {
                if (cb.Checked)
                {
                    total_qty += 1;
                    try
                    {
                        total_amount += Convert.ToDouble(cb.Tag);
                    }
                    catch { }
                }
            }

            totalQtyTxtBox.Text = total_qty.ToString();
            totalBillTxtBox.Text = total_amount.ToString("n");
        }
    }
}
