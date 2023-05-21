using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.CartRelated
{
    public class CartViewModel
    {
        public decimal Subtotal { get;  set; }
        public decimal DiscountedTotal { get;  set; }
        public string DiscountCode { get;  set; }
        public List<Game> GamesInCart { get; set; }

        public CartViewModel() { }

        public CartViewModel(decimal subtotal, decimal discountedTotal, string discountCode, List<Game> gamesInCart)
        {
            Subtotal = subtotal;
            DiscountedTotal = discountedTotal;
            DiscountCode = discountCode;
            GamesInCart = gamesInCart;
        }
    }
}
