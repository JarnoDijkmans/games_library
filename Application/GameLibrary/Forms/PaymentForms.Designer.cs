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
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { UserId, PaymentID, Date, GameID });
            listView1.Location = new Point(70, 78);
            listView1.Name = "listView1";
            listView1.Size = new Size(535, 227);
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
            // 
            // GameID
            // 
            GameID.Text = "GameID";
            // 
            // btn_see_payments
            // 
            btn_see_payments.Location = new Point(197, 26);
            btn_see_payments.Name = "btn_see_payments";
            btn_see_payments.Size = new Size(146, 23);
            btn_see_payments.TabIndex = 1;
            btn_see_payments.Text = "Click here for payments";
            btn_see_payments.UseVisualStyleBackColor = true;
            btn_see_payments.Click += btn_see_payments_Click;
            // 
            // CB_UserIDS
            // 
            CB_UserIDS.FormattingEnabled = true;
            CB_UserIDS.Location = new Point(70, 26);
            CB_UserIDS.Name = "CB_UserIDS";
            CB_UserIDS.Size = new Size(121, 23);
            CB_UserIDS.TabIndex = 2;
            // 
            // PaymentForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CB_UserIDS);
            Controls.Add(btn_see_payments);
            Controls.Add(listView1);
            Name = "PaymentForms";
            Text = "PaymentForms";
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
    }
}