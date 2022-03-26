using FractionTask;
using System;
using Xunit;
 


namespace FractionTaskTests
{
    public class UnitTest1
    {
       

        [Fact]
        public void Divide_1_3to1_2_Return2_3()
        {
            // arrange
            Fraction a = new Fraction(1, 3);
            Fraction b = new Fraction(1, 2);
            Fraction result = new Fraction(2, 3);

            // act
            var action = Fraction.Divide(a, b);
           
            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void Multiply_1_3to1_2_Return1_6()
        {
            // arrange
            Fraction a = new Fraction(1, 3);
            Fraction b = new Fraction(1, 2);
            Fraction result = new Fraction(1, 6);

            // act
            var action = Fraction.Multiply(a, b);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void Add_1_3to1_2_Return5_6()
        {
            // arrange
            Fraction a = new Fraction(1, 3);
            Fraction b = new Fraction(1, 2);
            Fraction result = new Fraction(5, 6);

            // act
            var action = Fraction.Add(a, b);

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void Substract_1_3to1_2_Return_minus1_6()
        {
            // arrange
            Fraction a = new Fraction(1, 3);
            Fraction b = new Fraction(1, 2);
            Fraction result = new Fraction(1, -6);

            // act
            var action = Fraction.Substract(a, b);

            // assert
            Assert.Equal(result, action);
        }
    }
}
