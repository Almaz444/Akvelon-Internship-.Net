using System;
using System.Text.RegularExpressions;

namespace LinqTask.Models
{
    public class Product
    {
        private string articleNumber;
        public string Category { get; private set; }
        public string OriginCountry { get; private set; }
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
        public Product(string articleNumber, string category, string originCountry)
        {
            ArticleNumber = articleNumber;
            Category = category;
            OriginCountry = originCountry;
        }
    }
}
