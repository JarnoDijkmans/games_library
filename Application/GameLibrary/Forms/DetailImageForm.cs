using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class DetailImageForm : Form
    {
        Result result;
        public string ImageUrl { get; set; }
        public DetailImageForm()
        {
            InitializeComponent();
            result = new Result("");
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (result != null)
                {
                    ImageUrl = txt_Detail_Image.Text;
                    result.validateDetailImage(ImageUrl);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else { MessageBox.Show("Validation object is not initialized."); }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
