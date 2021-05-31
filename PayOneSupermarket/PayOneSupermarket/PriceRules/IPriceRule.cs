using PayOneSupermarket.Product;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    public interface IPriceRule
    {
        PriceRuleCalculateResult CalculatePrice(ScannedProduct product, List<ScannedProduct> allScannedProducts);
        bool CanApplyToProduct(ScannedProduct product, IEnumerable<ScannedProduct> allScannedProducts);
        ProductRulePriority GetPriority();
    }
}
