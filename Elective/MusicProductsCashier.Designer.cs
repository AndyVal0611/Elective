namespace Elective
{
    partial class MusicProductsCashier
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
            dgvCart = new DataGridView();
            btnCheckout = new Button();
            txtScanReceiver = new TextBox();
            lblTotal = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            regradioButton1 = new RadioButton();
            seniorradioButton2 = new RadioButton();
            empradioButton3 = new RadioButton();
            promoradioButton4 = new RadioButton();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.LightYellow;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(36, 76);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(520, 570);
            dgvCart.TabIndex = 23;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.Khaki;
            btnCheckout.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.Location = new Point(578, 594);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(150, 55);
            btnCheckout.TabIndex = 21;
            btnCheckout.Text = "CHECKOUT";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // txtScanReceiver
            // 
            txtScanReceiver.BackColor = Color.MintCream;
            txtScanReceiver.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtScanReceiver.Location = new Point(36, 27);
            txtScanReceiver.Name = "txtScanReceiver";
            txtScanReceiver.Size = new Size(520, 27);
            txtScanReceiver.TabIndex = 20;
            txtScanReceiver.TextChanged += txtScanReceiver_TextChanged;
            txtScanReceiver.KeyDown += txtScanReceiver_KeyDown;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Palatino Linotype", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(601, 97);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 31);
            lblTotal.TabIndex = 24;
            lblTotal.Text = "TOTAL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(578, 76);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 25;
            label1.Text = "TOTAL:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.MintCream;
            textBox1.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(578, 389);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 27);
            textBox1.TabIndex = 26;
            // 
            // button1
            // 
            button1.BackColor = Color.Moccasin;
            button1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(578, 422);
            button1.Name = "button1";
            button1.Size = new Size(150, 28);
            button1.TabIndex = 27;
            button1.Text = "CALCULATE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.MintCream;
            textBox2.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(578, 518);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 27);
            textBox2.TabIndex = 28;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(578, 365);
            label2.Name = "label2";
            label2.Size = new Size(103, 21);
            label2.TabIndex = 29;
            label2.Text = "Cash Rendered";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(578, 494);
            label3.Name = "label3";
            label3.Size = new Size(64, 21);
            label3.TabIndex = 30;
            label3.Text = "Change";
            // 
            // regradioButton1
            // 
            regradioButton1.AutoSize = true;
            regradioButton1.Font = new Font("Palatino Linotype", 7.8F, FontStyle.Bold);
            regradioButton1.Location = new Point(578, 190);
            regradioButton1.Name = "regradioButton1";
            regradioButton1.Size = new Size(77, 22);
            regradioButton1.TabIndex = 31;
            regradioButton1.TabStop = true;
            regradioButton1.Text = "Regular";
            regradioButton1.UseVisualStyleBackColor = true;
            regradioButton1.CheckedChanged += regradioButton1_CheckedChanged;
            // 
            // seniorradioButton2
            // 
            seniorradioButton2.AutoSize = true;
            seniorradioButton2.Font = new Font("Palatino Linotype", 7.8F, FontStyle.Bold);
            seniorradioButton2.Location = new Point(578, 220);
            seniorradioButton2.Name = "seniorradioButton2";
            seniorradioButton2.Size = new Size(105, 22);
            seniorradioButton2.TabIndex = 32;
            seniorradioButton2.TabStop = true;
            seniorradioButton2.Text = "Senior/PWD";
            seniorradioButton2.UseVisualStyleBackColor = true;
            seniorradioButton2.CheckedChanged += seniorradioButton2_CheckedChanged;
            // 
            // empradioButton3
            // 
            empradioButton3.AutoSize = true;
            empradioButton3.Font = new Font("Palatino Linotype", 7.8F, FontStyle.Bold);
            empradioButton3.Location = new Point(578, 250);
            empradioButton3.Name = "empradioButton3";
            empradioButton3.Size = new Size(90, 22);
            empradioButton3.TabIndex = 33;
            empradioButton3.TabStop = true;
            empradioButton3.Text = "Employee";
            empradioButton3.UseVisualStyleBackColor = true;
            empradioButton3.CheckedChanged += empradioButton3_CheckedChanged;
            // 
            // promoradioButton4
            // 
            promoradioButton4.AutoSize = true;
            promoradioButton4.Font = new Font("Palatino Linotype", 7.8F, FontStyle.Bold);
            promoradioButton4.Location = new Point(578, 280);
            promoradioButton4.Name = "promoradioButton4";
            promoradioButton4.Size = new Size(70, 22);
            promoradioButton4.TabIndex = 34;
            promoradioButton4.TabStop = true;
            promoradioButton4.Text = "Promo";
            promoradioButton4.UseVisualStyleBackColor = true;
            promoradioButton4.CheckedChanged += promoradioButton4_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(578, 166);
            label4.Name = "label4";
            label4.Size = new Size(117, 21);
            label4.TabIndex = 35;
            label4.Text = "Types of discount";
            // 
            // MusicProductsCashier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(759, 681);
            Controls.Add(label4);
            Controls.Add(promoradioButton4);
            Controls.Add(empradioButton3);
            Controls.Add(seniorradioButton2);
            Controls.Add(regradioButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(lblTotal);
            Controls.Add(dgvCart);
            Controls.Add(btnCheckout);
            Controls.Add(txtScanReceiver);
            Name = "MusicProductsCashier";
            Text = "Products";
            Load += MusicProductsCashier_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCart;
        public Button btnCheckout;
        private TextBox txtScanReceiver;
        private Label lblTotal;
        private Label label1;
        private TextBox textBox1;
        public Button button1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private RadioButton regradioButton1;
        private RadioButton seniorradioButton2;
        private RadioButton empradioButton3;
        private RadioButton promoradioButton4;
        private Label label4;
    }
}