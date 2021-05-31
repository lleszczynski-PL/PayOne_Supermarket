using PayOneSupermarket.Product;
using System.Collections.Generic;

namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Result for IPriceRule.CalculatePrice method
    /// </summary>
    public class PriceRuleCalculateResult
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="price">Price for all products</param>
        /// <param name="productsForPrice">Products bought by this price</param>
        public PriceRuleCalculateResult(int price, IEnumerable<ScannedProduct> productsForPrice)
        {
            Price = price;
            ProductsForPrice = productsForPrice;
        }

        /// <summary>
        /// Total Price for all products assigned to this rule
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// All products assigned to this rule
        /// </summary>
        public IEnumerable<ScannedProduct> ProductsForPrice { get; }
    }
}
