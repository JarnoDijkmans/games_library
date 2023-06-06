namespace Forms
{
    partial class PaymentForms
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.UserId = new System.Windows.Forms.ColumnHeader();
            this.PaymentID = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.GameID = new System.Windows.Forms.ColumnHeader();
            this.TotalPrice = new System.Windows.Forms.ColumnHeader();
            this.btn_see_payments = new System.Windows.Forms.Button();
            this.CB_UserIDS = new System.Windows.Forms.ComboBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserId,
            this.PaymentID,
            this.Date,
            this.GameID,
            this.TotalPrice});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.Location = new System.Drawing.Point(254, 209);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1066, 632);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // UserId
            // 
            this.UserId.Text = "UserID";
            this.UserId.Width = 100;
            // 
            // PaymentID
            // 
            this.PaymentID.Text = "PaymentID";
            this.PaymentID.Width = 120;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 160;
            // 
            // GameID
            // 
            this.GameID.Text = "GameID";
            this.GameID.Width = 100;
            // 
            // TotalPrice
            // 
            this.TotalPrice.Text = "TotalPrice";
            this.TotalPrice.Width = 120;
            // 
            // btn_see_payments
            // 
            this.btn_see_payments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_see_payments.BackColor = System.Drawing.Color.Black;
            this.btn_see_payments.ForeColor = System.Drawing.Color.Yellow;
            this.btn_see_payments.Location = new System.Drawing.Point(438, 129);
            this.btn_see_payments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_see_payments.Name = "btn_see_payments";
            this.btn_see_payments.Size = new System.Drawing.Size(185, 40);
            this.btn_see_payments.TabIndex = 1;
            this.btn_see_payments.Text = "Click here for payments";
            this.btn_see_payments.UseVisualStyleBackColor = false;
            this.btn_see_payments.Click += new System.EventHandler(this.btn_see_payments_Click);
            // 
            // CB_UserIDS
            // 
            this.CB_UserIDS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CB_UserIDS.BackColor = System.Drawing.Color.Black;
            this.CB_UserIDS.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CB_UserIDS.ForeColor = System.Drawing.SystemColors.Window;
            this.CB_UserIDS.FormattingEnabled = true;
            this.CB_UserIDS.Location = new System.Drawing.Point(254, 129);
            this.CB_UserIDS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_UserIDS.Name = "CB_UserIDS";
            this.CB_UserIDS.Size = new System.Drawing.Size(177, 33);
            this.CB_UserIDS.TabIndex = 2;
            // 
            // btn_back
            // 
            this.btn_back.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_back.BackColor = System.Drawing.Color.Black;
            this.btn_back.ForeColor = System.Drawing.Color.White;
            this.btn_back.Location = new System.Drawing.Point(1215, 129);
            this.btn_back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(105, 40);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // PaymentForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(28)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1593, 859);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.CB_UserIDS);
            this.Controls.Add(this.btn_see_payments);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PaymentForms";
            this.Text = "PaymentForms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader UserId;
        private ColumnHeader PaymentID;
        private ColumnHeader Date;
        private ColumnHeader GameID;
        private Button btn_see_payments;
        private ComboBox CB_UserIDS;
        private Button btn_back;
        private ColumnHeader TotalPrice;
    }
}