namespace Elective
{
    partial class EmployeeReports
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
            dataGridView1.BackgroundColor = Color.ForestGreen;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1261, 570);
            dataGridView1.TabIndex = 17;
            // 
            // BACK
            // 
            BACK.BackColor = Color.LightGreen;
            BACK.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BACK.Location = new Point(706, 26);
            BACK.Name = "BACK";
            BACK.Size = new Size(150, 28);
            BACK.TabIndex = 16;
            BACK.Text = "BACK";
            BACK.UseVisualStyleBackColor = false;
            BACK.Click += BACK_Click;
            // 
            // SEARCH
            // 
            SEARCH.BackColor = Color.LightGreen;
            SEARCH.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SEARCH.Location = new Point(550, 26);
            SEARCH.Name = "SEARCH";
            SEARCH.Size = new Size(150, 28);
            SEARCH.TabIndex = 15;
            SEARCH.Text = "SEARCH";
            SEARCH.UseVisualStyleBackColor = false;
            SEARCH.Click += SEARCH_Click;
            // 
            // optionInputTxtbox
            // 
            optionInputTxtbox.BackColor = Color.MintCream;
            optionInputTxtbox.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionInputTxtbox.Location = new Point(340, 27);
            optionInputTxtbox.Name = "optionInputTxtbox";
            optionInputTxtbox.Size = new Size(180, 27);
            optionInputTxtbox.TabIndex = 14;
            // 
            // optionCombo
            // 
            optionCombo.BackColor = Color.MintCream;
            optionCombo.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            optionCombo.FormattingEnabled = true;
            optionCombo.Location = new Point(161, 27);
            optionCombo.Name = "optionCombo";
            optionCombo.Size = new Size(173, 28);
            optionCombo.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 30);
            label1.Name = "label1";
            label1.Size = new Size(130, 21);
            label1.TabIndex = 12;
            label1.Text = "Select an Option:";
            // 
            // EmployeeReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 689);
            Controls.Add(dataGridView1);
            Controls.Add(BACK);
            Controls.Add(SEARCH);
            Controls.Add(optionInputTxtbox);
            Controls.Add(optionCombo);
            Controls.Add(label1);
            Name = "EmployeeReports";
            Text = "EmployeeReports";
            Load += EmployeeReports_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        public Button BACK;
        public Button SEARCH;
        private TextBox optionInputTxtbox;
        private ComboBox optionCombo;
        private Label label1;
    }
}