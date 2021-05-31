using System;
using System.Collections.Generic;
using System.Text;

namespace PayOneSupermarket.DTO
{
    public class Product
    {
        private readonly string name;

        private Product(string name)
        {
            this.name = name;
        }

        public static Product NewProduct(string name)
        {
            return new Product(name);
        }
    }
}
