﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;
using Proudcts;

namespace Products
{
    public class ProductManager
    {
        private static ProductManager instance;

        private List<Product> products;

        private static uint idGenerator = 0;

        public List<Product> Products
        {
            get { return products.ToList(); }
        }

        private ProductManager()
        {
            products = new List<Product>();
        }

        public static ProductManager GetInstance()
        {
            return instance ?? (instance = new ProductManager());
        }

        public void AddProduct(Product product)
        {
            product.Id = idGenerator;
            idGenerator++;
            products.Add(product);
        }

        public void AddProducts(params Product[] products)
        {
            foreach (var product in products)
            {
                AddProduct(product);
            }
        }

        public void Update(Product product)
        {
            int index = -1;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == product.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index < 0)
            {
                throw new NotFoundException($"Product with same id {product.Id} doesn't exists!");
            }

            products.RemoveAt(index);
            products.Insert(index, product);
        }


        public void Remove(Product product)
        {
            if (!products.Remove(product))
            {
                throw new NotFoundException($"Product doesn't exists!");
            }
        }

        public void Insert(int index, Product product)
        {
            products.Insert(index, product);
        }

        public void RemoveAt(int index)
        {
            products.RemoveAt(index);
        }

        public void UpdateAt(int index, Product product)
        {
            products.RemoveAt(index);
            products.Insert(index, product);
        }

        public List<Product> FindProductsContainsAllIngredients(List<Ingredient> ingredients)
        {
            List<Product> products =
                Products.FindAll(item => item.Ingredients.Intersect(ingredients).Count() == ingredients.Count);

            return products;
        }

        public List<Product> FindProductsContainsOneOrMoreIngredients(List<Ingredient> ingredients)
        {
            List<Product> products =
                Products.FindAll(item => item.Ingredients.Intersect(ingredients).Any());

            return products;
        }

        public List<Product> FindProductsNotContainsIngredients(List<Ingredient> ingredients)
        {
            List<Product> products =
                Products.FindAll(item => !item.Ingredients.Intersect(ingredients).Any());

            return products;

        }

        public List<Product> FindProductsNotAlergic(List<Alergen> alergens)
        {
            List<Product> products =
                Products.FindAll(
                    item => !item.Ingredients.FindAll(ingredient => ingredient.Alergens.Intersect(alergens).Any()).Any());
            return products;
        }

        public List<Product> FindProduct(List<Ingredient> containIngredients, List<Ingredient> requeirdIngredients,
            List<Ingredient> notContainIngredients, List<Alergen> alergens)
        {
            List<Product> products = (List<Product>)
                FindProductsContainsAllIngredients(containIngredients)
                    .Intersect(FindProductsContainsOneOrMoreIngredients(requeirdIngredients))
                    .Intersect(FindProductsNotContainsIngredients(notContainIngredients))
                    .Intersect(FindProductsNotAlergic(alergens));

            return products;
        }

    }
}
