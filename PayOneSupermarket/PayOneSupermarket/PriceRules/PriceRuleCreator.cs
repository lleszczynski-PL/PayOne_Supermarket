namespace PayOneSupermarket.PriceRules
{
    public class PriceRuleCreator
    {
        public IPriceRule NewConstantPrice(string productName, int price, bool isSpecialPrice)
        {
            return new ConstantPriceRule(productName, price, TranslateSpecialPriceToPriority(isSpecialPrice));
        }

        public IPriceRule NewMultipleProduct(string productName, int quantity, int price, bool isSpecialPrice)
        {
            return new MultipleProductRule(productName, quantity, price, TranslateSpecialPriceToPriority(isSpecialPrice));
        }

        private ProductRulePriority TranslateSpecialPriceToPriority(bool isSpecialPrice)
        {
            return isSpecialPrice ? ProductRulePriority.High : ProductRulePriority.Normal;
        }
    }
}
