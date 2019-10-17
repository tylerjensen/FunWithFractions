/*
 * Write a command line program in the language of your choice that will take operations on fractions as an input and produce a fractional result.
 *      Legal operators shall be *, /, +, - (multiply, divide, add, subtract)
 *      Operands and operators shall be separated by one or more spaces
 *      Mixed numbers will be represented by whole_numerator/denominator. e.g. "3_1/4"
 *      Improper fractions and whole numbers are also allowed as operands 
 *      
 * Example run:
 *      ? 1/2 * 3_3/4
 *          = 1_7/8
 *      
 *      ? 2_3/8 + 9/8
 *          = 3_1/2
 */

using System;
using Xunit;

namespace FracFunLib.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(@"1/2 * 3_3/4", @"1_7/8")]
        [InlineData(@"2_3/8 + 9/8", @"3_1/2")]
        public void FractionCalculatorAddition(string input, string expectedOutput)
        {
            // Arrange
            IParser parser = new Parser();
            ICalculator calc = new Calculator(parser);
        
            // Act
            var result = calc.Calculate(input);
        
            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}
