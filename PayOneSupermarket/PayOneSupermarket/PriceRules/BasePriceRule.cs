namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Base class for new price rules
    /// </summary>
    class BasePriceRule
    {
        protected readonly string productName;
        protected readonly int price;
        protected readonly PriceRulePriority priority;

        internal BasePriceRule(string productName, int price, PriceRulePriority priority)
        {
            this.productName = productName;
            this.price = price;
            this.priority = priority;
        }

        public PriceRulePriority GetPriority()
        {
            return priority;
        }
    }

    /// <summary>
    /// Priority for Price rules
    /// </summary>
    public enum PriceRulePriority : int
    {
        Normal = 10,
        High = 20
    }
}
