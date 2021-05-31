using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;
using System.Text;

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
