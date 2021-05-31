namespace PayOneSupermarket.Product
{
    public class ScannedProduct
    {
        private ScannedProduct(string name)
        {
            this.Name = name;
        }

        public static ScannedProduct NewProduct(string name)
        {
            return new ScannedProduct(name);
        }

        public string Name { get; }
    }
}
