using System;
using System.Collections.Generic;
using System.Text;

namespace FractionTask
{
    public class Fraction
    {
        private readonly int numerator;
        private readonly int denominator;

        public int Numerator
        {
            get { return numerator; } 
        }
        public int Denominator
        {
            get { return denominator; } 
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("The denominator is zero.Please choose another number");
            } else {
                this.numerator = numerator;
                this.denominator = denominator;
            }
        }

        public static Fraction Multiply(Fraction firstFraction, Fraction secondFraction)
        {
            Fraction result = new Fraction(firstFraction.Numerator * secondFraction.Numerator, firstFraction.Denominator * secondFraction.Denominator);
            Fraction simpleForm = ReduceFraction(result.Denominator, result.Numerator);
            if (simpleForm.Numerator == 0)
            {
                Console.WriteLine("Result of Division operation is 0");
            } else{
                Console.WriteLine("Result of Multiply operation is " + simpleForm.Numerator + "/" + simpleForm.Denominator);
            }
            return simpleForm;
        }
        
        public static Fraction Divide(Fraction firstFraction, Fraction secondFraction)
        {
            Fraction result = new Fraction(firstFraction.Numerator * secondFraction.Denominator, firstFraction.Denominator * secondFraction.Numerator);
            Fraction simpleForm = ReduceFraction(result.Denominator, result.Numerator);
            if (simpleForm.Numerator == 0)
            {
                Console.WriteLine("Result of Division operation is 0");
                
            } else{
                Console.WriteLine("Result of Division operation is " + simpleForm.Numerator + "/" + simpleForm.Denominator);
            }
            return simpleForm;
            
        }

        public static Fraction Add(Fraction firstFraction, Fraction secondFraction)
        {
            // Finding Common Denominator
            int commonDenominator = GetCommonDenominator(firstFraction.Denominator, secondFraction.Denominator);

            // Finding Least Common Multiple
           int leastCommonMultiple = (firstFraction.Denominator * secondFraction.Denominator) / commonDenominator;

            //Finding Final Numerator 
            int finalNumerator = (firstFraction.Numerator) * (leastCommonMultiple / firstFraction.Denominator) + (secondFraction.Numerator) * (leastCommonMultiple / secondFraction.Denominator);
            Fraction result = ReduceFraction(leastCommonMultiple,finalNumerator);
            Console.WriteLine("Result of Addition operation is " + result.Numerator + "/" + result.Denominator);
            return result;
        }


        public static Fraction Substract(Fraction firstFraction, Fraction secondFraction)
        {
            // Finding Common Denominator
            int commonDenominator = GetCommonDenominator(firstFraction.Denominator, secondFraction.Denominator);

            // Finding Least Common Multiple
            int leastCommonMultiple = (firstFraction.Denominator * secondFraction.Denominator) / commonDenominator;

            //Finding Final Numerator 
            int finalNumerator = (firstFraction.Numerator) * (leastCommonMultiple / firstFraction.Denominator) - (secondFraction.Numerator) * (leastCommonMultiple / secondFraction.Denominator);
            Fraction result = ReduceFraction(leastCommonMultiple, finalNumerator);
            Console.WriteLine("Result of Substraction operation is " + result.Numerator + "/" + result.Denominator);
            return result;
        }
        private static int GetCommonDenominator(int a, int b)
        {
            if (a == 0)
                return b;
            return GetCommonDenominator(b % a, a);
        }

        // Method to convert fraction into the simplest form
        private static Fraction ReduceFraction(int den, int num)
        {
            int commonDenominator = GetCommonDenominator(num, den);
            den = den / commonDenominator;
            num = num / commonDenominator;
            Fraction fraction = new Fraction(num, den);
            return fraction;
        }
        // Method to convert fraction into double type
        public static double ConvertToDouble(Fraction fraction)
        {
            return (double)fraction.Numerator / (double)fraction.Denominator;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 11789;
                hash = hash * 27 + Numerator.GetHashCode();
                hash = hash * 27 + Denominator.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Fraction))
            {
                return false;
            }
            return (this.Numerator == ((Fraction)obj).Numerator)
                && (this.Denominator == ((Fraction)obj).Denominator);
        }
    }
}
