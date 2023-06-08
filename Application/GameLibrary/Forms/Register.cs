using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
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
    public partial class Register_form : Form
    {
        Result result;
        public Register_form()
        {
            InitializeComponent();
            result = new Result("");
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            UserService userService = UserFactory.userservice;

            string displayname = $"{txt_FirstName.Text}{txt_LastName.Text}";

            try
            {
                if (result != null)
                {
                    result.ValidateRegisterFields(txt_FirstName.Text, txt_LastName.Text, txt_Email.Text, txt_birthdate.Text, txt_Phone.Text, txt_country.Text, txt_city.Text, txt_address.Text, txt_Password.Text);
                    GameManagement user = new GameManagement(0, txt_FirstName.Text, txt_LastName.Text,
                     displayname, txt_Email.Text, txt_birthdate.Text, txt_Phone.Text, txt_country.Text,
                     txt_city.Text, txt_address.Text, "null", txt_Password.Text, txt_Email.Text, 2);

                    if (userService.RegisterUser(user) == true)
                    {
                        MessageBox.Show("Succesfully added");
                        var index = new Index(user);
                        this.Hide();
                        index.Show();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong, please search contact");
                    }

                }
                else { MessageBox.Show("Validation object is not initialized."); }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
