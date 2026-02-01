using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    internal class POSLogic
    {
        // Global variables sa loob ng logic class para ma-track ang running total
        private int runningTotalQty = 0;
        private double runningTotalDiscount = 0;
        private double runningTotalAmount = 0;

        public void AccumulateTotals(int qty, double disc, double discAmt,
                                     TextBox txtQty, TextBox txtDisc, TextBox txtTotalAmt,
                                     TextBox cashTxt, TextBox changeTxt)
        {
            // 1. I-add ang bagong values sa running totals
            runningTotalQty += qty;
            runningTotalDiscount += disc;
            runningTotalAmount += discAmt;

            // 2. I-display sa UI (Textboxes)
            txtQty.Text = runningTotalQty.ToString();
            txtDisc.Text = runningTotalDiscount.ToString("n2");
            txtTotalAmt.Text = runningTotalAmount.ToString("n2");

            // 3. Optional: Change computation kung may cash na
            if (!string.IsNullOrEmpty(cashTxt.Text))
            {
                double cash = Convert.ToDouble(cashTxt.Text);
                double change = cash - runningTotalAmount;
                changeTxt.Text = change.ToString("n2");
            }
        }
    }
}
