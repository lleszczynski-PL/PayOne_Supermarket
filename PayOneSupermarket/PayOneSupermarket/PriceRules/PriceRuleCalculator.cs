using PayOneSupermarket.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayOneSupermarket.PriceRules
{
    /// <summary>
    /// Calculate prices
    /// </summary>
    class PriceRuleCalculator
    {
        private readonly IEnumerable<IPriceRule> rules;
        private readonly IEnumerable<ScannedProduct> productsToCalculatePrices;
        private const int MaxIterations = 10000;

        internal PriceRuleCalculator(IEnumerable<IPriceRule> rules, IEnumerable<ScannedProduct> productsToCalculatePrices)
        {
            this.rules = rules;
            this.productsToCalculatePrices = productsToCalculatePrices;
        }

        public int CalculateTotalPrice()
        {
            return CalculatePrices();
        }

        private int CalculatePrices()
        {
            List<ScannedProduct> copyOfScannedProductList = MakeCopyToNotChangeOriginalList();

            int total = 0;
            int iterate = 0; //security for infinity loop
            while (copyOfScannedProductList.Count > 0)
            {
                if (iterate == MaxIterations)
                {
                    throw new OverflowException("Max iteration achived!");
                }

                var productToCalculate = copyOfScannedProductList.FirstOrDefault();
                if (productToCalculate != null)
                {
                    var bestRuleForProduct = FindTheBestRuleForProduct(productToCalculate, copyOfScannedProductList);

                    var calculationResult = bestRuleForProduct.CalculatePrice(productToCalculate, copyOfScannedProductList);

                    total += calculationResult.Price;
                    RemoveCalculatedProductsFromPendingCalculatedProducts(copyOfScannedProductList, calculationResult);

                    iterate++;
                }
                else
                {
                    break;
                }
            }
            
            return total;
        }

        private IPriceRule FindTheBestRuleForProduct(ScannedProduct product, IEnumerable<ScannedProduct> scannedProducts)
        {
            IPriceRule bestRule = null;
            foreach (var rule in rules.OrderByDescending(x => (int)x.GetPriority()))
            {
                if (rule.CanApplyToProduct(product, scannedProducts))
                {
                    bestRule = rule;
                    break;
                }
            }

            if (bestRule is null)
            {
                throw new ArgumentException($"Can't find rule for product {product.Name}");
            }
            else
            {
                return bestRule;
            }
        }

        private static void RemoveCalculatedProductsFromPendingCalculatedProducts(List<ScannedProduct> copyOfScannedProductList, PriceRuleCalculateResult calculationResult)
        {
            foreach (var calculatedProduct in calculationResult.ProductsForPrice.ToList())
            {
                copyOfScannedProductList.Remove(calculatedProduct);
            }
        }

        private List<ScannedProduct> MakeCopyToNotChangeOriginalList()
        {
            List<ScannedProduct> copyOfScannedProductList = new List<ScannedProduct>();
            copyOfScannedProductList.AddRange(productsToCalculatePrices);
            return copyOfScannedProductList;
        }
    }
}
