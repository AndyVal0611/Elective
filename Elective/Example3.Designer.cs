namespace Elective
{
    partial class Example3
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
            QUOTIENT = new Button();
            PRODUCT = new Button();
            DIFFERENCE = new Button();
            SUM = new Button();
            displayTxtbox = new TextBox();
            fourthNumTxtbox = new TextBox();
            thirdNumTxtbox = new TextBox();
            secondNumTxtbox = new TextBox();
            firstNumTxtbox = new TextBox();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // QUOTIENT
            // 
            QUOTIENT.Location = new Point(564, 319);
            QUOTIENT.Name = "QUOTIENT";
            QUOTIENT.Size = new Size(155, 66);
            QUOTIENT.TabIndex = 27;
            QUOTIENT.Text = "QUOTIENT";
            QUOTIENT.UseVisualStyleBackColor = true;
            QUOTIENT.Click += QUOTIENT_Click;
            // 
            // PRODUCT
            // 
            PRODUCT.Location = new Point(403, 319);
            PRODUCT.Name = "PRODUCT";
            PRODUCT.Size = new Size(155, 66);
            PRODUCT.TabIndex = 26;
            PRODUCT.Text = "PRODUCT";
            PRODUCT.UseVisualStyleBackColor = true;
            PRODUCT.Click += PRODUCT_Click;
            // 
            // DIFFERENCE
            // 
            DIFFERENCE.Location = new Point(242, 319);
            DIFFERENCE.Name = "DIFFERENCE";
            DIFFERENCE.Size = new Size(155, 66);
            DIFFERENCE.TabIndex = 25;
            DIFFERENCE.Text = "DIFFERENCE";
            DIFFERENCE.UseVisualStyleBackColor = true;
            DIFFERENCE.Click += DIFFERENCE_Click;
            // 
            // SUM
            // 
            SUM.Location = new Point(81, 319);
            SUM.Name = "SUM";
            SUM.Size = new Size(155, 66);
            SUM.TabIndex = 24;
            SUM.Text = "SUM";
            SUM.UseVisualStyleBackColor = true;
            SUM.Click += SUM_Click;
            // 
            // displayTxtbox
            // 
            displayTxtbox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            displayTxtbox.Location = new Point(340, 235);
            displayTxtbox.Name = "displayTxtbox";
            displayTxtbox.Size = new Size(336, 47);
            displayTxtbox.TabIndex = 23;
            // 
            // fourthNumTxtbox
            // 
            fourthNumTxtbox.Location = new Point(340, 188);
            fourthNumTxtbox.Name = "fourthNumTxtbox";
            fourthNumTxtbox.Size = new Size(336, 27);
            fourthNumTxtbox.TabIndex = 22;
            // 
            // thirdNumTxtbox
            // 
            thirdNumTxtbox.Location = new Point(340, 149);
            thirdNumTxtbox.Name = "thirdNumTxtbox";
            thirdNumTxtbox.Size = new Size(336, 27);
            thirdNumTxtbox.TabIndex = 21;
            // 
            // secondNumTxtbox
            // 
            secondNumTxtbox.Location = new Point(340, 110);
            secondNumTxtbox.Name = "secondNumTxtbox";
            secondNumTxtbox.Size = new Size(336, 27);
            secondNumTxtbox.TabIndex = 20;
            // 
            // firstNumTxtbox
            // 
            firstNumTxtbox.Location = new Point(340, 66);
            firstNumTxtbox.Name = "firstNumTxtbox";
            firstNumTxtbox.Size = new Size(336, 27);
            firstNumTxtbox.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(126, 255);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 18;
            label6.Text = "Output Display";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 195);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 17;
            label3.Text = "Fourth Input Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 156);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 16;
            label4.Text = "Third Input Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 120);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 15;
            label2.Text = "Second Input Data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 81);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 14;
            label1.Text = "First Input Data";
            // 
            // Example3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(QUOTIENT);
            Controls.Add(PRODUCT);
            Controls.Add(DIFFERENCE);
            Controls.Add(SUM);
            Controls.Add(displayTxtbox);
            Controls.Add(fourthNumTxtbox);
            Controls.Add(thirdNumTxtbox);
            Controls.Add(secondNumTxtbox);
            Controls.Add(firstNumTxtbox);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Example3";
            Text = "Example3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button QUOTIENT;
        private Button PRODUCT;
        private Button DIFFERENCE;
        private Button SUM;
        private TextBox displayTxtbox;
        private TextBox fourthNumTxtbox;
        private TextBox thirdNumTxtbox;
        private TextBox secondNumTxtbox;
        private TextBox firstNumTxtbox;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}