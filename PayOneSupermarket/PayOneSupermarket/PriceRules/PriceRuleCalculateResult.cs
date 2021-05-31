using PayOneSupermarket.Product;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    public class PriceRuleCalculateResult
    {
        public PriceRuleCalculateResult(int price, IEnumerable<ScannedProduct> productsForPrice)
        {
            Price = price;
            ProductsForPrice = productsForPrice;
        }

        public int Price { get; }
        public IEnumerable<ScannedProduct> ProductsForPrice { get; }
    }
}
