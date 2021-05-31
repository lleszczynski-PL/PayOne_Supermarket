using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayOneSupermarket.DTO;
using System.Collections.Generic;

namespace PayOneSupermarket.Tests
{
    [TestClass()]
    public class CheckOutTests
    {
        [DataTestMethod()]
        public void Test_Totals()
        {
            var rules = new List<PricingRule>();

            Assert.AreEqual(0, Price("", rules));
            Assert.AreEqual(50, Price("A", rules));
            Assert.AreEqual(80, Price("AB", rules));
            Assert.AreEqual(115, Price("CDBA", rules));

            Assert.AreEqual(100, Price("AA", rules));
            Assert.AreEqual(130, Price("AAA", rules));
            Assert.AreEqual(180, Price("AAAA", rules));
            Assert.AreEqual(230, Price("AAAAA", rules));
            Assert.AreEqual(260, Price("AAAAAA", rules));

            Assert.AreEqual(160, Price("AAAB", rules));
            Assert.AreEqual(175, Price("AAABB", rules));
            Assert.AreEqual(190, Price("AAABBD", rules));
            Assert.AreEqual(190, Price("DABABA", rules));
        }

        private int Price(string goods, List<PricingRule> pricingRules)
        {
            var co = CheckOut.NewCheckout(pricingRules);
            char[] splitGoods = goods.ToCharArray();
            foreach (var g in splitGoods)
            {
                co.Scan(CreateProduct(g.ToString()));
            }
            return co.Total;
        }

        [TestMethod()]
        public void Test_Incremental()
        {
            var rules = new List<PricingRule>();
            var co = CheckOut.NewCheckout(rules);

            Assert.AreEqual(0, co.Total);
            co.Scan(CreateProduct("A")); Assert.AreEqual(50, co.Total);
            co.Scan(CreateProduct("B")); Assert.AreEqual(80, co.Total);
            co.Scan(CreateProduct("A")); Assert.AreEqual(130, co.Total);
            co.Scan(CreateProduct("A")); Assert.AreEqual(160, co.Total);
            co.Scan(CreateProduct("B")); Assert.AreEqual(175, co.Total);
        }

        private Product CreateProduct(string name)
        {
            return Product.NewProduct(name);
        }
    }
}