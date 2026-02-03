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
    public partial class Example3 : Form
    {
        public Example3()
        {
            InitializeComponent();
        }

        private void SUM_Click(object sender, EventArgs e)
        {
            //Declaration of variables within a method of an object
            double firstNum, secondNum, thirdNum, fourthNum, sum;

            //Converting input read as string to numeric value
            firstNum = Convert.ToDouble(firstNumTxtbox.Text);
            secondNum = Convert.ToDouble(secondNumTxtbox.Text);
            thirdNum = Convert.ToDouble(thirdNumTxtbox.Text);
            fourthNum = Convert.ToDouble(fourthNumTxtbox.Text);

            //Creating a formula for simple adding of two input numbers
            sum = firstNum + secondNum + thirdNum + fourthNum;

            //Converting the numeric value reside inside the variables and display it in a textbox
            displayTxtbox.Text = sum.ToString("n");
        }

        private void DIFFERENCE_Click(object sender, EventArgs e)
        {
            //Declaration of variables within a method of an object
            double firstNum, secondNum, thirdNum, fourthNum, difference;

            //Converting input read as string to numeric value
            firstNum = Convert.ToDouble(firstNumTxtbox.Text);
            secondNum = Convert.ToDouble(secondNumTxtbox.Text);
            thirdNum = Convert.ToDouble(thirdNumTxtbox.Text);
            fourthNum = Convert.ToDouble(fourthNumTxtbox.Text);

            //Creating a formula for simple adding of two input numbers
            difference = firstNum - secondNum - thirdNum - fourthNum;

            //Converting the numeric value reside inside the variables and display it in a textbox
            displayTxtbox.Text = difference.ToString("n");
        }

        private void PRODUCT_Click(object sender, EventArgs e)
        {
            //Declaration of variables within a method of an object
            double firstNum, secondNum, thirdNum, fourthNum, product;

            //Converting input read as string to numeric value
            firstNum = Convert.ToDouble(firstNumTxtbox.Text);
            secondNum = Convert.ToDouble(secondNumTxtbox.Text);
            thirdNum = Convert.ToDouble(thirdNumTxtbox.Text);
            fourthNum = Convert.ToDouble(fourthNumTxtbox.Text);

            //Creating a formula for simple adding of two input numbers
            product = firstNum * secondNum * thirdNum * fourthNum;

            //Converting the numeric value reside inside the variables and display it in a textbox
            displayTxtbox.Text = product.ToString("n");
        }

        private void QUOTIENT_Click(object sender, EventArgs e)
        {
            //Declaration of variables within a method of an object
            double firstNum, secondNum, thirdNum, fourthNum, quotient;

            //Converting input read as string to numeric value
            firstNum = Convert.ToDouble(firstNumTxtbox.Text);
            secondNum = Convert.ToDouble(secondNumTxtbox.Text);
            thirdNum = Convert.ToDouble(thirdNumTxtbox.Text);
            fourthNum = Convert.ToDouble(fourthNumTxtbox.Text);

            //Creating a formula for simple adding of two input numbers
            quotient = (firstNum + secondNum) / (thirdNum + fourthNum);

            //Converting the numeric value reside inside the variables and display it in a textbox
            displayTxtbox.Text = quotient.ToString("n");
        }
    }
}
