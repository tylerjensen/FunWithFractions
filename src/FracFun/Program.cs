using System;
using FracFunLib;

namespace FracFun
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHelp();
            IParser parser = new Parser();
            ICalculator calculator = new Calculator(parser);

            while (true)
            {
                Console.Write("? ");
                var input = Console.ReadLine().Trim(' ', '?', '\'');
                if (input == "exit") break;
                if (input == "help")
                {
                    PrintHelp();
                    continue;
                }
                try
                {
                    var result = calculator.Calculate(input);
                    Console.WriteLine($" = {result}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("The following error has occurred:");
                    Console.WriteLine($"  {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Fun with Fractions!");
            Console.WriteLine(" Enter two or more fractions, each separated by an operator and press Enter.");
            Console.WriteLine(" All fractions have a / with no spaces between numerator and denominator.");
            Console.WriteLine(" All operators are separated by spaces between fractions, including");
            Console.WriteLine(" fractions that have a whole number that precedes it. The whole numer and");
            Console.WriteLine(" the fraction are separated by an underscore \"_\". Operators inlcude the");
            Console.WriteLine(" following: use * for multiplication, / for division, + for addition and");
            Console.WriteLine("  - for subtraction. Valid examples inlcude:");
            Console.WriteLine("      1/2 * 3_3/4");
            Console.WriteLine("      2_3/8 + 9/8");
            Console.WriteLine("      1/2 * 3_3/4 + 4_5/8");
            Console.WriteLine("      2_3/8 + 9/8 / 2/3");
            Console.WriteLine();
            Console.WriteLine("To see this help text again, type 'help' and press Enter.");
            Console.WriteLine("To quit, type 'exit' and press Enter.");
            Console.WriteLine();
        }
    }
}
