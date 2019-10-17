using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FracFunLib
{
    public class Expression
    {
        private readonly List<ExpressionNode> _nodes;
        public IReadOnlyList<ExpressionNode> Nodes => _nodes;

        public Expression(List<ExpressionNode> nodes)
        {
            if (nodes == null) throw new ArgumentNullException(nameof(nodes));
            if (nodes.Count < 2) throw new ArgumentException("A FractionExpression requires two or more Fractions and an operator between each.");
            _nodes = nodes;
        }

        public Fraction Execute()
        {
            if (_nodes.Count == 2)
            {
                return Execute(_nodes[0].Fraction, _nodes[0].RightOperator, _nodes[1].Fraction);
            }
            return ExecuteComplexExpression();
        }

        private Fraction ExecuteComplexExpression()
        {
            ExecuteSpecifiedOperations(Operator.Multiply);
            if (_nodes.Count > 1) ExecuteSpecifiedOperations(Operator.Divide);
            if (_nodes.Count > 1) ExecuteSpecifiedOperations(Operator.Subtract);
            if (_nodes.Count > 1) ExecuteSpecifiedOperations(Operator.Add);
            if (_nodes.Count == 1) return _nodes[0].Fraction;
            throw new Exception("An error has occurred in processing the complex expression.");
        }

        private void ExecuteSpecifiedOperations(Operator op)
        {
            int index;
            while (_nodes.Any((x) => x.RightOperator == op))
            {
                index = _nodes.FindIndex((x) => x.RightOperator == op);
                var multipliedFraction = Execute(_nodes[index].Fraction, op, _nodes[index + 1].Fraction);
                var result = new ExpressionNode
                {
                    Fraction = multipliedFraction,
                    LeftOperator = index == 0 ? Operator.None : _nodes[index - 1].RightOperator,
                    RightOperator = _nodes[index + 1].RightOperator
                };
                // Replace the two nodes with the resulting node
                _nodes.RemoveAt(index);
                _nodes.Insert(index, result);
                _nodes.RemoveAt(index + 1);
                // Trim operators in case this was the last set
                _nodes.Last().RightOperator = Operator.None;
            }
        }

        private Fraction Execute(Fraction a, Operator op, Fraction b)
        {
            switch(op)
            {
                case Operator.None:
                    throw new NotSupportedException("An unsupported operator cannot be processed.");
                case Operator.Add:
                    return a + b;
                case Operator.Subtract:
                    return a - b;
                case Operator.Divide:
                    return a / b;
                default:
                    return a * b;
            }
        }
    }
}
