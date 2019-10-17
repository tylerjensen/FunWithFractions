using System;
using System.Collections.Generic;
using System.Text;

namespace FracFunLib
{
    public class Calculator : ICalculator
    {
        private readonly IParser _parser;

        public Calculator(IParser parser)
        {
            if (null == parser) throw new ArgumentNullException(nameof(parser));
            _parser = parser;
        }

        public string Calculate(string input)
        {
            var expression = _parser.Parse(input);
            var result = expression.Execute();
            return result.ToFormattedString();
        }
    }
}
