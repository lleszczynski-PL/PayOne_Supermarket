using PayOneSupermarket.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket
{
    public class CheckOut
    {
        private readonly IEnumerable<PricingRule> pricingRules;

        private int _total;

        private CheckOut(IEnumerable<PricingRule> pricingRules)
        {
            this.pricingRules = pricingRules;
        }

        public static CheckOut NewCheckout(IEnumerable<PricingRule> pricingRules)
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
