using System;

namespace DiscountCalculation.Entities
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public double amount;
        public double Amount
        {
            set
            {
                if (value < 0)
                    Console.WriteLine("The order amount must be greater than zero.");
                else
                    amount = value;
            }
            get { return amount; }
        }
    }
}
