using System;
using System.Text.RegularExpressions;

namespace LinqTask.Models
{
    public class ProductPrice
    {
        private string articleNumber;
        public string ArticleNumber
        {
            private set
            {
                string pattern = "^[A-Z]{2}\\d{3}-\\d{4}";
                if (Regex.IsMatch(value, pattern))
                {
                    articleNumber = value;
                }
                else
                {
                    Console.WriteLine("Kindly enter article number in 'AAddd-dddd' format. ");
                }
            }
            get { return articleNumber; }
        }
        public string StoreName { get; private set; }
        public int Price { get; private set; }

        public ProductPrice(string articleNumber, string storeName, int price)
        {
            ArticleNumber = articleNumber;
            StoreName = storeName;
            Price = price;
        }
    }
}
