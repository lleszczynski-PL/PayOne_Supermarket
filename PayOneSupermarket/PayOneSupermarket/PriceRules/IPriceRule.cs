using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket.PriceRules
{
    public interface IPriceRule
    {
        int CalculatePrice();
    }
}
