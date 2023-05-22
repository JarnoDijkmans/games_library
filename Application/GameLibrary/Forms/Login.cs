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
    }
}