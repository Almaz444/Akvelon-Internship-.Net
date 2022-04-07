using System;

namespace LinqTask.Models
{
    public class ConsumerDiscount
    {
        public int ConsumerCode { get; private set; }
        public string StoreName { get; private set; }
        private int discount;
        public int Discount 
        {
            private set
            {
                if (value < 5 || value > 50)
                    Console.WriteLine("Discount should be in a range from 5 to 50.");
                else
                    discount = value;
            }
            get { return discount; }
        }

        public ConsumerDiscount(int consumerCode, string storeName, int discount)
        {
            ConsumerCode = consumerCode;
            StoreName = storeName;
            Discount = discount;
        }
    }
}
