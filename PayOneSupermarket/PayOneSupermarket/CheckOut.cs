using PayOneSupermarket.DTO;
using PayOneSupermarket.PriceRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket
{
    public class CheckOut
    {
        private readonly IEnumerable<IPriceRule> pricingRules;

        private int _total;

        private CheckOut(IEnumerable<IPriceRule> pricingRules)
        {
            this.pricingRules = pricingRules;
        }

        public static CheckOut NewCheckout(IEnumerable<IPriceRule> pricingRules)
        {
            var checkout = new CheckOut(pricingRules);

            return checkout;
        }

        public void Scan(Product product)
        {

        }

        public int Total
        {
            get
            {
                return _total;
            }
        }
    }
}
