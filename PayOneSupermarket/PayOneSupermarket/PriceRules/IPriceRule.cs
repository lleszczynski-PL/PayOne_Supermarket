using PayOneSupermarket.Product;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Abstraction to implement price rules
    /// </summary>
    public interface IPriceRule
    {
        /// <summary>
        /// Calculate price for product
        /// </summary>
        /// <param name="product">Product to calculate price</param>
        /// <param name="allScannedProducts">All products from basket</param>
        /// <returns></returns>
        PriceRuleCalculateResult CalculatePrice(ScannedProduct product, List<ScannedProduct> allScannedProducts);

        /// <summary>
        /// Check rule can be used for product
        /// </summary>
        /// <param name="product">Product to calculate price</param>
        /// <param name="allScannedProducts">All products from basket</param>
        /// <returns></returns>
        bool CanApplyToProduct(ScannedProduct product, IEnumerable<ScannedProduct> allScannedProducts);

        /// <summary>
        /// Return priority for rule (e.g. special price will have higher priority)
        /// </summary>
        /// <returns></returns>
        PriceRulePriority GetPriority();
    }
}
