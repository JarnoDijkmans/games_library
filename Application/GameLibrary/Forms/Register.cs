using Factory;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Register_form()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            UserService userService = UserFactory.userservice;

            string displayname = $"{txt_FirstName.Text}{txt_LastName.Text}";

            GameManagement user = new GameManagement(0, txt_FirstName.Text, txt_LastName.Text,
            displayname, txt_Email.Text, txt_birthdate.Text, txt_Phone.Text, txt_country.Text,
            txt_city.Text, txt_address.Text, "null", txt_Password.Text, txt_Email.Text, 2);

            if (userService.RegisterUser(user) == true)
            {
                MessageBox.Show ("Succesfully added");
            }
            else
            {
                MessageBox.Show("Something went wrong, please search contact");
            }

            var index = new Index(user);
            this.Hide();
            index.Show();
        }

    }
}
