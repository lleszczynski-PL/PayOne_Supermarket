namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Facade to create price rules
    /// </summary>
    public class PriceRuleCreator
    {
        /// <summary>
        /// Constant price - 1 product with specyfied price
        /// </summary>
        /// <param name="productName">Product name</param>
        /// <param name="price">Product price</param>
        /// <param name="isSpecialPrice">Rule is special price or not</param>
        /// <returns></returns>
        public IPriceRule NewConstantPrice(string productName, int price, bool isSpecialPrice)
        {
            return new ConstantPriceRule(productName, price, TranslateSpecialPriceToPriority(isSpecialPrice));
        }

        /// <summary>
        /// Multiple Product - use when you have rule for some products with the same type (w.g. when you buy 3 coca-cola, then you will pay 100 for this 3 instead of 120
        /// </summary>
        /// <param name="productName">Product name</param>
        /// <param name="quantity">Number of products with the same name in basket</param>
        /// <param name="price">Price for all products</param>
        /// <param name="isSpecialPrice">Rule is special price or not</param>
        /// <returns></returns>
        public IPriceRule NewMultipleProduct(string productName, int quantity, int price, bool isSpecialPrice)
        {
            return new MultipleProductRule(productName, quantity, price, TranslateSpecialPriceToPriority(isSpecialPrice));
        }

        private PriceRulePriority TranslateSpecialPriceToPriority(bool isSpecialPrice)
        {
            return isSpecialPrice ? PriceRulePriority.High : PriceRulePriority.Normal;
        }
    }
}
