namespace Elective
{
    partial class OdysseyMainForm
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
            salesReportsToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            simplePOSToolStripMenuItem = new ToolStripMenuItem();
            pOSCashierToolStripMenuItem = new ToolStripMenuItem();
            jEEPOSOrderingToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // salesReportsToolStripMenuItem
            // 
            salesReportsToolStripMenuItem.Name = "salesReportsToolStripMenuItem";
            salesReportsToolStripMenuItem.Size = new Size(181, 26);
            salesReportsToolStripMenuItem.Text = "Sales Reports";
            salesReportsToolStripMenuItem.Click += salesReportsToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesReportsToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(224, 26);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // simplePOSToolStripMenuItem
            // 
            simplePOSToolStripMenuItem.Name = "simplePOSToolStripMenuItem";
            simplePOSToolStripMenuItem.Size = new Size(224, 26);
            simplePOSToolStripMenuItem.Text = "Cashier";
            simplePOSToolStripMenuItem.Click += simplePOSToolStripMenuItem_Click;
            // 
            // pOSCashierToolStripMenuItem
            // 
            pOSCashierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jEEPOSOrderingToolStripMenuItem, simplePOSToolStripMenuItem, logoutToolStripMenuItem });
            pOSCashierToolStripMenuItem.Name = "pOSCashierToolStripMenuItem";
            pOSCashierToolStripMenuItem.Size = new Size(102, 24);
            pOSCashierToolStripMenuItem.Text = "POS Cashier";
            // 
            // jEEPOSOrderingToolStripMenuItem
            // 
            jEEPOSOrderingToolStripMenuItem.Name = "jEEPOSOrderingToolStripMenuItem";
            jEEPOSOrderingToolStripMenuItem.Size = new Size(224, 26);
            jEEPOSOrderingToolStripMenuItem.Text = "MusicProducts";
            jEEPOSOrderingToolStripMenuItem.Click += jEEPOSOrderingToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { pOSCashierToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1373, 28);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // OdysseyMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 450);
            Controls.Add(menuStrip1);
            Name = "OdysseyMainForm";
            Text = "OdysseyMainForm";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ToolStripMenuItem salesReportsToolStripMenuItem;
        public ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem simplePOSToolStripMenuItem;
        public ToolStripMenuItem pOSCashierToolStripMenuItem;
        private ToolStripMenuItem jEEPOSOrderingToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}