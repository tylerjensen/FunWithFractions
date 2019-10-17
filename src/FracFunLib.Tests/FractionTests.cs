using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FracFunLib.Tests
{
    public class FractionTests
    {
        [Fact]
        public void FractionConstructorSimplifyTest()
        {
            // Arrange & Act
            var a = new Fraction(4, 6);
            var c = new Fraction(2, 3);

            // Assert
            Assert.Equal(c, a);
        }

        [Fact]
        public void FractionConstructorSimplifyWithWholeNumberTest()
        {
            // Arrange & Act
            var a = new Fraction(6, 4);
            var c = new Fraction(3, 2);

            // Assert
            Assert.Equal(c, a);
        }

        [Fact]
        public void FractionConstructorSimplifyNegativeNumTest()
        {
            // Arrange & Act
            var a = new Fraction(-4, 6);
            var c = new Fraction(-2, 3);

            // Assert
            Assert.Equal(c, a);
        }

        [Fact]
        public void FractionConstructorSimplifyNegativeDenTest()
        {
            // Arrange & Act
            var a = new Fraction(4, -6);
            var c = new Fraction(2, -3);

            // Assert
            Assert.Equal(c, a);
        }

        [Fact]
        public void FractionConstructorDivideByZeroTest()
        {
            // Arrange & Act & Assert
            var result = Assert.Throws<ArgumentException>(() => new Fraction(4, 0));
        }

        [Fact]
        public void FractionToFormattedStringTest()
        {
            // Arrange
            var frac = new Fraction(4, 6);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("2/3", result);
        }

        [Fact]
        public void FractionToFormattedStringNegativeTest()
        {
            // Arrange
            var frac = new Fraction(4, -6);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("-2/3", result);
        }


        [Fact]
        public void FractionToFormattedStringWholeNumberTest()
        {
            // Arrange
            var frac = new Fraction(6, 3);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("2", result);
        }


        [Fact]
        public void FractionToFormattedStringWithWholeNumberTest()
        {
            // Arrange
            var frac = new Fraction(6, 4);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("1_1/2", result);
        }

        [Fact]
        public void FractionToFormattedStringWithWholeNumberNegativeTest()
        {
            // Arrange
            var frac = new Fraction(-6, 4);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("-1_1/2", result);
        }

        [Fact]
        public void FractionToFormattedStringWithWholeNumberDoubleNegativeTest()
        {
            // Arrange
            var frac = new Fraction(-6, -4);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("1_1/2", result);
        }

        [Fact]
        public void FractionToFormattedStringOneTest()
        {
            // Arrange
            var frac = new Fraction(6, 6);

            // Act
            var result = frac.ToFormattedString();

            // Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void FractionAdditionSimpleTest()
        {
            // Arrange
            var a = new Fraction(1, 3);
            var b = new Fraction(1, 3);
            var c = new Fraction(2, 3);

            // Act
            var result = a + b;

            // Assert
            Assert.Equal(c, result);
        }

        [Fact]
        public void FractionAdditionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);
            var c = new Fraction(17, 12);

            // Act
            var result = a + b;

            // Assert
            Assert.Equal(c, result);
            Assert.Equal("1_5/12", result.ToFormattedString());
        }

        [Fact]
        public void FractionSubtractionSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);
            var c = new Fraction(1, 3);

            // Act
            var result = a - b;

            // Assert
            Assert.Equal(c, result);
        }

        [Fact]
        public void FractionSubtractionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);
            var c = new Fraction(-1, 12);

            // Act
            var result = a - b;

            // Assert
            Assert.Equal(c, result);
            Assert.Equal("-1/12", result.ToFormattedString());
        }

        [Fact]
        public void FractionMultiplicationSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);
            var c = new Fraction(2, 9);

            // Act
            var result = a * b;

            // Assert
            Assert.Equal(c, result);
        }

        [Fact]
        public void FractionMultiplicationComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);
            var c = new Fraction(1, 2);

            // Act
            var result = a * b;

            // Assert
            Assert.Equal(c, result);
            Assert.Equal("1/2", result.ToFormattedString());
        }

        [Fact]
        public void FractionDivisionSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);
            var c = new Fraction(2, 1);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(c, result);
        }

        [Fact]
        public void FractionDivisionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);
            var c = new Fraction(8, 9);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(c, result);
            Assert.Equal("8/9", result.ToFormattedString());
        }

        [Fact]
        public void FractionDivisionComplexNegativeTest()
        {
            // Arrange
            var a = new Fraction(2, -3);
            var b = new Fraction(3, 4);
            var c = new Fraction(8, -9);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(c, result);
            Assert.Equal("-8/9", result.ToFormattedString());
        }

        [Fact]
        public void FractionInEqualityTest()
        {
            // Arrange & Act
            var a = new Fraction(2, 3);
            var b = new Fraction(4, 5);

            // Assert
            Assert.NotEqual(a, b);
        }

        [Fact]
        public void FractionEqualityTest()
        {
            // Arrange & Act
            var a = new Fraction(2, 3);
            var b = new Fraction(4, 6);

            // Assert
            Assert.Equal(a, b);
        }

        [Fact]
        public void FractionNotEqualTest()
        {
            // Arrange & Act
            var a = new Fraction(2, 3);
            var b = new Fraction(4, 5);
            bool result = a != b;

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void FractionEqualTest()
        {
            // Arrange & Act
            var a = new Fraction(2, 3);
            var b = new Fraction(4, 6);
            bool result = a == b;

            // Assert
            Assert.True(result);
        }
    }
}
