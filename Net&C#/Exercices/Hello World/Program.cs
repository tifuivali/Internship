using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(3);
            if (IsDayInWeekend(dt))
            {
                Console.WriteLine("Today is a weekend day.");
            }
            else
            {
                Console.WriteLine("Today is not a weekend day.");
            }

            PrintSeasonsMesages(Seasons.Autumn);

            string[] coutries = { "USA", "Romania", "Italy", "Germany", "France", "Belgium", "Grece", "Brasil" };
            string highestCoutry = GetCountryHighestOf(coutries);
            Console.WriteLine("Coutry highest with highest name is {0} , length: {1}", highestCoutry, highestCoutry.Length);
            highestCoutry = GetHighestCountry("USA", "Belgium", "Romania", "Italy", "Germany", "France", "Grece", "Brasil");
            Console.WriteLine("Coutry 2 highest with highest name is {0} , length: {1}", highestCoutry, highestCoutry.Length);

            double priceWithDiscount;
            int age = 12;
            double price = 100;
            CalculatePriceWithDiscount(price, age, out priceWithDiscount);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount out:{2}", price, age, priceWithDiscount);

            age = 6;
            price = 100;
            double initialPrice = price;
            CalculatePriceWithDiscount(ref price, age);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount ref:{2}", initialPrice, age, price);

            age = 6;
            price = 100;
            double priceWithLastDiscount = 0;
            priceWithLastDiscount = CalculatePriceWithDiscountType(price, age, DiscountType.BestDeal);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3}", initialPrice, age, priceWithLastDiscount, DiscountType.BestDeal);

            age = 12;
            price = 100;
            priceWithLastDiscount = CalculatePriceWithDiscountType(price, age);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3}", initialPrice, age, priceWithLastDiscount, DiscountType.General);

            age = 12;
            price = 100;
            priceWithLastDiscount = CalculatePriceWithDiscountTypeOptionalAgeOptional(price);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3}", initialPrice, 14, priceWithLastDiscount, DiscountType.General);

            age = 12;
            price = 100;
            priceWithLastDiscount = CalculatePriceWithDiscountTypeOptionalAgeOptional(price, age);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3}", initialPrice, age, priceWithLastDiscount, DiscountType.General);

            age = 12;
            price = 100;
            priceWithLastDiscount = CalculatePriceWithDiscountTypeOptionalAgeOptional(price, age, DiscountType.Promotion);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3}", initialPrice, age, priceWithLastDiscount, DiscountType.Promotion);

            price = 100;
            priceWithLastDiscount = CalculatePriceWithDiscountTypeOptionalAgeOptional(12, age, DiscountType.Promotion);
            Console.WriteLine("Initial price:{0} , Age:{1}, Price with discount:{2} Discount Type:{3} (call overloaded)", initialPrice, age, priceWithLastDiscount, DiscountType.Promotion);
            Console.ReadKey();


        }

        static bool IsDayInWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        static void PrintSeasonsMesages(Seasons seasons)
        {
            switch (seasons)
            {
                case Seasons.Summer:
                    Console.WriteLine("This is Summer");
                    break;
                case Seasons.Autumn:
                    Console.WriteLine("This is Autumn");
                    break;
                case Seasons.Winter:
                    Console.WriteLine("This is Winter");
                    break;
                case Seasons.Spring:
                    Console.WriteLine("This is Spring");
                    break;
            }

        }

        static string GetCountryHighestOf(string[] countries)
        {
            return  countries.OrderByDescending(item => item.Length).First();
        }

        static string GetHighestCountry(params string[] countries)
        {
            string highestCountryName = "";
            foreach (string country in countries)
            {
                if (country.Length > highestCountryName.Length)
                {
                    highestCountryName = country;
                }
            }
            return highestCountryName;
        }


        static void CalculatePriceWithDiscount(double price, int age, out double priceWithDiscount)
        {
            double discount = 0.05;
            if (age < 7)
            {
                discount = 0.25;
            }
            else if (age < 14)
            {
                discount = 0.15;
            }
            priceWithDiscount = price - price * discount;
        }

        static void CalculatePriceWithDiscount(ref double price, int age)
        {
            var discount = 0.05;
            if (age < 7)
            {
                discount = 0.25;
            }
            else if ( age < 14)
            {
                discount = 0.15;
            }
            price  -= price * discount;
        }

        static double CalculatePriceWithDiscountType(double price, int age, DiscountType discountType = DiscountType.General)
        {
            double discount = 0;
            double priceWithGeneralDiscount = price;
            CalculatePriceWithDiscount(ref priceWithGeneralDiscount, age);
            if (discountType == DiscountType.Promotion)
            {
                discount = 0.25;

            }
            else if (discountType == DiscountType.BestDeal)
            {
                discount = 0.50;
            }
            return (priceWithGeneralDiscount - priceWithGeneralDiscount * discount);
        }

        static double CalculatePriceWithDiscountTypeOptionalAgeOptional(double price, int age = 14, DiscountType discountType = DiscountType.General)
        {
            return CalculatePriceWithDiscountType(price, age, discountType);
        }

        static double CalculatePriceWithDiscountTypeOptionalAgeOptional(int price, int age = 14, DiscountType discountType = DiscountType.General)
        {
            Console.WriteLine("overloaded method int price!");
            double discount = 0;
            double priceWithGeneralDiscount = price;
            CalculatePriceWithDiscount(ref priceWithGeneralDiscount, age);
            if (discountType == DiscountType.Promotion)
            {
                discount = 0.25;

            }
            else if (discountType == DiscountType.BestDeal)
            {
                discount = 0.50;
            }
            return (priceWithGeneralDiscount - priceWithGeneralDiscount * discount);
        }
    }
}
