namespace Elective
{
    partial class OdysseyLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdysseyLogin));
            label1 = new Label();
            label3 = new Label();
            Username = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yellowtail", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(711, 324);
            label1.Name = "label1";
            label1.Size = new Size(472, 76);
            label1.TabIndex = 2;
            label1.Text = "Odyssey Corporation";
            label1.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(742, 460);
            label3.Name = "label3";
            label3.Size = new Size(73, 24);
            label3.TabIndex = 17;
            label3.Text = "Password";
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.BackColor = Color.Transparent;
            Username.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Username.Location = new Point(743, 428);
            Username.Name = "Username";
            Username.Size = new Size(78, 24);
            Username.TabIndex = 16;
            Username.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Gill Sans MT", 9F);
            txtUsername.Location = new Point(848, 427);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(306, 25);
            txtUsername.TabIndex = 15;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Gill Sans MT", 9F);
            txtPassword.Location = new Point(848, 460);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(306, 25);
            txtPassword.TabIndex = 14;
            // 
            // button2
            // 
            button2.BackColor = Color.AntiqueWhite;
            button2.Font = new Font("Marcellus SC", 12F, FontStyle.Bold);
            button2.Location = new Point(960, 509);
            button2.Name = "button2";
            button2.Size = new Size(98, 35);
            button2.TabIndex = 235;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.AntiqueWhite;
            button1.Font = new Font("Marcellus SC", 12F, FontStyle.Bold);
            button1.Location = new Point(835, 509);
            button1.Name = "button1";
            button1.Size = new Size(98, 35);
            button1.TabIndex = 234;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // OdysseyLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1824, 801);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(Username);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Name = "OdysseyLogin";
            Text = "OdysseyLogin";
            WindowState = FormWindowState.Maximized;
            Load += OdysseyLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label Username;
        private TextBox txtUsername;
        private TextBox txtPassword;
        public Button button2;
        public Button button1;
    }
}