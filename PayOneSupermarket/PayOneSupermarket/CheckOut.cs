using PayOneSupermarket.PriceRules;
using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayOneSupermarket
{
    public class CheckOut
    {
        private readonly IEnumerable<IPriceRule> pricingRules;

        private int _total;
        private List<ScannedProduct> _scannedProducts;

        private CheckOut(IEnumerable<IPriceRule> pricingRules)
        {
            this.pricingRules = pricingRules;
            _scannedProducts = new List<ScannedProduct>();
        }

        public static CheckOut NewCheckout(IEnumerable<IPriceRule> pricingRules)
        {
            return new CheckOut(pricingRules);
        }

        public void Scan(ScannedProduct product)
        {
            _scannedProducts.Add(product);
        }

        private void Recalculate()
        {
            _total = new PriceRuleCalculator(pricingRules, _scannedProducts).CalculateTotalPrice();
        }

        public int Total
        {
            get
            {
                Recalculate();
                return _total;
            }
        }
    }
}
