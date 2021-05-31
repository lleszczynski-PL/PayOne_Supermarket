namespace PayOneSupermarket.Product
{
    /// <summary>
    /// Scanned product representation
    /// </summary>
    public class ScannedProduct
    {
        private ScannedProduct(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Create new instance of scaned product
        /// </summary>
        /// <param name="name">Product name</param>
        /// <returns></returns>
        public static ScannedProduct NewProduct(string name)
        {
            return new ScannedProduct(name);
        }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; }
    }
}
