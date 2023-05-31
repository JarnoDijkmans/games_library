using LogicLayer;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration Configuration { get; }
        public string ImageUrl { get; set; }
        public DetailImageForm()
        {
            InitializeComponent();
            result = new Result("");
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
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

        private void btn_select_detailImage_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_Detail_Image.Text = imagePath;
            }
        }

        private string SelectImage()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                string imagePath = Configuration["ImagePath"];

                openFileDialog.InitialDirectory = Path.Combine(imagePath, "Images");
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = openFileDialog.FileName;
                    if (fullPath.StartsWith(imagePath))
                    {
                        string relativePath = fullPath.Substring(imagePath.Length);

                        if (!relativePath.StartsWith("\\"))
                        {
                            relativePath = "\\" + relativePath;
                        }

                        return relativePath;
                    }
                }
            }

            return string.Empty;
        }
    }
}
