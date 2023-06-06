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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_See_payments = new System.Windows.Forms.Button();
            this.btn_AddNewGame = new System.Windows.Forms.Button();
            this.lbl_Welcome = new System.Windows.Forms.Label();
            this.txt_modify = new System.Windows.Forms.Label();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_showall = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.lv_games = new System.Windows.Forms.ListView();
            this.Id = new System.Windows.Forms.ColumnHeader();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.Price = new System.Windows.Forms.ColumnHeader();
            this.Releasedate = new System.Windows.Forms.ColumnHeader();
            this.Publisher = new System.Windows.Forms.ColumnHeader();
            this.Btn_Logout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Logout);
            this.panel1.Controls.Add(this.btn_See_payments);
            this.panel1.Controls.Add(this.btn_AddNewGame);
            this.panel1.Controls.Add(this.lbl_Welcome);
            this.panel1.Controls.Add(this.txt_modify);
            this.panel1.Controls.Add(this.btn_Modify);
            this.panel1.Controls.Add(this.btn_showall);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txt_Search);
            this.panel1.Controls.Add(this.lv_games);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 1000);
            this.panel1.TabIndex = 0;
            // 
            // btn_See_payments
            // 
            this.btn_See_payments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_See_payments.BackColor = System.Drawing.Color.Black;
            this.btn_See_payments.ForeColor = System.Drawing.Color.Yellow;
            this.btn_See_payments.Location = new System.Drawing.Point(150, 48);
            this.btn_See_payments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_See_payments.Name = "btn_See_payments";
            this.btn_See_payments.Size = new System.Drawing.Size(135, 41);
            this.btn_See_payments.TabIndex = 18;
            this.btn_See_payments.Text = "See Payments";
            this.btn_See_payments.UseVisualStyleBackColor = false;
            this.btn_See_payments.Click += new System.EventHandler(this.btn_See_payments_Click);
            // 
            // btn_AddNewGame
            // 
            this.btn_AddNewGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddNewGame.BackColor = System.Drawing.Color.Black;
            this.btn_AddNewGame.ForeColor = System.Drawing.Color.Yellow;
            this.btn_AddNewGame.Location = new System.Drawing.Point(793, 916);
            this.btn_AddNewGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_AddNewGame.Name = "btn_AddNewGame";
            this.btn_AddNewGame.Size = new System.Drawing.Size(170, 45);
            this.btn_AddNewGame.TabIndex = 17;
            this.btn_AddNewGame.Text = "Add New Game";
            this.btn_AddNewGame.UseVisualStyleBackColor = false;
            this.btn_AddNewGame.Click += new System.EventHandler(this.btn_AddNewGame_Click);
            // 
            // lbl_Welcome
            // 
            this.lbl_Welcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Welcome.AutoSize = true;
            this.lbl_Welcome.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_Welcome.Location = new System.Drawing.Point(690, 59);
            this.lbl_Welcome.Name = "lbl_Welcome";
            this.lbl_Welcome.Size = new System.Drawing.Size(0, 46);
            this.lbl_Welcome.TabIndex = 16;
            // 
            // txt_modify
            // 
            this.txt_modify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_modify.AutoSize = true;
            this.txt_modify.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_modify.ForeColor = System.Drawing.Color.White;
            this.txt_modify.Location = new System.Drawing.Point(1283, 900);
            this.txt_modify.Name = "txt_modify";
            this.txt_modify.Size = new System.Drawing.Size(304, 25);
            this.txt_modify.TabIndex = 15;
            this.txt_modify.Text = "Modify selected game details here:";
            this.txt_modify.Visible = false;
            // 
            // btn_Modify
            // 
            this.btn_Modify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Modify.BackColor = System.Drawing.Color.Black;
            this.btn_Modify.ForeColor = System.Drawing.Color.Yellow;
            this.btn_Modify.Location = new System.Drawing.Point(1472, 930);
            this.btn_Modify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(86, 31);
            this.btn_Modify.TabIndex = 14;
            this.btn_Modify.Text = "Modify";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Visible = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_showall
            // 
            this.btn_showall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_showall.BackColor = System.Drawing.Color.Black;
            this.btn_showall.ForeColor = System.Drawing.Color.Yellow;
            this.btn_showall.Location = new System.Drawing.Point(1435, 116);
            this.btn_showall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_showall.Name = "btn_showall";
            this.btn_showall.Size = new System.Drawing.Size(123, 39);
            this.btn_showall.TabIndex = 4;
            this.btn_showall.Text = "Show all";
            this.btn_showall.UseVisualStyleBackColor = false;
            this.btn_showall.Click += new System.EventHandler(this.btn_showall_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_search.BackColor = System.Drawing.Color.Black;
            this.btn_search.ForeColor = System.Drawing.Color.Yellow;
            this.btn_search.Location = new System.Drawing.Point(423, 116);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(95, 37);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Search.BackColor = System.Drawing.Color.Black;
            this.txt_Search.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Search.ForeColor = System.Drawing.Color.White;
            this.txt_Search.Location = new System.Drawing.Point(151, 118);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(266, 31);
            this.txt_Search.TabIndex = 1;
            // 
            // lv_games
            // 
            this.lv_games.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lv_games.BackColor = System.Drawing.Color.Black;
            this.lv_games.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Title,
            this.Price,
            this.Releasedate,
            this.Publisher});
            this.lv_games.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lv_games.ForeColor = System.Drawing.Color.White;
            this.lv_games.FullRowSelect = true;
            this.lv_games.Location = new System.Drawing.Point(150, 163);
            this.lv_games.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_games.Name = "lv_games";
            this.lv_games.Size = new System.Drawing.Size(1409, 732);
            this.lv_games.TabIndex = 0;
            this.lv_games.UseCompatibleStateImageBehavior = false;
            this.lv_games.View = System.Windows.Forms.View.Details;
            this.lv_games.Click += new System.EventHandler(this.lv_games_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 40;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 160;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 50;
            // 
            // Releasedate
            // 
            this.Releasedate.Text = "Release date";
            this.Releasedate.Width = 100;
            // 
            // Publisher
            // 
            this.Publisher.Text = "Publisher";
            this.Publisher.Width = 140;
            // 
            // Btn_Logout
            // 
            this.Btn_Logout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Logout.BackColor = System.Drawing.Color.Black;
            this.Btn_Logout.ForeColor = System.Drawing.Color.White;
            this.Btn_Logout.Location = new System.Drawing.Point(1435, 48);
            this.Btn_Logout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Logout.Name = "Btn_Logout";
            this.Btn_Logout.Size = new System.Drawing.Size(123, 34);
            this.Btn_Logout.TabIndex = 19;
            this.Btn_Logout.Text = "Logout";
            this.Btn_Logout.UseVisualStyleBackColor = false;
            this.Btn_Logout.Click += new System.EventHandler(this.Btn_Logout_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(28)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1688, 1000);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Index";
            this.Text = "Index";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btn_search;
        private TextBox txt_Search;
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
        private Button btn_AddNewGame;
        private Button btn_See_payments;
        private Button Btn_Logout;
    }
}