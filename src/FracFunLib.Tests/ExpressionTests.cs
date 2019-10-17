using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FracFunLib.Tests
{
    public class ExpressionTests
    {
        [Theory]
        [InlineData(@"1/2 * 3_3/4", 15, 8)]
        [InlineData(@"2_3/8 + 9/8", 7, 2)]
        public void FractionExpressionBasicTests(string input, int expectedNumerator, int expectedDenominator)
        {
            // Arrange
            IParser parser = new Parser();

            // Act
            var expression = parser.Parse(input);
            var result = expression.Execute();

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

        [Theory]
        [InlineData(@"1/2 * 3_3/4 + 4_5/8", 13, 2)]
        [InlineData(@"2_3/8 + 9/8 / 2/3", 65, 16)]
        [InlineData(@"-2_3/8 + 9/8 / 2/3", -11, 16)]
        public void FractionExpressionComplexTests(string input, int expectedNumerator, int expectedDenominator)
        {
            // Arrange
            IParser parser = new Parser();

            // Act
            var expression = parser.Parse(input);
            var result = expression.Execute();

            // Assert
            Assert.Equal(expectedNumerator, result.Numerator);
            Assert.Equal(expectedDenominator, result.Denominator);
        }

    }
}
