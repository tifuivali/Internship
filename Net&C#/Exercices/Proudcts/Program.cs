using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Products.Categories;
using Proudcts.Categories;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            var productManager = ProductManager.GetInstance();
            var productFactory = new ProductFactory();
            var glutenAlergen = new Alergen()
            {
                Name = "Gluten",
                Id = 1
            };
            var eggsAlergen = new Alergen()
            {
                Id = 2,
                Name = "Eggs"
            };
            var fishAlergen = new Alergen()
            {
                Id = 3,
                Name = "Fish"
            };

            var milkAlergen = new Alergen()
            {
                Id = 4,
                Name = "Milk"
            };
            var mustardAlergen = new Alergen()
            {
                Id = 5,
                Name = "Mustard"
            };
            var peanutsAlergen = new Alergen()
            {
                Id = 6,
                Name = "Mustard"
            };
            var soyaAlergen = new Alergen()
            {
                Id = 7,
                Name = "Soya"
            };

            var maize = new Ingredient()
            {
                Id = 1,
                Name = "Maize",
                Alergens = new List<Alergen>() { glutenAlergen }
            };

            var whiteFlour = new Ingredient()
            {
                Id = 2,
                Name = "White Flour",
                Alergens = new List<Alergen>() { glutenAlergen }
            };

            var cheese = new Ingredient()
            {
                Id = 3,
                Name = "Cheese",
                Alergens = new List<Alergen>() { milkAlergen }
            };

            var water = new Ingredient()
            {
                Id = 4,
                Name = "Water"
            };
            var sugar = new Ingredient()
            {
                Id = 5,
                Name = "Sugar"
            };

            var pork = new Ingredient()
            {
                Id = 6,
                Name = "Pork"
            };

            var beef = new Ingredient()
            {
                Id = 7,
                Name = "Beef"
            };

            var soya = new Ingredient()
            {
                Id=8,
                Name = "Soya",
                Alergens = new List<Alergen>() { soyaAlergen}
            };

            var sunflowrOil = new Ingredient()
            {
                Id=9,
                Name = "Sunflowr Oil"
            };

            var pepper = new Ingredient()
            {
                Id=10,
                Name = "Pepper"
            };

            var mustard = new Ingredient()
            {
                Id=11,
                Name = "Mustard",
                Alergens = new List<Alergen>() { mustardAlergen}
            };

            var pizzaMax = productFactory.CreateConcreteProduct(typeof(FastFood));
            pizzaMax.Name = "Pizza Max";
            pizzaMax.Description = "Large pizza";
            pizzaMax.Ingredients = new List<Ingredient>() {whiteFlour,water,maize,pork,cheese};

            var soyaSauce = productFactory.CreateConcreteProduct(typeof(Sauce));
            soyaSauce.Name = "Soya Sausage";
            soyaSauce.Description = "Soya sauge ....";
            soyaSauce.Ingredients = new List<Ingredient>() {soya,water,sunflowrOil,pepper,mustard};

            productManager.AddProducts(pizzaMax,soyaSauce);

            Console.WriteLine("Result:");
            //Products that contains all specified ingredients.
            productManager.FindProductsContainsAllIngredients(new List<Ingredient>() { water, mustard }).ForEach(Console.WriteLine); 
            
            Console.WriteLine();
            Console.WriteLine("Result 2:");
            //Products that contains many specified ingredioents
            productManager.FindProductsContainsOneOrMoreIngredients(new List<Ingredient>() {pork,pepper}).ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Result 3:");
            //Products that not contains specified ingredients
            productManager.FindProductsNotContainsIngredients(new List<Ingredient>() {mustard,pepper}).ForEach(Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine("Result 4:");
            //Products that not contains specified alergens
            productManager.FindProductsNotAlergic(new List<Alergen>() {mustardAlergen,eggsAlergen,soyaAlergen}).ForEach(Console.WriteLine);


            Console.ReadKey();

        }
    }
}
