namespace DSAL_Prelim
{
    partial class LoginFrm_Database
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
            button2 = new Button();
            button1 = new Button();
            usernameTxtbox = new TextBox();
            passwordTxtbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.LightCyan;
            button2.Font = new Font("Kalam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(996, 507);
            button2.Name = "button2";
            button2.Size = new Size(98, 35);
            button2.TabIndex = 12;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCyan;
            button1.Font = new Font("Kalam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(871, 507);
            button1.Name = "button1";
            button1.Size = new Size(98, 35);
            button1.TabIndex = 11;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // usernameTxtbox
            // 
            usernameTxtbox.BackColor = Color.Honeydew;
            usernameTxtbox.Location = new Point(885, 419);
            usernameTxtbox.Name = "usernameTxtbox";
            usernameTxtbox.Size = new Size(248, 27);
            usernameTxtbox.TabIndex = 7;
            // 
            // passwordTxtbox
            // 
            passwordTxtbox.BackColor = Color.Honeydew;
            passwordTxtbox.Location = new Point(885, 450);
            passwordTxtbox.Name = "passwordTxtbox";
            passwordTxtbox.Size = new Size(248, 27);
            passwordTxtbox.TabIndex = 8;
            passwordTxtbox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 9F);
            label2.Location = new Point(807, 454);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 10;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 9F);
            label1.Location = new Point(807, 419);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 9;
            label1.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Monotype Corsiva", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkSlateGray;
            label4.Location = new Point(687, 333);
            label4.Name = "label4";
            label4.Size = new Size(589, 72);
            label4.TabIndex = 227;
            label4.Text = "TCF Incorperated System";
            // 
            // LoginFrm_Database
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(1564, 755);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(usernameTxtbox);
            Controls.Add(passwordTxtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginFrm_Database";
            Text = "LoginFrm_Database";
            WindowState = FormWindowState.Maximized;
            Load += LoginFrm_Database_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button button2;
        public Button button1;
        public TextBox usernameTxtbox;
        public TextBox passwordTxtbox;
        public Label label2;
        public Label label1;
        public Label label4;
    }
}