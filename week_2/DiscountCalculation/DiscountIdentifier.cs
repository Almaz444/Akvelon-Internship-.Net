using DiscountCalculation.Entities;
using DiscountCalculation.Enums;
using System;
using System.Collections.Generic;

namespace DiscountCalculation
{
    public class DiscountIdentifier
    {
        private delegate double Calculate(double amount, int discount);
       
        private double CalculateDiscount(double x, int y) => x - (x* y / 100);

        public Dictionary<CustomerType, int> discountStrategy { get; private set; } 

        public DiscountIdentifier()
        {
            discountStrategy = new Dictionary<CustomerType, int>();
        }
        public double IdentifyDiscount(Customer customer)
        {
            Calculate calculateDisc = new Calculate(CalculateDiscount);
            int disc = 0;
            double result;
            switch ((int)customer.CustomerType)
            {
                case 1:
                    disc = discountStrategy[customer.CustomerType];
                    break;
                case 2:
                    if (customer.Order.Amount > 100000)
                        disc = 15;
                    else if(0 < customer.Order.Amount && customer.Order.Amount < 100001)
                        disc = discountStrategy[customer.CustomerType];
                    break;
                case 3:
                    disc  = discountStrategy[customer.CustomerType];
                    break;
            }
             result = calculateDisc(customer.Order.Amount, disc);
            if (customer.CustomerType == CustomerType.NewCustomer)
                Console.WriteLine("There is no discount for new customer , amount to be paid remain same {0}", result);
            else
                Console.WriteLine("Discount will be {0}%, amount before discount = {1}. After discount amount to be paid = {2}", disc, customer.Order.Amount, result);
            return result;
        }
    }
}
