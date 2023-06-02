using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CheckoutRelated
{
    public class CheckoutInfo
    {
        public int PaymentID { get; set; }
        public string PaymentType { get; set; }

        public decimal TotalAmount { get; private set; }

        public List <int> GameIds { get; private set; }

        public int? userID { get; private set; }
        public DateTime DateOfPurchase { get; private set; }

        public CheckoutInfo()
        {
        }
        public CheckoutInfo(int paymentID, string paymentType, decimal totalAmount, List<int>gameIds, int? loggedInUser, DateTime dateOfPurchase) 
        {
            this.PaymentID = paymentID;
            this.PaymentType = paymentType;
            this.TotalAmount = totalAmount;
            this.GameIds = gameIds;
            this.userID = loggedInUser;
            this.DateOfPurchase = dateOfPurchase;
        }
    }
}
