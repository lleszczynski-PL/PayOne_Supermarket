using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Constant price rule (use for: coca-cola costs $1)
    /// </summary>
    class ConstantPriceRule : BasePriceRule, IPriceRule
    {
        internal ConstantPriceRule(string productName, int price, PriceRulePriority priority) : base(productName, price, priority)
        {
        }
        public PriceRuleCalculateResult CalculatePrice(ScannedProduct product, List<ScannedProduct> allScannedProducts)
        {
            List<ScannedProduct> calculatedProducts = new List<ScannedProduct>()
            {
                product
            };

            return new PriceRuleCalculateResult(price, calculatedProducts);
        }

        public bool CanApplyToProduct(ScannedProduct product, IEnumerable<ScannedProduct> allScannedProducts)
        {
            return product.Name.Equals(productName, StringComparison.Ordinal);
        }
    }
}
