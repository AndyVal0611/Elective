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
    public partial class Activity4 : Form
    {
        private string picpath;
        public Activity4()
        {
            InitializeComponent();
        }

        private void Activity4_Load(object sender, EventArgs e)
        {
            // Disable textboxes
            creditUnitsTextBox.Enabled = false;
            totalNumberUnitsTextBox.Enabled = false;
            totalTuitionFeeTextBox.Enabled = false;
            totalMiscFeeTextBox.Enabled = false;
            totalTuitionAndFeeTextBox.Enabled = false;

            // Add engineering programs to the ComboBox
            ProgramsTextBox.Items.Add("BS In Aeronautical Engineering");
            ProgramsTextBox.Items.Add("BS In Civil Engineering");
            ProgramsTextBox.Items.Add("BS In Computer Engineering");
            ProgramsTextBox.Items.Add("BS In Electrical Engineering");
            ProgramsTextBox.Items.Add("BS In Electronics Engineering");
            ProgramsTextBox.Items.Add("BS In Industrial Engineering");
            ProgramsTextBox.Items.Add("BS In Mechanical Engineering");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Instance of OpenFileDialog using openFileDialog1
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Image file types
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Select an Image File";

            // Opens the file
            openFileDialog1.ShowDialog();
            picpath = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear all textboxes for NEW/CANCEL Button
            SNameTextBox.Text = "";
            ProgramsTextBox.Text = "";
            SNumTextBox.Text = "";
            yearLevelTextBox.Text = "";
            scholarTextBox.Text = "";
            courseNumberTextBox.Text = "";
            courseCodeTextBox.Text = "";
            courseDescTextBox.Text = "";
            unitLectureTextBox.Text = "";
            unitLaboratoryTextBox.Text = "";
            timeTextBox.Text = "";
            dayTextBox.Text = "";
            creditUnitsTextBox.Text = "";
            totalNumberUnitsTextBox.Text = "";
            laboratoryFeeTextBox.Text = "";
            totalTuitionFeeTextBox.Text = "";
            totalMiscFeeTextBox.Text = "";
            ciscoLabFeeTextBox.Text = "";
            examBookletFeeTextBox.Text = "";
            totalTuitionAndFeeTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SUBMIT Button
            // Transfer data to the corresponding ListBox
            courseCodeListBox.Items.Add(courseCodeTextBox.Text);
            courseDescListBox.Items.Add(courseDescTextBox.Text);
            unitLecListBox.Items.Add(unitLectureTextBox.Text);
            unitLabListBox.Items.Add(unitLaboratoryTextBox.Text);
            creditUnitsListBox.Items.Add(creditUnitsTextBox.Text);
            timeListBox.Items.Add(timeTextBox.Text);
            dayListBox.Items.Add(dayTextBox.Text);
            listBox2.Items.Add(totalTuitionFeeTextBox.Text);
            listBox3.Items.Add(totalMiscFeeTextBox.Text);
            listBox4.Items.Add(totalTuitionAndFeeTextBox.Text);
            listBox5.Items.Add(totalNumberUnitsTextBox.Text);
            listBox6.Items.Add(laboratoryFeeTextBox.Text);
            listBox7.Items.Add(ciscoLabFeeTextBox.Text);
            listBox8.Items.Add(examBookletFeeTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // CALCULATE Tuition Fee
            // Retrieve values from textboxes
            double lectureUnits = Convert.ToDouble(unitLectureTextBox.Text);
            double labUnits = Convert.ToDouble(unitLaboratoryTextBox.Text);

            // Calculate Credit Units
            double creditUnits = lectureUnits + labUnits;
            creditUnitsTextBox.Text = creditUnits.ToString();

            // Accumulate total number of units
            double totalUnits = 0.0;
            if (totalNumberUnitsTextBox.Text != "")
            {
                totalUnits = Convert.ToDouble(totalNumberUnitsTextBox.Text);
            }
            totalUnits += creditUnits;
            totalNumberUnitsTextBox.Text = totalUnits.ToString();

            // Calculate Total Tuition Fee
            const decimal TUITION_FEE_PER_UNIT = 1700.00m;
            decimal totalTuitionFee = Convert.ToDecimal(totalUnits) * TUITION_FEE_PER_UNIT;
            totalTuitionFeeTextBox.Text = totalTuitionFee.ToString("C2");

            // Get Miscellaneous Fee values
            decimal ciscoLabFee = Convert.ToDecimal(ciscoLabFeeTextBox.Text);
            decimal examBookletFee = Convert.ToDecimal(examBookletFeeTextBox.Text);
            decimal computerLaboratoryFee = Convert.ToDecimal(laboratoryFeeTextBox.Text);

            // Calculate Total Miscellaneous Fee
            decimal totalMiscFee = examBookletFee + ciscoLabFee + computerLaboratoryFee;
            totalMiscFeeTextBox.Text = totalMiscFee.ToString("C2");

            // Calculate Total Tuition and Fees
            decimal totalTuitionAndFees = totalTuitionFee + totalMiscFee;
            totalTuitionAndFeeTextBox.Text = totalTuitionAndFees.ToString("C2");
        }
    }
}
