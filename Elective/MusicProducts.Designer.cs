namespace Elective
{
    partial class MusicProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicProducts));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtAlbumName = new TextBox();
            txtArtist = new TextBox();
            txtCategory = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtBarcode = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dgvInventory = new DataGridView();
            pbAlbumImage = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            txtManufacturer = new TextBox();
            txtReleaseYear = new TextBox();
            label10 = new Label();
            txtSearch = new TextBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbumImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.SeaShell;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(870, 520);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 172);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yellowtail", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(794, 228);
            label1.Name = "label1";
            label1.Size = new Size(355, 76);
            label1.TabIndex = 1;
            label1.Text = "Odyssey Music";
            label1.UseWaitCursor = true;
            // 
            // txtAlbumName
            // 
            txtAlbumName.Font = new Font("Gill Sans MT", 9F);
            txtAlbumName.Location = new Point(1178, 376);
            txtAlbumName.Name = "txtAlbumName";
            txtAlbumName.Size = new Size(233, 25);
            txtAlbumName.TabIndex = 2;
            // 
            // txtArtist
            // 
            txtArtist.Font = new Font("Gill Sans MT", 9F);
            txtArtist.Location = new Point(1178, 409);
            txtArtist.Name = "txtArtist";
            txtArtist.Size = new Size(233, 25);
            txtArtist.TabIndex = 3;
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Gill Sans MT", 9F);
            txtCategory.Location = new Point(1178, 442);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(233, 25);
            txtCategory.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Gill Sans MT", 9F);
            txtPrice.Location = new Point(1178, 569);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(233, 25);
            txtPrice.TabIndex = 6;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Gill Sans MT", 9F);
            txtQuantity.Location = new Point(1178, 538);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(233, 25);
            txtQuantity.TabIndex = 5;
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Gill Sans MT", 9F);
            txtBarcode.Location = new Point(1178, 343);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(233, 25);
            txtBarcode.TabIndex = 8;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // button1
            // 
            button1.BackColor = Color.PeachPuff;
            button1.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(1072, 610);
            button1.Name = "button1";
            button1.Size = new Size(112, 33);
            button1.TabIndex = 9;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PeachPuff;
            button2.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1312, 610);
            button2.Name = "button2";
            button2.Size = new Size(99, 33);
            button2.TabIndex = 10;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.PeachPuff;
            button3.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(1190, 610);
            button3.Name = "button3";
            button3.Size = new Size(116, 33);
            button3.TabIndex = 11;
            button3.Text = "CANCEL";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(1073, 344);
            label2.Name = "label2";
            label2.Size = new Size(66, 24);
            label2.TabIndex = 12;
            label2.Text = "Barcode";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(1072, 376);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 13;
            label3.Text = "Album Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(1073, 409);
            label4.Name = "label4";
            label4.Size = new Size(47, 24);
            label4.TabIndex = 14;
            label4.Text = "Artist";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(1073, 442);
            label5.Name = "label5";
            label5.Size = new Size(72, 24);
            label5.TabIndex = 15;
            label5.Text = "Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(1076, 569);
            label6.Name = "label6";
            label6.Size = new Size(44, 24);
            label6.TabIndex = 16;
            label6.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(1073, 536);
            label7.Name = "label7";
            label7.Size = new Size(70, 24);
            label7.TabIndex = 17;
            label7.Text = "Quantity";
            // 
            // dgvInventory
            // 
            dgvInventory.BackgroundColor = Color.LightYellow;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.GridColor = SystemColors.Info;
            dgvInventory.Location = new Point(493, 373);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(354, 319);
            dgvInventory.TabIndex = 24;
            dgvInventory.CellClick += dgvInventory_CellClick;
            dgvInventory.CellFormatting += dgvInventory_CellFormatting;
            // 
            // pbAlbumImage
            // 
            pbAlbumImage.BackColor = Color.LemonChiffon;
            pbAlbumImage.BorderStyle = BorderStyle.Fixed3D;
            pbAlbumImage.Location = new Point(870, 331);
            pbAlbumImage.Name = "pbAlbumImage";
            pbAlbumImage.Size = new Size(181, 174);
            pbAlbumImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbAlbumImage.TabIndex = 25;
            pbAlbumImage.TabStop = false;
            pbAlbumImage.Click += pbAlbumImage_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(1074, 506);
            label8.Name = "label8";
            label8.Size = new Size(101, 24);
            label8.TabIndex = 29;
            label8.Text = "Record Label";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Josefin Sans", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(1074, 474);
            label9.Name = "label9";
            label9.Size = new Size(109, 24);
            label9.TabIndex = 28;
            label9.Text = "Released Year";
            // 
            // txtManufacturer
            // 
            txtManufacturer.Font = new Font("Gill Sans MT", 9F);
            txtManufacturer.Location = new Point(1190, 505);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.Size = new Size(221, 25);
            txtManufacturer.TabIndex = 27;
            // 
            // txtReleaseYear
            // 
            txtReleaseYear.Font = new Font("Gill Sans MT", 9F);
            txtReleaseYear.Location = new Point(1190, 473);
            txtReleaseYear.Name = "txtReleaseYear";
            txtReleaseYear.Size = new Size(221, 25);
            txtReleaseYear.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Inter", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(495, 335);
            label10.Name = "label10";
            label10.Size = new Size(85, 21);
            label10.TabIndex = 31;
            label10.Text = "SEARCH";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Gill Sans MT", 9F);
            txtSearch.Location = new Point(586, 333);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 25);
            txtSearch.TabIndex = 30;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.PeachPuff;
            button4.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(1126, 649);
            button4.Name = "button4";
            button4.Size = new Size(116, 33);
            button4.TabIndex = 33;
            button4.Text = "DELETE";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.PeachPuff;
            button5.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(1248, 649);
            button5.Name = "button5";
            button5.Size = new Size(112, 33);
            button5.TabIndex = 32;
            button5.Text = "UPDATE";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.PeachPuff;
            button6.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(495, 702);
            button6.Name = "button6";
            button6.Size = new Size(116, 46);
            button6.TabIndex = 35;
            button6.Text = "CASHIER";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.PeachPuff;
            button7.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(628, 702);
            button7.Name = "button7";
            button7.Size = new Size(112, 46);
            button7.TabIndex = 34;
            button7.Text = "REFRESH";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkSalmon;
            btnLogout.Font = new Font("Marcellus SC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1295, 696);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(116, 46);
            btnLogout.TabIndex = 36;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // MusicProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1584, 905);
            Controls.Add(btnLogout);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(label10);
            Controls.Add(txtSearch);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(txtManufacturer);
            Controls.Add(txtReleaseYear);
            Controls.Add(pbAlbumImage);
            Controls.Add(dgvInventory);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtBarcode);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Controls.Add(txtCategory);
            Controls.Add(txtArtist);
            Controls.Add(txtAlbumName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "MusicProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MusicProducts";
            WindowState = FormWindowState.Maximized;
            Load += MusicProducts_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAlbumImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtAlbumName;
        private TextBox txtArtist;
        private TextBox txtCategory;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtBarcode;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvInventory;
        private PictureBox pbAlbumImage;
        private Label label8;
        private Label label9;
        private TextBox txtManufacturer;
        private TextBox txtReleaseYear;
        private Label label10;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        public TextBox txtSearch;
        public Button btnLogout;
    }
}