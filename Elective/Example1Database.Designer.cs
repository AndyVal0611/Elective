namespace Elective
{
    partial class Example1Database
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            gridView = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            departmentTxtbox = new TextBox();
            studentNameTxtbox = new TextBox();
            studentNumTxtbox = new TextBox();
            picturepathTxtbox = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button6
            // 
            button6.BackColor = Color.PowderBlue;
            button6.Font = new Font("Candara", 9F, FontStyle.Bold);
            button6.Location = new Point(1028, 562);
            button6.Name = "button6";
            button6.Size = new Size(87, 44);
            button6.TabIndex = 63;
            button6.Text = "New";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.PowderBlue;
            button5.Font = new Font("Candara", 9F, FontStyle.Bold);
            button5.Location = new Point(935, 562);
            button5.Name = "button5";
            button5.Size = new Size(87, 44);
            button5.TabIndex = 62;
            button5.Text = "Cancel";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.PowderBlue;
            button4.Font = new Font("Candara", 9F, FontStyle.Bold);
            button4.Location = new Point(842, 562);
            button4.Name = "button4";
            button4.Size = new Size(87, 44);
            button4.TabIndex = 61;
            button4.Text = "Edit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.PowderBlue;
            button3.Font = new Font("Candara", 9F, FontStyle.Bold);
            button3.Location = new Point(750, 562);
            button3.Name = "button3";
            button3.Size = new Size(87, 44);
            button3.TabIndex = 60;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PowderBlue;
            button2.Font = new Font("Candara", 9F, FontStyle.Bold);
            button2.Location = new Point(657, 562);
            button2.Name = "button2";
            button2.Size = new Size(87, 44);
            button2.TabIndex = 59;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.PowderBlue;
            button1.Font = new Font("Candara", 9F, FontStyle.Bold);
            button1.Location = new Point(564, 563);
            button1.Name = "button1";
            button1.Size = new Size(87, 44);
            button1.TabIndex = 58;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // gridView
            // 
            gridView.BackgroundColor = Color.LightCyan;
            gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridView.Location = new Point(563, 277);
            gridView.Name = "gridView";
            gridView.RowHeadersWidth = 51;
            gridView.Size = new Size(553, 264);
            gridView.TabIndex = 57;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(563, 233);
            label4.Name = "label4";
            label4.Size = new Size(89, 18);
            label4.TabIndex = 56;
            label4.Text = "Department:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(563, 191);
            label3.Name = "label3";
            label3.Size = new Size(102, 18);
            label3.TabIndex = 55;
            label3.Text = "Student Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(563, 149);
            label2.Name = "label2";
            label2.Size = new Size(117, 18);
            label2.TabIndex = 54;
            label2.Text = "Student Number:";
            // 
            // departmentTxtbox
            // 
            departmentTxtbox.BackColor = Color.LightCyan;
            departmentTxtbox.Location = new Point(699, 230);
            departmentTxtbox.Name = "departmentTxtbox";
            departmentTxtbox.Size = new Size(416, 27);
            departmentTxtbox.TabIndex = 53;
            // 
            // studentNameTxtbox
            // 
            studentNameTxtbox.BackColor = Color.LightCyan;
            studentNameTxtbox.Location = new Point(699, 188);
            studentNameTxtbox.Name = "studentNameTxtbox";
            studentNameTxtbox.Size = new Size(416, 27);
            studentNameTxtbox.TabIndex = 52;
            // 
            // studentNumTxtbox
            // 
            studentNumTxtbox.BackColor = Color.LightCyan;
            studentNumTxtbox.Location = new Point(699, 146);
            studentNumTxtbox.Name = "studentNumTxtbox";
            studentNumTxtbox.Size = new Size(416, 27);
            studentNumTxtbox.TabIndex = 51;
            // 
            // picturepathTxtbox
            // 
            picturepathTxtbox.BackColor = Color.LightCyan;
            picturepathTxtbox.Location = new Point(749, 103);
            picturepathTxtbox.Name = "picturepathTxtbox";
            picturepathTxtbox.Size = new Size(366, 27);
            picturepathTxtbox.TabIndex = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Euphorigenic", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(579, 33);
            label1.Name = "label1";
            label1.Size = new Size(525, 47);
            label1.TabIndex = 49;
            label1.Text = "Sample Program Lang Po ──★ ˙\U0001f9f7 ̟ !! ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.PaleTurquoise;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(44, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(484, 541);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Example1Database
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(1157, 636);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(gridView);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(departmentTxtbox);
            Controls.Add(studentNameTxtbox);
            Controls.Add(studentNumTxtbox);
            Controls.Add(picturepathTxtbox);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Example1Database";
            Text = "Example1Database";
            Load += Example1Database_Load;
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button button6;
        public Button button5;
        public Button button4;
        public Button button3;
        public Button button2;
        public Button button1;
        public DataGridView gridView;
        public Label label4;
        public Label label3;
        public Label label2;
        public TextBox departmentTxtbox;
        public TextBox studentNameTxtbox;
        public TextBox studentNumTxtbox;
        public TextBox picturepathTxtbox;
        public Label label1;
        public PictureBox pictureBox1;
    }
}