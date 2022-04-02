using DiscountCalculation;
using DiscountCalculation.Entities;
using DiscountCalculation.Enums;
using System;
using Xunit;

namespace DiscountCalculationTests
{
    public class DiscountIdentifierTest
    {
        [Fact]
        public void IdentifyDiscount_AddingNewCustomerWithNoDiscount_ReturnSameAmount()
        {
            // arrange

            Order order = new Order() { OrderNumber = 1, Date = DateTime.Today, Amount = 100 };
            Customer newCustomer = new Customer(order) { FirstName = "John", LastName = "Kane", CustomerType = CustomerType.NewCustomer };
            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(CustomerType.NewCustomer, 0);
            double result = 100;

            // act
            double action = discountIdentifier.IdentifyDiscount(newCustomer);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void IdentifyDiscount_AddingCustomerWithPermanentLargeOrdersAndAmountGreaterThan100000_ReturnAmontWith15Discount()
        {
            // arrange

            Order order1 = new Order() { OrderNumber = 2, Date = DateTime.Today, Amount = 100001 };
            Customer customerLarge = new Customer(order1) { FirstName = "Mike", LastName = "Konnor", CustomerType = CustomerType.PermanentLargeOrders };
            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(CustomerType.NewCustomer, 0);
            double result = 85000.85;

            // act
            double action = discountIdentifier.IdentifyDiscount(customerLarge);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void IdentifyDiscount_AddingCustomerWithPermanentLargeOrdersAndAmountLessThan100001_ReturnAmontWith10Discount()
        {
            // arrange

            Order order2 = new Order() { OrderNumber = 3, Date = DateTime.Today, Amount = 100 };
            Customer customerLarge = new Customer(order2) { FirstName = "Luki", LastName = "O'Neil", CustomerType = CustomerType.PermanentLargeOrders };
            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(CustomerType.PermanentLargeOrders, 10);
            double result = 90;

            // act
            double action = discountIdentifier.IdentifyDiscount(customerLarge);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void IdentifyDiscount_AddingCustomerWithPermanentSmallOrders_ReturnAmontWith5Discount()
        {
            // arrange

            Order order3 = new Order() { OrderNumber = 4, Date = DateTime.Today, Amount = 100 };
            Customer customerSmall = new Customer(order3) { FirstName = "Sadio", LastName = "Mane", CustomerType = CustomerType.PermanentSmallOrders };
            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(CustomerType.PermanentSmallOrders, 5);
            double result = 95;

            // act
            double action = discountIdentifier.IdentifyDiscount(customerSmall);

            // assert
            Assert.Equal(result, action);
        }
        [Fact]
        public void IdentifyDiscount_AddingCustomerWithOrderAmont0_Return0()
        {
            // arrange

            Order order3 = new Order() { OrderNumber = 4, Date = DateTime.Today, Amount = 0 };
            Customer customerSmall = new Customer(order3) { FirstName = "Sadio", LastName = "Mane", CustomerType = CustomerType.PermanentSmallOrders };
            DiscountIdentifier discountIdentifier = new DiscountIdentifier();
            discountIdentifier.discountStrategy.Add(CustomerType.PermanentSmallOrders, 5);
            double result = 0;

            // act
            double action = discountIdentifier.IdentifyDiscount(customerSmall);

            // assert
            Assert.Equal(result, action);
        }
    }
}
