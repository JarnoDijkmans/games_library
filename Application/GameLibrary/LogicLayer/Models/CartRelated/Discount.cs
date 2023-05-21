using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Discount
{
    public class Discount
    {
        public string Code { get; private set; }
        public string DiscountType { get; private set; }
        public int DiscountValue { get; private set; }

        public Discount() { }

        public Discount(string code, string discountType, int discountValue)
        {
            Code = code;
            DiscountType = discountType;
            DiscountValue = discountValue;
        }
    }
}
