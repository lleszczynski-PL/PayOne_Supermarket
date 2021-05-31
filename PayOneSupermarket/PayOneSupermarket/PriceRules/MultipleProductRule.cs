using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayOneSupermarket.PriceRules
{
    class MultipleProductRule : BasePriceRule, IPriceRule
    {
        private readonly int quantity;

        internal MultipleProductRule(string productName, int quantity, int priceForAllProducts, PriceRulePriority priority) : base(productName, priceForAllProducts, priority)
        {
            this.quantity = quantity;
        }

        public PriceRuleCalculateResult CalculatePrice(ScannedProduct product, List<ScannedProduct> allScannedProducts)
        {
            if (CanApplyToProduct(product, allScannedProducts))
            {
                return new PriceRuleCalculateResult(price, GetCalculatedProducts(allScannedProducts));
            }
            else
            {
                throw new ArgumentException("Can't apply rule to product. First check CanApplyToProduct method to check");
            }
        }

        public bool CanApplyToProduct(ScannedProduct product, IEnumerable<ScannedProduct> allScannedProducts)
        {
            if (product.Name.Equals(productName))
            {
                if (allScannedProducts.Count(x => IsEqual(x.Name)) >= quantity)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsEqual(string name)
        {
            return name.Equals(productName);
        }

        private IEnumerable<ScannedProduct> GetCalculatedProducts(List<ScannedProduct> allScannedProducts)
        {
            return allScannedProducts.Where(x => IsEqual(x.Name)).Take(quantity);
        }
    }
}
