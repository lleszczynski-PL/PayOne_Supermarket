using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayOneSupermarket.PriceRules;
using PayOneSupermarket.Product;
using System.Collections.Generic;
using System.Data;

namespace PayOneSupermarket.Tests
{
    [TestClass()]
    public class CheckOutTests
    {
        private List<IPriceRule> Rules;
        public CheckOutTests()
        {
            Rules = new List<IPriceRule>();

            var ruleCreator = new PriceRuleCreator();
            Rules.Add(ruleCreator.NewConstantPrice("", 0, false));
            Rules.Add(ruleCreator.NewConstantPrice("A", 50, false));
            Rules.Add(ruleCreator.NewConstantPrice("B", 30, false));
            Rules.Add(ruleCreator.NewConstantPrice("C", 20, false));
            Rules.Add(ruleCreator.NewConstantPrice("D", 15, false));

            Rules.Add(ruleCreator.NewMultipleProduct("A", 3, 130, true));
            Rules.Add(ruleCreator.NewMultipleProduct("B", 2, 45, true));
        }

        [DataTestMethod()]
        public void Test_Totals_From_Documentation()
        {
            Assert.AreEqual(0, Price(""));
            Assert.AreEqual(50, Price("A"));
            Assert.AreEqual(80, Price("AB"));
            Assert.AreEqual(115, Price("CDBA"));

            Assert.AreEqual(100, Price("AA"));
            Assert.AreEqual(130, Price("AAA"));
            Assert.AreEqual(180, Price("AAAA"));
            Assert.AreEqual(230, Price("AAAAA"));
            Assert.AreEqual(260, Price("AAAAAA"));

            Assert.AreEqual(160, Price("AAAB"));
            Assert.AreEqual(175, Price("AAABB"));
            Assert.AreEqual(190, Price("AAABBD"));
            Assert.AreEqual(190, Price("DABABA"));
        }

        private int Price(string goods)
        {
            var co = CheckOut.NewCheckout(Rules);
            char[] splitGoods = goods.ToCharArray();
            foreach (var g in splitGoods)
            {
                co.Scan(CreateProduct(g.ToString()));
            }
            return co.Total;
        }

        [TestMethod()]
        public void Test_Incremental_From_Documentation()
        {
            var co = CheckOut.NewCheckout(Rules);

            Assert.AreEqual(0, co.Total);
            co.Scan(CreateProduct("A"));
            Assert.AreEqual(50, co.Total);

            co.Scan(CreateProduct("B"));
            Assert.AreEqual(80, co.Total);

            co.Scan(CreateProduct("A"));
            Assert.AreEqual(130, co.Total);

            co.Scan(CreateProduct("A"));
            Assert.AreEqual(160, co.Total);

            co.Scan(CreateProduct("B"));
            Assert.AreEqual(175, co.Total);
        }

        private ScannedProduct CreateProduct(string name)
        {
            return ScannedProduct.NewProduct(name);
        }
    }
}