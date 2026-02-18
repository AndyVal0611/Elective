namespace Elective
{
    partial class MusicProductsReport
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
            dgvReport = new DataGridView();
            BACK = new Button();
            EXIT = new Button();
            txtSearchReport = new TextBox();
            optionCombo = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // dgvReport
            // 
            dgvReport.BackgroundColor = Color.Tan;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(41, 81);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1261, 570);
            dgvReport.TabIndex = 17;
            // 
            // BACK
            // 
            BACK.BackColor = Color.Moccasin;
            BACK.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BACK.Location = new Point(559, 32);
            BACK.Name = "BACK";
            BACK.Size = new Size(150, 28);
            BACK.TabIndex = 16;
            BACK.Text = "BACK";
            BACK.UseVisualStyleBackColor = false;

            // 
            // EXIT
            // 
            EXIT.BackColor = Color.Wheat;
            EXIT.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EXIT.Location = new Point(727, 32);
            EXIT.Name = "EXIT";
            EXIT.Size = new Size(150, 28);
            EXIT.TabIndex = 15;
            EXIT.Text = "EXIT";
            EXIT.UseVisualStyleBackColor = false;
            EXIT.Click += EXIT_Click;
            // 
            // txtSearchReport
            // 
            txtSearchReport.BackColor = Color.GhostWhite;
            txtSearchReport.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchReport.Location = new Point(349, 33);
            txtSearchReport.Name = "txtSearchReport";
            txtSearchReport.Size = new Size(180, 27);
            txtSearchReport.TabIndex = 14;
            txtSearchReport.TextChanged += txtSearchReport_TextChanged;
            // 
            // optionCombo
            // 
            optionCombo.BackColor = Color.GhostWhite;
            optionCombo.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionCombo.FormattingEnabled = true;
            optionCombo.Location = new Point(170, 33);
            optionCombo.Name = "optionCombo";
            optionCombo.Size = new Size(173, 28);
            optionCombo.TabIndex = 13;
            optionCombo.SelectedIndexChanged += optionCombo_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 36);
            label1.Name = "label1";
            label1.Size = new Size(130, 21);
            label1.TabIndex = 12;
            label1.Text = "Select an Option:";
            // 
            // MusicProductsReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 690);
            Controls.Add(dgvReport);
            Controls.Add(BACK);
            Controls.Add(EXIT);
            Controls.Add(txtSearchReport);
            Controls.Add(optionCombo);
            Controls.Add(label1);
            Name = "MusicProductsReport";
            Text = "MusicProductsReport";
            Load += MusicProductsReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReport;
        private Button BACK;
        private Button EXIT;
        private TextBox txtSearchReport;
        private ComboBox optionCombo;
        private Label label1;
    }
}