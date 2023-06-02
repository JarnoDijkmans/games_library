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

namespace Forms
{
    public partial class PaymentForms : Form
    {
        CheckoutService _checkoutService = CheckoutFactory.checkoutservice;
        UserService userService = UserFactory.userservice;
        public PaymentForms(User loggedInUser)
        {
            InitializeComponent();
            PopulateCombobox();
        }

        private void PaymentForms_Load(object sender, EventArgs e)
        {

        }

        private void btn_see_payments_Click(object sender, EventArgs e)
        {
            
            var payments = _checkoutService.GetPaymentById(Convert.ToInt32(CB_UserIDS.Text));
            listView1.Items.Clear();
            foreach (CheckoutInfo payment in payments)
            {
                ListViewItem gameinfo = new ListViewItem(new[] { payment.PaymentID.ToString(), payment.userID.ToString(), payment.DateOfPurchase.ToString() ,payment.GameIds.ToString() });
                listView1.Items.Add(gameinfo);
            }
        }

        private void PopulateCombobox()
        {
            List <User> users = userService.GetUsers();
            CB_UserIDS.Items.Add("None");
            foreach (var user in users)
            {
                CB_UserIDS.Items.Add(user.Id);
            }
        }
    }
}
