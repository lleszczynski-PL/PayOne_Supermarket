using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket.PriceRules
{
    public class PriceRuleCreator
    {
        public IPriceRule NewConstantPrice(string productName, int price)
        {
            return new ConstantPriceRule();
        }

        public IPriceRule NewMultipleProduct(string productName, int price, int quantity)
        {
            return new MultipleProductRule();
        }
    }
}
