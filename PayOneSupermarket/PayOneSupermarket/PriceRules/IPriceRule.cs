using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket.PriceRules
{
    public interface IPriceRule
    {
        PriceRuleCalculateResult CalculatePrice(ScannedProduct product, List<ScannedProduct> allScannedProducts);
        bool CanApplyToProduct(ScannedProduct product, IEnumerable<ScannedProduct> allScannedProducts);
        ProductRulePriority GetPriority();
    }
}
