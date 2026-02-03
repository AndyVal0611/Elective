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
    public partial class Activity3 : Form
    {
        public Activity3()
        {
            InitializeComponent();
        }

        private void Activity3_Load(object sender, EventArgs e)
        {
            // code for changing the form background
            this.BackColor = Color.LightGoldenrodYellow;
        }

        private void foodARdbtn_CheckedChanged(object sender, EventArgs e)
        {
            // code for changing the form background
            this.BackColor = Color.LightSalmon;
            // code for food bundle B not to be selected
            foodBRdbtn.Checked = false;
            // inserting image inside the picture box
            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\Elective\FoodBundleA.png");

            // codes to check the checkboxes
            A_FriedChickenCheckBox.Checked = true;
            A_FriesCheckBox.Checked = true;
            A_CokeCheckBox.Checked = true;
            A_SideDishCheckBox.Checked = true;
            A_SpecialPizzaCheckBox.Checked = true;
            // codes to uncheck the checkboxes
            B_HalohaloCheckBox.Checked = false;
            B_ChickenCheckBox.Checked = false;
            B_CarbonaraCheckBox.Checked = false;
            B_FriesCheckBox.Checked = false;
            B_HawaiianCheckBox.Checked = false;
            // codes for displaying data inside the textboxes
            priceTextBox.Text = "P1,000.00";
            discountTextBox.Text = "20% (of the Price) P200.00";
        }

        private void foodBRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            // code for changing the form background
            this.BackColor = Color.Salmon;
            // code for food bundle A not to be selected
            foodARdbtn.Checked = false;
            // inserting image inside the picture box
            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\Elective\FoodBundleB.png");

            // codes to uncheck the checkboxes
            A_FriedChickenCheckBox.Checked = false;
            A_FriesCheckBox.Checked = false;
            A_CokeCheckBox.Checked = false;
            A_SideDishCheckBox.Checked = false;
            A_SpecialPizzaCheckBox.Checked = false;
            // codes to check the checkboxes
            B_HalohaloCheckBox.Checked = true;
            B_ChickenCheckBox.Checked = true;
            B_CarbonaraCheckBox.Checked = true;
            B_FriesCheckBox.Checked = true;
            B_HawaiianCheckBox.Checked = true;
            // codes for displaying data inside the textboxes
            priceTextBox.Text = "P1,299.00";
            discountTextBox.Text = "15% (of the Price) P194.85";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // code for food bundle A not to be selected
            foodARdbtn.Checked = false;
            foodBRdbtn.Checked = false;
            // code for inserting default image inside the picturebox
            DisplayPictureBox.Image = Image.FromFile(@"C:\Users\andy1\source\repos\Elective\TCF.png");

            // codes to uncheck all the checkboxes
            A_FriedChickenCheckBox.Checked = false;
            A_FriesCheckBox.Checked = false;
            A_CokeCheckBox.Checked = false;
            A_SideDishCheckBox.Checked = false;
            A_SpecialPizzaCheckBox.Checked = false;
            B_HalohaloCheckBox.Checked = false;
            B_ChickenCheckBox.Checked = false;
            B_CarbonaraCheckBox.Checked = false;
            B_FriesCheckBox.Checked = false;
            B_HawaiianCheckBox.Checked = false;

            //codes for clearing the textboxes
            priceTextBox.Clear();
            discountTextBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
