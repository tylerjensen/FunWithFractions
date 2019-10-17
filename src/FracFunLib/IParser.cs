using System;
using System.Collections.Generic;
using System.Text;

namespace FracFunLib
{
    public interface IParser
    {
        Expression Parse(string input);
    }
}
