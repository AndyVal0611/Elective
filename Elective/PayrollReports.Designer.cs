namespace Elective
{
    partial class PayrollReports
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
            dataGridView1 = new DataGridView();
            BACK = new Button();
            SEARCH = new Button();
            optionInputTxtbox = new TextBox();
            optionCombo = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.MediumVioletRed;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1261, 570);
            dataGridView1.TabIndex = 11;
            // 
            // BACK
            // 
            BACK.BackColor = Color.Violet;
            BACK.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BACK.Location = new Point(707, 29);
            BACK.Name = "BACK";
            BACK.Size = new Size(150, 28);
            BACK.TabIndex = 10;
            BACK.Text = "BACK";
            BACK.UseVisualStyleBackColor = false;
            BACK.Click += BACK_Click;
            // 
            // SEARCH
            // 
            SEARCH.BackColor = Color.Violet;
            SEARCH.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SEARCH.Location = new Point(551, 29);
            SEARCH.Name = "SEARCH";
            SEARCH.Size = new Size(150, 28);
            SEARCH.TabIndex = 9;
            SEARCH.Text = "SEARCH";
            SEARCH.UseVisualStyleBackColor = false;
            SEARCH.Click += SEARCH_Click;
            // 
            // optionInputTxtbox
            // 
            optionInputTxtbox.BackColor = Color.GhostWhite;
            optionInputTxtbox.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionInputTxtbox.Location = new Point(341, 30);
            optionInputTxtbox.Name = "optionInputTxtbox";
            optionInputTxtbox.Size = new Size(180, 27);
            optionInputTxtbox.TabIndex = 8;
            // 
            // optionCombo
            // 
            optionCombo.BackColor = Color.GhostWhite;
            optionCombo.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionCombo.FormattingEnabled = true;
            optionCombo.Location = new Point(162, 30);
            optionCombo.Name = "optionCombo";
            optionCombo.Size = new Size(173, 28);
            optionCombo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 33);
            label1.Name = "label1";
            label1.Size = new Size(130, 21);
            label1.TabIndex = 6;
            label1.Text = "Select an Option:";
            // 
            // PayrollReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 700);
            Controls.Add(dataGridView1);
            Controls.Add(BACK);
            Controls.Add(SEARCH);
            Controls.Add(optionInputTxtbox);
            Controls.Add(optionCombo);
            Controls.Add(label1);
            Name = "PayrollReports";
            Text = "PayrollReports";
            Load += PayrollReports_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button BACK;
        private Button SEARCH;
        private TextBox optionInputTxtbox;
        private ComboBox optionCombo;
        private Label label1;
    }
}