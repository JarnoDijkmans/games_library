namespace Forms
{
    partial class Register_form
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
            this.btn_register = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.txt_country = new System.Windows.Forms.TextBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.txt_birthdate = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_register);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 626);
            this.panel1.TabIndex = 0;
            // 
            // btn_register
            // 
            this.btn_register.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_register.BackColor = System.Drawing.Color.Black;
            this.btn_register.Location = new System.Drawing.Point(459, 533);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(196, 33);
            this.btn_register.TabIndex = 1;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.txt_address);
            this.panel2.Controls.Add(this.txt_city);
            this.panel2.Controls.Add(this.txt_country);
            this.panel2.Controls.Add(this.txt_Phone);
            this.panel2.Controls.Add(this.txt_birthdate);
            this.panel2.Controls.Add(this.txt_Password);
            this.panel2.Controls.Add(this.txt_Email);
            this.panel2.Controls.Add(this.txt_LastName);
            this.panel2.Controls.Add(this.txt_FirstName);
            this.panel2.Location = new System.Drawing.Point(308, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 468);
            this.panel2.TabIndex = 0;
            // 
            // txt_address
            // 
            this.txt_address.BackColor = System.Drawing.Color.Black;
            this.txt_address.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_address.ForeColor = System.Drawing.Color.White;
            this.txt_address.Location = new System.Drawing.Point(48, 401);
            this.txt_address.Name = "txt_address";
            this.txt_address.PlaceholderText = "Address";
            this.txt_address.Size = new System.Drawing.Size(404, 34);
            this.txt_address.TabIndex = 8;
            // 
            // txt_city
            // 
            this.txt_city.BackColor = System.Drawing.Color.Black;
            this.txt_city.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_city.ForeColor = System.Drawing.Color.White;
            this.txt_city.Location = new System.Drawing.Point(48, 350);
            this.txt_city.Name = "txt_city";
            this.txt_city.PlaceholderText = "City";
            this.txt_city.Size = new System.Drawing.Size(404, 34);
            this.txt_city.TabIndex = 7;
            // 
            // txt_country
            // 
            this.txt_country.BackColor = System.Drawing.Color.Black;
            this.txt_country.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_country.ForeColor = System.Drawing.Color.White;
            this.txt_country.Location = new System.Drawing.Point(48, 296);
            this.txt_country.Name = "txt_country";
            this.txt_country.PlaceholderText = "Country";
            this.txt_country.Size = new System.Drawing.Size(404, 34);
            this.txt_country.TabIndex = 6;
            // 
            // txt_Phone
            // 
            this.txt_Phone.BackColor = System.Drawing.Color.Black;
            this.txt_Phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Phone.ForeColor = System.Drawing.Color.White;
            this.txt_Phone.Location = new System.Drawing.Point(48, 244);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.PlaceholderText = "Phone";
            this.txt_Phone.Size = new System.Drawing.Size(404, 34);
            this.txt_Phone.TabIndex = 5;
            // 
            // txt_birthdate
            // 
            this.txt_birthdate.BackColor = System.Drawing.Color.Black;
            this.txt_birthdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_birthdate.ForeColor = System.Drawing.Color.White;
            this.txt_birthdate.Location = new System.Drawing.Point(48, 191);
            this.txt_birthdate.Name = "txt_birthdate";
            this.txt_birthdate.PlaceholderText = "Birthdate";
            this.txt_birthdate.Size = new System.Drawing.Size(404, 34);
            this.txt_birthdate.TabIndex = 4;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.Black;
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Password.ForeColor = System.Drawing.Color.White;
            this.txt_Password.Location = new System.Drawing.Point(48, 138);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PlaceholderText = "Password";
            this.txt_Password.Size = new System.Drawing.Size(404, 34);
            this.txt_Password.TabIndex = 3;
            // 
            // txt_Email
            // 
            this.txt_Email.BackColor = System.Drawing.Color.Black;
            this.txt_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Email.ForeColor = System.Drawing.Color.White;
            this.txt_Email.Location = new System.Drawing.Point(48, 85);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.PlaceholderText = "Email";
            this.txt_Email.Size = new System.Drawing.Size(404, 34);
            this.txt_Email.TabIndex = 2;
            // 
            // txt_LastName
            // 
            this.txt_LastName.BackColor = System.Drawing.Color.Black;
            this.txt_LastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_LastName.ForeColor = System.Drawing.Color.White;
            this.txt_LastName.Location = new System.Drawing.Point(265, 30);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.PlaceholderText = "Last Name";
            this.txt_LastName.Size = new System.Drawing.Size(187, 34);
            this.txt_LastName.TabIndex = 1;
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.BackColor = System.Drawing.Color.Black;
            this.txt_FirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_FirstName.ForeColor = System.Drawing.Color.White;
            this.txt_FirstName.Location = new System.Drawing.Point(48, 30);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.PlaceholderText = "First Name";
            this.txt_FirstName.Size = new System.Drawing.Size(198, 34);
            this.txt_FirstName.TabIndex = 0;
            // 
            // Register_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(28)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1087, 626);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Register_form";
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btn_register;
        private TextBox txt_address;
        private TextBox txt_city;
        private TextBox txt_country;
        private TextBox txt_Phone;
        private TextBox txt_birthdate;
        private TextBox txt_Password;
        private TextBox txt_Email;
        private TextBox txt_LastName;
        private TextBox txt_FirstName;
    }
}