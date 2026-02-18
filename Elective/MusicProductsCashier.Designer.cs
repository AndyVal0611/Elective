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
            btnCheckout.Location = new Point(406, 26);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(150, 28);
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
            txtScanReceiver.Size = new Size(344, 27);
            txtScanReceiver.TabIndex = 20;
            txtScanReceiver.TextChanged += txtScanReceiver_TextChanged;
            txtScanReceiver.KeyDown += txtScanReceiver_KeyDown;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(446, 659);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(63, 21);
            lblTotal.TabIndex = 24;
            lblTotal.Text = "TOTAL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 659);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 25;
            label1.Text = "TOTAL:";
            // 
            // MusicProductsCashier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(594, 698);
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
    }
}