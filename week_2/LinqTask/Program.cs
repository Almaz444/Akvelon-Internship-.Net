using LinqTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTask
{
    class Program
    {
        static void Main(string[] args)
        {
            const string appleStore = "AppleStore";
            const string megaStore = "MegaStore";

            List<Consumer> consumers = new List<Consumer>();
            Consumer consumer1 = new Consumer(1, 1989,"25 Manas str.");
            Consumer consumer2 = new Consumer(2, 2000, "33 Baker Avenue");
            Consumer consumer3 = new Consumer(3, 1975, "16 Main Road");
            consumers.Add(consumer1);
            consumers.Add(consumer2);
            consumers.Add(consumer3);
           
            List<Product> products = new List<Product>();
            Product product1 = new Product("AA222-4444", "Mobile", "USA");
            Product product2 = new Product("BB333-5555", "TV", "Japan");
            products.Add(product1);
            products.Add(product2);

            List<ConsumerDiscount> discounts = new List<ConsumerDiscount>();
            ConsumerDiscount discount1 = new ConsumerDiscount(1, megaStore, 25);
            ConsumerDiscount discount2 = new ConsumerDiscount(1, appleStore, 15);
            ConsumerDiscount discount3 = new ConsumerDiscount(2, appleStore, 50);
            ConsumerDiscount discount4 = new ConsumerDiscount(3, megaStore, 10);
            discounts.Add(discount1);
            discounts.Add(discount2);
            discounts.Add(discount3);
            discounts.Add(discount4);

            List<ProductPrice> prices = new List<ProductPrice>();
            ProductPrice price1 = new ProductPrice("AA222-4444", appleStore, 500);
            ProductPrice price2 = new ProductPrice("AA222-4444", megaStore, 400);
            ProductPrice price3 = new ProductPrice("BB333-5555", appleStore, 1000);
            ProductPrice price4 = new ProductPrice("BB333-5555", megaStore, 1200);
            prices.Add(price1);
            prices.Add(price2);
            prices.Add(price3);
            prices.Add(price4);

            List<Purchase> purchases = new List<Purchase>();
            Purchase purchase1 = new Purchase(1, "AA222-4444", appleStore);
            Purchase purchase2 = new Purchase(1, "AA222-4444", megaStore);
            Purchase purchase3 = new Purchase(2, "BB333-5555", appleStore);
            Purchase purchase4 = new Purchase(2, "BB333-5555", megaStore);
       
            purchases.Add(purchase1);
            purchases.Add(purchase2);
            purchases.Add(purchase3);
            purchases.Add(purchase4);


            var result = from consumer in consumers
                         join purchase in purchases on consumer.ConsumerCode equals purchase.ConsumerCode
                         where consumer.BirthYear == consumers.Max(x => x.BirthYear)
                         join product in products on purchase.ArticleNumber equals product.ArticleNumber
                         join price in prices on product.ArticleNumber equals price.ArticleNumber
                         where price.StoreName == purchase.StoreName
                         join discount in discounts on consumer.ConsumerCode equals discount.ConsumerCode


                         select new { consumer.ConsumerCode, consumer.BirthYear, consumer.Address, purchase.StoreName, purchase.ArticleNumber , product.OriginCountry, discount.Discount, price.Price };


            //var amountAfterDiscount = result.Select(d => d.Price * d.Discount;

            foreach (var item in result)
            {
                Console.WriteLine($" Name of country - {item.OriginCountry}, Name of store - {item.StoreName},Year of birth- {item.BirthYear}, Consumer code - {item.ConsumerCode}");
                
            }
            

        }
    }
}
