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

            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer(1, 1989, "25 Manas str."),
                new Consumer(2, 2000, "33 Baker Avenue"),
                new Consumer(3, 1975, "16 Main Road")
            };

            List<Product> products = new List<Product>()
            {
                new Product("AA222-4444", "Mobile", "USA"),
                new Product("BB333-5555", "TV", "Japan")
            };

            List<ConsumerDiscount> discounts = new List<ConsumerDiscount>()
            {
                new ConsumerDiscount(1, megaStore, 10),
                new ConsumerDiscount(1, appleStore, 20),
                new ConsumerDiscount(2, appleStore, 50),
                new ConsumerDiscount(3, megaStore, 10)
            };

            List<ProductPrice> prices = new List<ProductPrice>()
            {
                new ProductPrice("AA222-4444", appleStore, 100),
                new ProductPrice("AA222-4444", megaStore, 200),
                new ProductPrice("BB333-5555", appleStore, 1000),
                new ProductPrice("BB333-5555", megaStore, 1200),
            };

            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase(1, "AA222-4444", appleStore),
                new Purchase(1, "AA222-4444", megaStore),
                new Purchase(2, "BB333-5555", appleStore),
                new Purchase(2, "BB333-5555", megaStore),
                new Purchase(1, "BB333-5555", megaStore),
            };

            var finalResult = products.Join(
                                    prices,
                                    product => product.ArticleNumber,
                                    price => price.ArticleNumber,
                                    (product, price) => new
                                    {
                                        ArticleNumber = product.ArticleNumber,
                                        Category = product.Category,
                                        Country = product.OriginCountry,
                                        Price = price.Price,
                                        StoreName = price.StoreName
                                    }).Join(
                                    purchases,
                                    x => new { x.ArticleNumber, x.StoreName },
                                    y => new { y.ArticleNumber, y.StoreName },
                                    (productPrice, purchase) => new
                                    {
                                        ConsumerCode = purchase.ConsumerCode,
                                        ArticleNumber = purchase.ArticleNumber,
                                        Country = productPrice.Country,
                                        Price = productPrice.Price,
                                        StoreName = productPrice.StoreName
                                    }).Join(
                                    consumers,
                                    p => p.ConsumerCode,
                                    c => c.ConsumerCode,
                                    (purchase, consumer) => new
                                    {
                                        ConsumerCode = consumer.ConsumerCode,
                                        AtricleNumber = purchase.ArticleNumber,
                                        StoreName = purchase.StoreName,
                                        BirthYear = consumer.BirthYear,
                                        Contry = purchase.Country,
                                        Price = purchase.Price

                                    }).OrderBy(year => year.BirthYear).GroupBy(x => x.ConsumerCode).Take(1).SelectMany(
                                    g => g.ToList()).Join(
                                    discounts,
                                    x => new { x.ConsumerCode, x.StoreName },
                                    y => new { y.ConsumerCode, y.StoreName },
                                    (purchase , discount) => new
                                    {
                                        Country = purchase.Contry,
                                        Store = purchase.StoreName,
                                        BirthYear = purchase.BirthYear,
                                        CustomerCode = purchase.ConsumerCode,
                                        TotalCost = (purchase.Price -(purchase.Price * discount.Discount)/100)
                                    });
          
            foreach (var item in finalResult)
            {
                Console.WriteLine($"Country:{item.Country}, Store:{item.Store}, Birth Year:{item.BirthYear}, Customer Code:{item.CustomerCode}, Total Cost:{item.TotalCost}.");
            }
        }
    }
}
