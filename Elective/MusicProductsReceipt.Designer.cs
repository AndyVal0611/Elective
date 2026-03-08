namespace Elective
{
    partial class MusicProductsReceipt
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
            label1 = new Label();
            priDisplaylistbox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yellowtail", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(64, 33);
            label1.Name = "label1";
            label1.Size = new Size(355, 76);
            label1.TabIndex = 2;
            label1.Text = "Odyssey Music";
            label1.UseWaitCursor = true;
            // 
            // priDisplaylistbox
            // 
            priDisplaylistbox.BackColor = Color.AntiqueWhite;
            priDisplaylistbox.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priDisplaylistbox.FormattingEnabled = true;
            priDisplaylistbox.ItemHeight = 15;
            priDisplaylistbox.Location = new Point(29, 135);
            priDisplaylistbox.Margin = new Padding(3, 4, 3, 4);
            priDisplaylistbox.Name = "priDisplaylistbox";
            priDisplaylistbox.Size = new Size(427, 529);
            priDisplaylistbox.TabIndex = 3;
            // 
            // MusicProductsReceipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(485, 719);
            Controls.Add(priDisplaylistbox);
            Controls.Add(label1);
            Name = "MusicProductsReceipt";
            Text = "MusicProductsReceipt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public ListBox priDisplaylistbox;
    }
}