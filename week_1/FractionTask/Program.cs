using System;

namespace FractionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 3);
            Fraction b = new Fraction(1, 2);
            Fraction.Add(a, b);
            Fraction.Multiply(a, b);
            Fraction.Substract(a, b);
            Fraction.Divide(a, b);
            double result = Fraction.ConvertToDouble(a);
            Console.WriteLine("Result of Converting fraction into double type is " + result);
            int hash = b.GetHashCode();
            Console.WriteLine(hash);
            Fraction c = new Fraction(1, 3);
            bool isEqual = a.Equals(c);
            Console.WriteLine(isEqual);
        }
    }
}
