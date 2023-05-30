using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal basePrice);
        decimal ApplyBirthdayDiscount(decimal basePrice, DateTime birthdate);
    }
}
