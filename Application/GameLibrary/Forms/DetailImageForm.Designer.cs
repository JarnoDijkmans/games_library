namespace Forms
{
    partial class DetailImageForm
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
            txt_Detail_Image = new TextBox();
            label1 = new Label();
            Btn_Ok = new Button();
            Btn_Cancel = new Button();
            btn_select_detailImage = new Button();
            SuspendLayout();
            // 
            // txt_Detail_Image
            // 
            txt_Detail_Image.Anchor = AnchorStyles.None;
            txt_Detail_Image.BackColor = Color.Black;
            txt_Detail_Image.ForeColor = Color.White;
            txt_Detail_Image.Location = new Point(59, 93);
            txt_Detail_Image.Name = "txt_Detail_Image";
            txt_Detail_Image.Size = new Size(308, 23);
            txt_Detail_Image.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(59, 75);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 1;
            label1.Text = "Here detail image URL please";
            // 
            // Btn_Ok
            // 
            Btn_Ok.BackColor = Color.Black;
            Btn_Ok.ForeColor = Color.Yellow;
            Btn_Ok.Location = new Point(254, 134);
            Btn_Ok.Name = "Btn_Ok";
            Btn_Ok.Size = new Size(113, 27);
            Btn_Ok.TabIndex = 2;
            Btn_Ok.Text = "Ok";
            Btn_Ok.UseVisualStyleBackColor = false;
            Btn_Ok.Click += Btn_Ok_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.BackColor = Color.Black;
            Btn_Cancel.ForeColor = Color.White;
            Btn_Cancel.Location = new Point(122, 134);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(113, 27);
            Btn_Cancel.TabIndex = 3;
            Btn_Cancel.Text = "Cancel";
            Btn_Cancel.UseVisualStyleBackColor = false;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // btn_select_detailImage
            // 
            btn_select_detailImage.Anchor = AnchorStyles.None;
            btn_select_detailImage.BackColor = Color.FromArgb(64, 64, 64);
            btn_select_detailImage.ForeColor = Color.Yellow;
            btn_select_detailImage.Location = new Point(358, 93);
            btn_select_detailImage.Margin = new Padding(3, 2, 3, 2);
            btn_select_detailImage.Name = "btn_select_detailImage";
            btn_select_detailImage.Size = new Size(112, 23);
            btn_select_detailImage.TabIndex = 27;
            btn_select_detailImage.Text = "Select Image";
            btn_select_detailImage.UseVisualStyleBackColor = false;
            btn_select_detailImage.Click += btn_select_detailImage_Click;
            // 
            // DetailImageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 28, 54);
            ClientSize = new Size(492, 244);
            Controls.Add(btn_select_detailImage);
            Controls.Add(Btn_Cancel);
            Controls.Add(Btn_Ok);
            Controls.Add(label1);
            Controls.Add(txt_Detail_Image);
            ForeColor = Color.White;
            Name = "DetailImageForm";
            Text = "DetailImageForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Detail_Image;
        private Label label1;
        private Button Btn_Ok;
        private Button Btn_Cancel;
        private Button btn_select_detailImage;
    }
}