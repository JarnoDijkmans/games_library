namespace Forms
{
    partial class Index
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
            lbl_Welcome = new Label();
            txt_modify = new Label();
            btn_Modify = new Button();
            btn_showall = new Button();
            btn_search = new Button();
            textBox1 = new TextBox();
            lv_games = new ListView();
            Id = new ColumnHeader();
            Title = new ColumnHeader();
            Price = new ColumnHeader();
            Releasedate = new ColumnHeader();
            Publisher = new ColumnHeader();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_Welcome);
            panel1.Controls.Add(txt_modify);
            panel1.Controls.Add(btn_Modify);
            panel1.Controls.Add(btn_showall);
            panel1.Controls.Add(btn_search);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lv_games);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1477, 750);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lbl_Welcome
            // 
            lbl_Welcome.Anchor = AnchorStyles.None;
            lbl_Welcome.AutoSize = true;
            lbl_Welcome.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Welcome.ForeColor = Color.White;
            lbl_Welcome.Location = new Point(604, 44);
            lbl_Welcome.Name = "lbl_Welcome";
            lbl_Welcome.Size = new Size(0, 37);
            lbl_Welcome.TabIndex = 16;
            // 
            // txt_modify
            // 
            txt_modify.Anchor = AnchorStyles.None;
            txt_modify.AutoSize = true;
            txt_modify.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_modify.ForeColor = Color.White;
            txt_modify.Location = new Point(1123, 675);
            txt_modify.Name = "txt_modify";
            txt_modify.Size = new Size(241, 20);
            txt_modify.TabIndex = 15;
            txt_modify.Text = "Modify selected game details here:";
            txt_modify.Visible = false;
            // 
            // btn_Modify
            // 
            btn_Modify.Anchor = AnchorStyles.None;
            btn_Modify.Location = new Point(1289, 698);
            btn_Modify.Name = "btn_Modify";
            btn_Modify.Size = new Size(75, 23);
            btn_Modify.TabIndex = 14;
            btn_Modify.Text = "Modify";
            btn_Modify.UseVisualStyleBackColor = true;
            btn_Modify.Visible = false;
            btn_Modify.Click += btn_Modify_Click;
            // 
            // btn_showall
            // 
            btn_showall.Anchor = AnchorStyles.None;
            btn_showall.Location = new Point(1256, 87);
            btn_showall.Name = "btn_showall";
            btn_showall.Size = new Size(108, 29);
            btn_showall.TabIndex = 4;
            btn_showall.Text = "Show all";
            btn_showall.UseVisualStyleBackColor = true;
            btn_showall.Click += btn_showall_Click;
            // 
            // btn_search
            // 
            btn_search.Anchor = AnchorStyles.None;
            btn_search.Location = new Point(370, 87);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(83, 28);
            btn_search.TabIndex = 3;
            btn_search.Text = "Search";
            btn_search.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(131, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 23);
            textBox1.TabIndex = 1;
            // 
            // lv_games
            // 
            lv_games.Anchor = AnchorStyles.None;
            lv_games.BackColor = Color.Black;
            lv_games.Columns.AddRange(new ColumnHeader[] { Id, Title, Price, Releasedate, Publisher });
            lv_games.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lv_games.ForeColor = Color.White;
            lv_games.FullRowSelect = true;
            lv_games.Location = new Point(131, 122);
            lv_games.Name = "lv_games";
            lv_games.Size = new Size(1233, 550);
            lv_games.TabIndex = 0;
            lv_games.UseCompatibleStateImageBehavior = false;
            lv_games.View = View.Details;
            lv_games.SelectedIndexChanged += lv_games_SelectedIndexChanged;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 40;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 160;
            // 
            // Price
            // 
            Price.Text = "Price";
            Price.Width = 50;
            // 
            // Releasedate
            // 
            Releasedate.Text = "Release date";
            Releasedate.Width = 100;
            // 
            // Publisher
            // 
            Publisher.Text = "Publisher";
            Publisher.Width = 140;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 28, 54);
            ClientSize = new Size(1477, 750);
            Controls.Add(panel1);
            Name = "Index";
            Text = "Index";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_search;
        private TextBox textBox1;
        private ListView lv_games;
        private ColumnHeader Id;
        private ColumnHeader Title;
        private ColumnHeader Price;
        private ColumnHeader Releasedate;
        private ColumnHeader Publisher;
        private Button btn_showall;
        private Button btn_Modify;
        private Label txt_modify;
        private Label lbl_Welcome;
    }
}