using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Products;
using Products.Categories;
using Proudcts.Categories;

namespace Products
{
    public class ProductFactory
    {
        public Product CreateConcreteProduct(Type t)
        {
            if (t == typeof(Chocolate))
                return new Chocolate();

            if (t == typeof(DairyProduct))
                return new DairyProduct();

            if (t == typeof(FastFood))
                return new FastFood();

            if (t == typeof(Soup))
                return new Soup();

            if (t == typeof(Sauce))
                return new Sauce();
            return null;
        }
    }
}
