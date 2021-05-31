using PayOneSupermarket.PriceRules;
using PayOneSupermarket.Product;
using System.Collections.Generic;

namespace PayOneSupermarket
{
    /// <summary>
    /// Calculate total price for products in basket
    /// </summary>
    public class CheckOut
    {
        private readonly IEnumerable<IPriceRule> pricingRules;

        private int _total;
        private readonly List<ScannedProduct> _scannedProducts;

        private CheckOut(IEnumerable<IPriceRule> pricingRules)
        {
            this.pricingRules = pricingRules;
            _scannedProducts = new List<ScannedProduct>();
        }

        /// <summary>
        /// Create new instance of checkout
        /// </summary>
        /// <param name="priceRules">price rules for products</param>
        /// <returns></returns>
        public static CheckOut NewCheckout(IEnumerable<IPriceRule> priceRules)
        {
            return new CheckOut(priceRules);
        }

        /// <summary>
        /// Add product to basket
        /// </summary>
        /// <param name="product"></param>
        public void Scan(ScannedProduct product)
        {
            _scannedProducts.Add(product);
        }

        private void Recalculate()
        {
            _total = new PriceRuleCalculator(pricingRules, _scannedProducts).CalculateTotalPrice();
        }

        /// <summary>
        /// Total price for basket
        /// </summary>
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
