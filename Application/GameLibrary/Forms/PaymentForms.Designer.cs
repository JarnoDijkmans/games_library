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
            listView1 = new ListView();
            UserId = new ColumnHeader();
            PaymentID = new ColumnHeader();
            Date = new ColumnHeader();
            GameID = new ColumnHeader();
            btn_see_payments = new Button();
            CB_UserIDS = new ComboBox();
            btn_back = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.None;
            listView1.BackColor = Color.Black;
            listView1.Columns.AddRange(new ColumnHeader[] { UserId, PaymentID, Date, GameID });
            listView1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.ForeColor = Color.White;
            listView1.Location = new Point(222, 157);
            listView1.Name = "listView1";
            listView1.Size = new Size(933, 475);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // UserId
            // 
            UserId.Text = "UserID";
            // 
            // PaymentID
            // 
            PaymentID.Text = "PaymentID";
            // 
            // Date
            // 
            Date.Text = "Date";
            Date.Width = 120;
            // 
            // GameID
            // 
            GameID.Text = "GameID";
            GameID.Width = 80;
            // 
            // btn_see_payments
            // 
            btn_see_payments.Anchor = AnchorStyles.None;
            btn_see_payments.BackColor = Color.Black;
            btn_see_payments.ForeColor = Color.Yellow;
            btn_see_payments.Location = new Point(383, 97);
            btn_see_payments.Name = "btn_see_payments";
            btn_see_payments.Size = new Size(162, 30);
            btn_see_payments.TabIndex = 1;
            btn_see_payments.Text = "Click here for payments";
            btn_see_payments.UseVisualStyleBackColor = false;
            btn_see_payments.Click += btn_see_payments_Click;
            // 
            // CB_UserIDS
            // 
            CB_UserIDS.Anchor = AnchorStyles.None;
            CB_UserIDS.BackColor = Color.Black;
            CB_UserIDS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            CB_UserIDS.ForeColor = SystemColors.Window;
            CB_UserIDS.FormattingEnabled = true;
            CB_UserIDS.Location = new Point(222, 97);
            CB_UserIDS.Name = "CB_UserIDS";
            CB_UserIDS.Size = new Size(155, 28);
            CB_UserIDS.TabIndex = 2;
            // 
            // btn_back
            // 
            btn_back.Anchor = AnchorStyles.None;
            btn_back.BackColor = Color.Black;
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(1063, 97);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(92, 30);
            btn_back.TabIndex = 3;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // PaymentForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 28, 54);
            ClientSize = new Size(1394, 644);
            Controls.Add(btn_back);
            Controls.Add(CB_UserIDS);
            Controls.Add(btn_see_payments);
            Controls.Add(listView1);
            Name = "PaymentForms";
            Text = "PaymentForms";
            WindowState = FormWindowState.Maximized;
            Load += PaymentForms_Load;
            ResumeLayout(false);
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
    }
}