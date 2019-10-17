using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FracFunLib
{
    public class Parser : IParser
    {
        private readonly string[] _validOperators = new string[] { "+", "-", "*", "/" };
        private readonly Regex _invalidChars = new Regex(@"[^_0-9\+\-\*\/\s]");

        /// <summary>
        /// Parse input. 
        /// </summary>
        /// <param name="input">
        /// Assumes that all fractions have a / with no spaces between numerator and denominator. 
        /// Assumes all operators and separated by spaces between fractions, including
        /// fractions that have a whole number that precedes it with the whole number and
        /// the fraction separated by an underscore "_".
        /// </param>
        /// <returns></returns>
        public Expression Parse(string input)
        {
            var elements = ValidateInput(input);
            var nodes = new List<ExpressionNode>();

            bool previousParsedItemWasFraction = false;
            Operator parsedOperator = Operator.None;

            foreach(var item in elements)
            {
                if (item.Length == 1 && _validOperators.Contains(item))
                {
                    if (!previousParsedItemWasFraction)
                    {
                        throw new ArgumentException("Operator and fraction order error. One fraction and then one operator and one fraction.");
                    }
                    parsedOperator = ParseOperator(item);
                    nodes.Last().RightOperator = parsedOperator;
                    previousParsedItemWasFraction = false;
                }
                else
                {
                    if (previousParsedItemWasFraction)
                    {
                        throw new ArgumentException("Operator and fraction order error. One fraction and then one operator and one fraction.");
                    }
                    var node = new ExpressionNode 
                    { 
                        Fraction = ParseFraction(item), 
                        LeftOperator = parsedOperator, 
                        RightOperator = Operator.None 
                    };
                    nodes.Add(node);
                    previousParsedItemWasFraction = true;
                }
            }
            return new Expression(nodes);
        }

        private List<string> ValidateInput(string input)
        {
            if (_invalidChars.IsMatch(input))
            {
                throw new ArgumentException("Input contains characters that are not allowed. Only numerals (0-9), _, +, -, /, *, and spaces are allowed.");
            }
            var elements = input.Split(' ').ToList();
            elements.RemoveAll((item) => item == string.Empty);
            if (elements.Count < 3)
            {
                throw new ArgumentException("Input must have a minimum of two fractions and one operator, e.g. \"2_3/8 + 9/8\"");
            }
            var first = elements.First();
            var last = elements.Last();
            if (_validOperators.Contains(first) && first.Length == 1)
            {
                throw new ArgumentException("Input cannot begin with an operator such as +, -, /, or *.");
            }
            if (_validOperators.Contains(last) && last.Length == 1)
            {
                throw new ArgumentException("Input cannot end with an operator such as +, -, /, or *.");
            }
            return elements;
        }

        private Fraction ParseFraction(string item)
        {
            int whole = 0;
            if (item.Contains("_"))
            {
                var parts = item.Split('_');
                if (parts[0].Length > 0)
                {
                    whole = int.Parse(parts[0]);
                    item = parts[1];
                }
            }
            return ParseFraction(item, whole);
        }

        private Fraction ParseFraction(string fraction, int whole)
        {
            int num = 1;
            int den = 1;
            var fractionParts = fraction.Split('/');
            if (fractionParts.Length < 2)
            {
                num = int.Parse(fractionParts[0]);
            }
            else
            {
                num = int.Parse(fractionParts[0]);
                den = int.Parse(fractionParts[1]);
            }
            num = whole < 0 ? (whole * den) - num : (whole * den) + num;
            return new Fraction(num, den);
        }

        private Operator ParseOperator(string item)
        {
            switch(item)
            {
                case "-": return Operator.Subtract;
                case "*": return Operator.Multiply;
                case "/": return Operator.Divide;
                default: return Operator.Add;
            }
        }
    }
}
