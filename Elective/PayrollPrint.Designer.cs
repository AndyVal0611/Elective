namespace Elective
{
    partial class PayrollPrint
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
            priDisplaylistbox = new ListBox();
            SuspendLayout();
            // 
            // priDisplaylistbox
            // 
            priDisplaylistbox.BackColor = Color.Azure;
            priDisplaylistbox.Font = new Font("Lucida Bright", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priDisplaylistbox.FormattingEnabled = true;
            priDisplaylistbox.ItemHeight = 17;
            priDisplaylistbox.Location = new Point(31, 23);
            priDisplaylistbox.Margin = new Padding(3, 4, 3, 4);
            priDisplaylistbox.Name = "priDisplaylistbox";
            priDisplaylistbox.Size = new Size(323, 786);
            priDisplaylistbox.TabIndex = 2;
            // 
            // PayrollPrint
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(389, 836);
            Controls.Add(priDisplaylistbox);
            Name = "PayrollPrint";
            Text = "PayrollPrint";
            ResumeLayout(false);
        }

        #endregion

        public ListBox priDisplaylistbox;
    }
}