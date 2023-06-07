using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal basePrice, DateTime birthdate = default);
    }
}
