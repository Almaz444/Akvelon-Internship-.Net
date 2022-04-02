using DiscountCalculation.Entities;
using DiscountCalculation.Enums;
using System;

namespace DiscountCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order() { OrderNumber = 1, Date = DateTime.Today, Amount = 100 };
            Customer newCustomer = new Customer(order) { FirstName= "John", LastName = "Kane", CustomerType = CustomerType.NewCustomer };

            Order order1 = new Order() { OrderNumber = 2, Date = DateTime.Today, Amount = 100001 };
            Customer customerLarge = new Customer(order1) { FirstName= "Mike", LastName = "Konnor", CustomerType = CustomerType.PermanentLargeOrders };
           
            Order order2 = new Order() { OrderNumber = 3, Date = DateTime.Today, Amount = 5000 };
            Customer customerLarge2 = new Customer(order2) { FirstName= "Luki", LastName = "O'Neil", CustomerType = CustomerType.PermanentLargeOrders };

            Order order3 = new Order() { OrderNumber = 4, Date = DateTime.Today, Amount = 200 };
            Customer customerSmall = new Customer(order3) { FirstName = "Sadio", LastName = "Mane", CustomerType = CustomerType.PermanentSmallOrders};

            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(Enums.CustomerType.NewCustomer, 0);
            discountIdentifier.discountStrategy.Add(Enums.CustomerType.PermanentLargeOrders, 10);
            discountIdentifier.discountStrategy.Add(Enums.CustomerType.PermanentSmallOrders, 5);

            discountIdentifier.IdentifyDiscount(newCustomer);
            discountIdentifier.IdentifyDiscount(customerLarge);
            discountIdentifier.IdentifyDiscount(customerLarge2);
            discountIdentifier.IdentifyDiscount(customerSmall);

        }
    }
}
