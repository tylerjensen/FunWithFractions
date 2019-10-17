using System;
using System.Collections.Generic;
using System.Text;

namespace FracFunLib
{
    public class ExpressionNode
    {
        public Fraction Fraction { get; set; }
        public Operator LeftOperator { get; set; }
        public Operator RightOperator { get; set; }
    }
}
