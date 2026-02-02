namespace Elective
{
    partial class POS2Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS2Print));
            printdisplayListbox = new ListBox();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // printdisplayListbox
            // 
            printdisplayListbox.BackColor = SystemColors.Info;
            printdisplayListbox.Font = new Font("Garamond", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            printdisplayListbox.FormattingEnabled = true;
            printdisplayListbox.ItemHeight = 17;
            printdisplayListbox.Location = new Point(50, 133);
            printdisplayListbox.Name = "printdisplayListbox";
            printdisplayListbox.Size = new Size(395, 242);
            printdisplayListbox.TabIndex = 118;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Gadugi", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.MistyRose;
            label3.Location = new Point(134, 51);
            label3.Name = "label3";
            label3.Size = new Size(41, 22);
            label3.TabIndex = 117;
            label3.Text = "The";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Monotype Corsiva", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MistyRose;
            label2.Location = new Point(68, 51);
            label2.Name = "label2";
            label2.Size = new Size(363, 56);
            label2.TabIndex = 116;
            label2.Text = "Cheesecake Factory";
            // 
            // POS2Print
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(497, 431);
            Controls.Add(printdisplayListbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "POS2Print";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POS2Print";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox printdisplayListbox;
        private Label label3;
        private Label label2;
    }
}