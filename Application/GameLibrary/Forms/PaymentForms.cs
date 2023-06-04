using DataLayer.DAL;
using Microsoft.Extensions.DependencyInjection;
using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Models.CheckoutRelated;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class PaymentForms : Form
    {
        CheckoutService _checkoutService = CheckoutFactory.checkoutservice;
        UserService userService = UserFactory.userservice;
        User loggedInUser;
        public PaymentForms(User loggedInUser)
        {
            InitializeComponent();
            PopulateCombobox();
            this.loggedInUser = loggedInUser;
        }

        private void PaymentForms_Load(object sender, EventArgs e)
        {

        }

        private void btn_see_payments_Click(object sender, EventArgs e)
        {
            if (CB_UserIDS.Text != null && CB_UserIDS.Text != "None" && CB_UserIDS.Text != "")
            {
                var payments = _checkoutService.GetPaymentById(Convert.ToInt32(CB_UserIDS.Text));
                listView1.Items.Clear();

                if (payments != null)
                {
                    var groupedPayments = payments
                    .GroupBy(p => new { p.PaymentID, p.userID, p.DateOfPurchase })
                    .Select(group => new
                    {
                        PaymentID = group.Key.PaymentID,
                        UserID = group.Key.userID,
                        DateOfPurchase = group.Key.DateOfPurchase,
                        GameIds = string.Join(", ", group.SelectMany(p => p.GameIds))
                    });
                    if (groupedPayments != null)
                    {
                        foreach (var payment in groupedPayments)
                        {
                            ListViewItem gameinfo = new ListViewItem(new[] { payment.PaymentID.ToString(), payment.UserID.ToString(), payment.DateOfPurchase.ToString(), payment.GameIds });
                            listView1.Items.Add(gameinfo);
                        }
                    }
                    else { MessageBox.Show("Oops something went wrong, Please ask for help"); }

                }
                else { MessageBox.Show("There are no payments for this particular person"); }
            }
            else
            {
                listView1.Items.Clear();
                MessageBox.Show("Please select a user first");
            }
            
        }


        private void PopulateCombobox()
        {
            List<User> users = userService.GetUsers();
            CB_UserIDS.Items.Add("None");
            foreach (var user in users)
            {
                CB_UserIDS.Items.Add(user.Id);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Index index = new Index(loggedInUser);
            this.Close();
            index.Show();
        }
    }
}
