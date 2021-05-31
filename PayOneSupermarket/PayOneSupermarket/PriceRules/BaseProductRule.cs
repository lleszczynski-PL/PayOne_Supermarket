namespace PayOneSupermarket.PriceRules
{
    class BaseProductRule
    {
        protected readonly string productName;
        protected readonly int price;
        protected readonly ProductRulePriority priority;

        public BaseProductRule(string productName, int price, ProductRulePriority priority)
        {
            this.productName = productName;
            this.price = price;
            this.priority = priority;
        }

        public ProductRulePriority GetPriority()
        {
            return priority;
        }
    }

    public enum ProductRulePriority : int
    {
        Normal = 10,
        High = 20
    }
}
