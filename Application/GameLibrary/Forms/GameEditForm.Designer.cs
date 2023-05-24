namespace Forms
{
    partial class GameEditForm
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
            panel1 = new Panel();
            btn_Modify = new Button();
            groupBox4 = new GroupBox();
            lv_ImageDetails = new ListView();
            Number = new ColumnHeader();
            Url = new ColumnHeader();
            txt_thumbnail = new TextBox();
            txt_spotlight = new TextBox();
            txt_CoverArt = new TextBox();
            label16 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            groupBox3 = new GroupBox();
            CB_Feature3 = new ComboBox();
            CB_Feature2 = new ComboBox();
            CB_Feature1 = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox2 = new GroupBox();
            CB_Genre3 = new ComboBox();
            CB_Genre2 = new ComboBox();
            CB_Genre1 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            groupBox1 = new GroupBox();
            txt_description = new TextBox();
            label6 = new Label();
            txt_Trailerurl = new TextBox();
            label5 = new Label();
            txt_publisher = new TextBox();
            label4 = new Label();
            txt_releasedate = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txt_price = new TextBox();
            label1 = new Label();
            txt_Title = new TextBox();
            panel1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(btn_Modify);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(-139, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1336, 646);
            panel1.TabIndex = 0;
            // 
            // btn_Modify
            // 
            btn_Modify.BackColor = Color.Black;
            btn_Modify.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Modify.ForeColor = Color.Yellow;
            btn_Modify.Location = new Point(668, 584);
            btn_Modify.Name = "btn_Modify";
            btn_Modify.Size = new Size(106, 30);
            btn_Modify.TabIndex = 18;
            btn_Modify.Text = "Modify";
            btn_Modify.UseVisualStyleBackColor = false;
            btn_Modify.Click += btn_Modify_Click;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.None;
            groupBox4.BackColor = Color.Black;
            groupBox4.Controls.Add(lv_ImageDetails);
            groupBox4.Controls.Add(txt_thumbnail);
            groupBox4.Controls.Add(txt_spotlight);
            groupBox4.Controls.Add(txt_CoverArt);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label15);
            groupBox4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(906, 38);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(399, 548);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Game Genres";
            // 
            // lv_ImageDetails
            // 
            lv_ImageDetails.Anchor = AnchorStyles.None;
            lv_ImageDetails.BackColor = Color.Black;
            lv_ImageDetails.Columns.AddRange(new ColumnHeader[] { Number, Url });
            lv_ImageDetails.ForeColor = Color.White;
            lv_ImageDetails.Location = new Point(24, 244);
            lv_ImageDetails.Name = "lv_ImageDetails";
            lv_ImageDetails.Size = new Size(358, 271);
            lv_ImageDetails.TabIndex = 20;
            lv_ImageDetails.UseCompatibleStateImageBehavior = false;
            lv_ImageDetails.View = View.Details;
            // 
            // Number
            // 
            Number.Text = "Number";
            // 
            // Url
            // 
            Url.Text = "URL";
            Url.Width = 300;
            // 
            // txt_thumbnail
            // 
            txt_thumbnail.BackColor = Color.Black;
            txt_thumbnail.ForeColor = Color.White;
            txt_thumbnail.Location = new Point(24, 186);
            txt_thumbnail.Name = "txt_thumbnail";
            txt_thumbnail.Size = new Size(358, 27);
            txt_thumbnail.TabIndex = 19;
            // 
            // txt_spotlight
            // 
            txt_spotlight.BackColor = Color.Black;
            txt_spotlight.ForeColor = Color.White;
            txt_spotlight.Location = new Point(24, 120);
            txt_spotlight.Name = "txt_spotlight";
            txt_spotlight.Size = new Size(358, 27);
            txt_spotlight.TabIndex = 15;
            // 
            // txt_CoverArt
            // 
            txt_CoverArt.BackColor = Color.Black;
            txt_CoverArt.ForeColor = Color.White;
            txt_CoverArt.Location = new Point(24, 62);
            txt_CoverArt.Name = "txt_CoverArt";
            txt_CoverArt.Size = new Size(358, 27);
            txt_CoverArt.TabIndex = 14;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.White;
            label16.Location = new Point(24, 163);
            label16.Name = "label16";
            label16.Size = new Size(134, 20);
            label16.TabIndex = 9;
            label16.Text = "Image: Thumbnail*";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(24, 221);
            label13.Name = "label13";
            label13.Size = new Size(104, 20);
            label13.TabIndex = 5;
            label13.Text = "Image: Details";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.White;
            label14.Location = new Point(24, 97);
            label14.Name = "label14";
            label14.Size = new Size(125, 20);
            label14.TabIndex = 3;
            label14.Text = "Image: Spotlight*";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(24, 39);
            label15.Name = "label15";
            label15.Size = new Size(126, 20);
            label15.TabIndex = 1;
            label15.Text = "Image: Cover Art*";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.None;
            groupBox3.BackColor = Color.Black;
            groupBox3.Controls.Add(CB_Feature3);
            groupBox3.Controls.Add(CB_Feature2);
            groupBox3.Controls.Add(CB_Feature1);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(568, 337);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(300, 223);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Game Features";
            // 
            // CB_Feature3
            // 
            CB_Feature3.BackColor = Color.Black;
            CB_Feature3.ForeColor = Color.White;
            CB_Feature3.FormattingEnabled = true;
            CB_Feature3.Location = new Point(22, 174);
            CB_Feature3.Name = "CB_Feature3";
            CB_Feature3.Size = new Size(250, 28);
            CB_Feature3.TabIndex = 8;
            // 
            // CB_Feature2
            // 
            CB_Feature2.BackColor = Color.Black;
            CB_Feature2.ForeColor = Color.White;
            CB_Feature2.FormattingEnabled = true;
            CB_Feature2.Location = new Point(22, 111);
            CB_Feature2.Name = "CB_Feature2";
            CB_Feature2.Size = new Size(250, 28);
            CB_Feature2.TabIndex = 7;
            // 
            // CB_Feature1
            // 
            CB_Feature1.BackColor = Color.Black;
            CB_Feature1.ForeColor = Color.White;
            CB_Feature1.FormattingEnabled = true;
            CB_Feature1.Location = new Point(22, 54);
            CB_Feature1.Name = "CB_Feature1";
            CB_Feature1.Size = new Size(250, 28);
            CB_Feature1.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 152);
            label7.Name = "label7";
            label7.Size = new Size(140, 20);
            label7.TabIndex = 5;
            label7.Text = "Feature 3 (optional)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(22, 89);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 3;
            label8.Text = "Feature 2*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 31);
            label9.Name = "label9";
            label9.Size = new Size(76, 20);
            label9.TabIndex = 1;
            label9.Text = "Feature 1*";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.None;
            groupBox2.BackColor = Color.Black;
            groupBox2.Controls.Add(CB_Genre3);
            groupBox2.Controls.Add(CB_Genre2);
            groupBox2.Controls.Add(CB_Genre1);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(568, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(300, 221);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Game Genres";
            // 
            // CB_Genre3
            // 
            CB_Genre3.BackColor = Color.Black;
            CB_Genre3.ForeColor = Color.White;
            CB_Genre3.FormattingEnabled = true;
            CB_Genre3.Location = new Point(22, 174);
            CB_Genre3.Name = "CB_Genre3";
            CB_Genre3.Size = new Size(250, 28);
            CB_Genre3.TabIndex = 8;
            // 
            // CB_Genre2
            // 
            CB_Genre2.BackColor = Color.Black;
            CB_Genre2.ForeColor = Color.White;
            CB_Genre2.FormattingEnabled = true;
            CB_Genre2.Location = new Point(22, 111);
            CB_Genre2.Name = "CB_Genre2";
            CB_Genre2.Size = new Size(250, 28);
            CB_Genre2.TabIndex = 7;
            // 
            // CB_Genre1
            // 
            CB_Genre1.BackColor = Color.Black;
            CB_Genre1.ForeColor = Color.White;
            CB_Genre1.FormattingEnabled = true;
            CB_Genre1.Location = new Point(22, 54);
            CB_Genre1.Name = "CB_Genre1";
            CB_Genre1.Size = new Size(250, 28);
            CB_Genre1.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 152);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 5;
            label10.Text = "Genre 3 (optional)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(22, 89);
            label11.Name = "label11";
            label11.Size = new Size(66, 20);
            label11.TabIndex = 3;
            label11.Text = "Genre 2*";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 31);
            label12.Name = "label12";
            label12.Size = new Size(66, 20);
            label12.TabIndex = 1;
            label12.Text = "Genre 1*";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(txt_description);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txt_Trailerurl);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txt_publisher);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txt_releasedate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_price);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txt_Title);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(187, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 548);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "General Game information";
            // 
            // txt_description
            // 
            txt_description.BackColor = Color.Black;
            txt_description.ForeColor = Color.White;
            txt_description.Location = new Point(22, 174);
            txt_description.Margin = new Padding(3, 2, 3, 2);
            txt_description.Multiline = true;
            txt_description.Name = "txt_description";
            txt_description.ScrollBars = ScrollBars.Vertical;
            txt_description.Size = new Size(254, 157);
            txt_description.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 465);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 11;
            label6.Text = "Trailer URL*";
            // 
            // txt_Trailerurl
            // 
            txt_Trailerurl.BackColor = Color.Black;
            txt_Trailerurl.ForeColor = Color.White;
            txt_Trailerurl.Location = new Point(22, 488);
            txt_Trailerurl.Name = "txt_Trailerurl";
            txt_Trailerurl.Size = new Size(254, 27);
            txt_Trailerurl.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 402);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 9;
            label5.Text = "Publisher*";
            // 
            // txt_publisher
            // 
            txt_publisher.BackColor = Color.Black;
            txt_publisher.ForeColor = Color.White;
            txt_publisher.Location = new Point(22, 425);
            txt_publisher.Name = "txt_publisher";
            txt_publisher.Size = new Size(254, 27);
            txt_publisher.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 340);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 7;
            label4.Text = "Release date*";
            // 
            // txt_releasedate
            // 
            txt_releasedate.BackColor = Color.Black;
            txt_releasedate.ForeColor = Color.White;
            txt_releasedate.Location = new Point(22, 364);
            txt_releasedate.Name = "txt_releasedate";
            txt_releasedate.Size = new Size(254, 27);
            txt_releasedate.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 152);
            label3.Name = "label3";
            label3.Size = new Size(91, 20);
            label3.TabIndex = 5;
            label3.Text = "Description*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 89);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 3;
            label2.Text = "Price*";
            // 
            // txt_price
            // 
            txt_price.BackColor = Color.Black;
            txt_price.ForeColor = Color.White;
            txt_price.Location = new Point(22, 112);
            txt_price.Name = "txt_price";
            txt_price.Size = new Size(254, 27);
            txt_price.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 31);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 1;
            label1.Text = "Title*";
            // 
            // txt_Title
            // 
            txt_Title.BackColor = Color.Black;
            txt_Title.ForeColor = Color.White;
            txt_Title.Location = new Point(22, 54);
            txt_Title.Name = "txt_Title";
            txt_Title.Size = new Size(254, 27);
            txt_Title.TabIndex = 0;
            // 
            // GameEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 28, 54);
            ClientSize = new Size(1198, 643);
            Controls.Add(panel1);
            Name = "GameEditForm";
            Text = "GameEditForm";
            panel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private ComboBox CB_Feature3;
        private ComboBox CB_Feature2;
        private ComboBox CB_Feature1;
        private Label label7;
        private Label label8;
        private Label label9;
        private GroupBox groupBox2;
        private ComboBox CB_Genre3;
        private ComboBox CB_Genre2;
        private ComboBox CB_Genre1;
        private Label label10;
        private Label label11;
        private Label label12;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txt_Trailerurl;
        private Label label5;
        private TextBox txt_publisher;
        private Label label4;
        private TextBox txt_releasedate;
        private Label label3;
        private Label label2;
        private TextBox txt_price;
        private Label label1;
        private TextBox txt_Title;
        private TextBox txt_description;
        private GroupBox groupBox4;
        private Label label16;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button btn_Modify;
        private ListView lv_ImageDetails;
        private ColumnHeader Number;
        private ColumnHeader Url;
        private TextBox txt_thumbnail;
        private TextBox txt_spotlight;
        private TextBox txt_CoverArt;
    }
}