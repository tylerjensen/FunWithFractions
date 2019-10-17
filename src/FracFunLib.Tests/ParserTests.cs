using System;
using System.Linq;
using Xunit;

namespace FracFunLib.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(@"ab 1/2 * 3_3/4")]
        [InlineData(@"xy 2_3/8 + 9/8")]
        [InlineData(@"2_3/8 + 9/8,")]
        [InlineData(@"2.3/8 + 9/8,")]
        public void CalculatorInputParserInvalidCharacterTests(string input)
        {
            // Arrange
            IParser parser = new Parser();

            // Act & Assert
            var result = Assert.Throws<ArgumentException>(() => parser.Parse(input));

            // Assert
            Assert.Equal("Input contains characters that are not allowed. Only numerals (0-9), _, +, -, /, *, and spaces are allowed.", result.Message);
        }

        [Theory]
        [InlineData(@"* 3_3/4")]
        [InlineData(@"+ 9/8")]
        [InlineData(@"2_3/8 9/8")]
        public void CalculatorInputParserInputInsufficientNumberOfElementsTests(string input)
        {
            // Arrange
            IParser parser = new Parser();

            // Act & Assert
            var result = Assert.Throws<ArgumentException>(() => parser.Parse(input));

            // Assert
            Assert.Equal("Input must have a minimum of two fractions and one operator, e.g. \"2_3/8 + 9/8\"", result.Message);
        }

        [Theory]
        [InlineData(@"+ 1/2 * 3_3/4")]
        [InlineData(@"2_3/8 + 9/8 -")]
        public void CalculatorInputParserInputBeginsOrEndsWithOperatorTests(string input)
        {
            // Arrange
            IParser parser = new Parser();

            // Act & Assert
            var result = Assert.Throws<ArgumentException>(() => parser.Parse(input));

            // Assert
            Assert.True(result.Message.StartsWith("Input cannot "));
        }

        [Theory]
        [InlineData(@"1/2 * 3_3/4", 1, 2)]
        [InlineData(@"2_3/8 + 9/8", 1, 2)]
        public void CalculatorInputParserBasicTests(string input, int operatorCount, int fractionCount)
        {
            // Arrange
            IParser parser = new Parser();

            // Act
            var result = parser.Parse(input);

            // Assert
            Assert.Equal(2, result.Nodes.Count);
            Assert.Equal(Operator.None, result.Nodes.First().LeftOperator);
            Assert.Equal(Operator.None, result.Nodes.Last().RightOperator);
        }

        //ArgumentException("Operator and fraction order error

        [Theory]
        [InlineData(@"1/2 * + 3_3/4")]
        [InlineData(@"2_3/8 + - 9/8")]
        public void CalculatorInputParserTooOperatorsTests(string input)
        {
            // Arrange
            IParser parser = new Parser();

            // Act & Assert
            var result = Assert.Throws<ArgumentException>(() => parser.Parse(input));

            // Assert
            Assert.True(result.Message.StartsWith("Operator and fraction order error"));
        }

    }
}
