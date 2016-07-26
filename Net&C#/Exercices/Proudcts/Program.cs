using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Products.Categories;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = ProductManager.GetInstance();
            ProductFactory productFactory = new ProductFactory();
            Product product;
            product = productFactory.CreateConcreteProduct(typeof(FastFood));
            Alergen gluten = new Alergen()
            {
                Name = "Gluten",
                Id = 1
            };
            Ingredient maize = new Ingredient()
            {
                Id = 1,
                Name = "Maize",
                Alergens = new List<Alergen>() {gluten}
            };
            product.Name = "Pizza Max";
            product.Description = "Large pizza";
             
        }
    }
}
