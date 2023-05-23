using Factory;
using LogicLayer.Models.UserFolder;

namespace Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lbl_register_Click(object sender, EventArgs e)
        {
            var register = new Register_form();
            this.Hide();
            register.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            User? loggedInUser = UserFactory.VerifyeLoginUser().validateUserCredentials(txt_username.Text, txt_password.Text);
            if (loggedInUser != null && loggedInUser.Role == 2)
            {
                var index = new Index(loggedInUser);
                this.Hide();
                index.Show();
            }
            else
            {
                MessageBox.Show("Oops something went wrong, Try again");
                return;
            }
        }
    }
}