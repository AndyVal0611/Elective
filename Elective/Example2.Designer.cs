namespace Elective
{
    partial class Example2
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            discountTxtbox = new TextBox();
            priceTxtbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(455, 174);
            button3.Name = "button3";
            button3.Size = new Size(179, 51);
            button3.TabIndex = 20;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(251, 174);
            button2.Name = "button2";
            button2.Size = new Size(179, 51);
            button2.TabIndex = 19;
            button2.Text = "New";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(48, 174);
            button1.Name = "button1";
            button1.Size = new Size(179, 51);
            button1.TabIndex = 18;
            button1.Text = "Compute";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // discountTxtbox
            // 
            discountTxtbox.Font = new Font("Franklin Gothic Book", 18F, FontStyle.Bold);
            discountTxtbox.Location = new Point(378, 102);
            discountTxtbox.Name = "discountTxtbox";
            discountTxtbox.Size = new Size(214, 42);
            discountTxtbox.TabIndex = 17;
            // 
            // priceTxtbox
            // 
            priceTxtbox.Font = new Font("Franklin Gothic Book", 18F, FontStyle.Bold);
            priceTxtbox.Location = new Point(378, 56);
            priceTxtbox.Name = "priceTxtbox";
            priceTxtbox.Size = new Size(214, 42);
            priceTxtbox.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ebrima", 12F, FontStyle.Bold);
            label2.Location = new Point(92, 111);
            label2.Name = "label2";
            label2.Size = new Size(280, 28);
            label2.TabIndex = 15;
            label2.Text = "20% Senior Citizen Discount";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 12F, FontStyle.Bold);
            label1.Location = new Point(94, 65);
            label1.Name = "label1";
            label1.Size = new Size(278, 28);
            label1.TabIndex = 14;
            label1.Text = "Write a price of the product";
            // 
            // Example2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 280);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(discountTxtbox);
            Controls.Add(priceTxtbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Example2";
            Text = "Example2";
            Load += Example2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox discountTxtbox;
        private TextBox priceTxtbox;
        private Label label2;
        private Label label1;
    }
}