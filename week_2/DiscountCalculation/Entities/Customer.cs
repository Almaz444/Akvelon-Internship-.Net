using DiscountCalculation.Enums;

namespace DiscountCalculation.Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }
        public  Order Order { get; private set; }
        public Customer(Order order)
        {
            Order = order;
        }
    }
}
