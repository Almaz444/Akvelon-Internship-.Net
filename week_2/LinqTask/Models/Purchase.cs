using System;
using System.Text.RegularExpressions;

namespace LinqTask.Models
{
    public class Purchase
    {
        public int ConsumerCode { get; private set; }
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

        public Purchase(int consumerCode, string articleNumber, string storeName)
        {
            ConsumerCode = consumerCode;
            ArticleNumber = articleNumber;
            StoreName = storeName;
        }
    }
}
