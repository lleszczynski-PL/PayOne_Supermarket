using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    class ConstantPriceRule : BaseProductRule, IPriceRule
    {
        public ConstantPriceRule(string productName, int price, ProductRulePriority priority) : base(productName, price, priority)
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
