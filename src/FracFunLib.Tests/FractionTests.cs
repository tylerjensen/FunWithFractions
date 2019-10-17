using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FracFunLib.Tests
{
    public class FractionTests
    {
        [Fact]
        public void FractionConstructorNoSimplifyTest()
        {
            // Arrange & // Act
            var result = new Fraction(4, 6, false);

            // Assert
            Assert.Equal(4, result.Numerator);
            Assert.Equal(6, result.Denominator);
        }

        [Fact]
        public void FractionConstructorSimplifyTest()
        {
            // Arrange & Act
            var result = new Fraction(4, 6);

            // Assert
            Assert.Equal(2, result.Numerator);
            Assert.Equal(3, result.Denominator);
        }

        [Fact]
        public void FractionConstructorSimplifyWithWholeNumberTest()
        {
            // Arrange & Act
            var result = new Fraction(6, 4);

            // Assert
            Assert.Equal(3, result.Numerator);
            Assert.Equal(2, result.Denominator);
        }

        [Fact]
        public void FractionConstructorSimplifyNegativeNumTest()
        {
            // Arrange & Act
            var result = new Fraction(-4, 6);

            // Assert
            Assert.Equal(-2, result.Numerator);
            Assert.Equal(3, result.Denominator);
        }

        [Fact]
        public void FractionConstructorSimplifyNegativeDenTest()
        {
            // Arrange & Act
            var result = new Fraction(4, -6);

            // Assert
            Assert.Equal(2, result.Numerator);
            Assert.Equal(-3, result.Denominator);
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
            Assert.Equal(1, frac.Numerator);
            Assert.Equal(1, frac.Denominator);
        }

        [Fact]
        public void FractionAdditionSimpleTest()
        {
            // Arrange
            var a = new Fraction(1, 3);
            var b = new Fraction(1, 3);

            // Act
            var result = a + b;

            // Assert
            Assert.Equal(2, result.Numerator);
            Assert.Equal(3, result.Denominator);
        }

        [Fact]
        public void FractionAdditionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            // Act
            var result = a + b;

            // Assert
            Assert.Equal(17, result.Numerator);
            Assert.Equal(12, result.Denominator);
            Assert.Equal("1_5/12", result.ToFormattedString());
        }

        [Fact]
        public void FractionSubtractionSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);

            // Act
            var result = a - b;

            // Assert
            Assert.Equal(1, result.Numerator);
            Assert.Equal(3, result.Denominator);
        }

        [Fact]
        public void FractionSubtractionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            // Act
            var result = a - b;

            // Assert
            Assert.Equal(-1, result.Numerator);
            Assert.Equal(12, result.Denominator);
            Assert.Equal("-1/12", result.ToFormattedString());
        }

        [Fact]
        public void FractionMultiplicationSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);

            // Act
            var result = a * b;

            // Assert
            Assert.Equal(2, result.Numerator);
            Assert.Equal(9, result.Denominator);
        }

        [Fact]
        public void FractionMultiplicationComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            // Act
            var result = a * b;

            // Assert
            Assert.Equal(1, result.Numerator);
            Assert.Equal(2, result.Denominator);
            Assert.Equal("1/2", result.ToFormattedString());
        }

        [Fact]
        public void FractionDivisionSimpleTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(1, 3);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(2, result.Numerator);
            Assert.Equal(1, result.Denominator);
        }

        [Fact]
        public void FractionDivisionComplexTest()
        {
            // Arrange
            var a = new Fraction(2, 3);
            var b = new Fraction(3, 4);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(8, result.Numerator);
            Assert.Equal(9, result.Denominator);
            Assert.Equal("8/9", result.ToFormattedString());
        }

        [Fact]
        public void FractionDivisionComplexNegativeTest()
        {
            // Arrange
            var a = new Fraction(2, -3);
            var b = new Fraction(3, 4);

            // Act
            var result = a / b;

            // Assert
            Assert.Equal(8, result.Numerator);
            Assert.Equal(-9, result.Denominator);
            Assert.Equal("-8/9", result.ToFormattedString());
        }

    }
}
