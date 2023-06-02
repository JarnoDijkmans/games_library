using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IDiscountFactory
    {
        IDiscount GetDiscount(string type, decimal value);
    }
}
