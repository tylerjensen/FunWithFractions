using System;
using System.Collections.Generic;
using System.Text;

namespace FracFunLib
{
    public struct Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator, bool simplify = true)
        {
            if (denominator == 0) throw new ArgumentException("Denominator cannot be zero.");
            Numerator = numerator;
            Denominator = denominator;
            if (simplify) Simplify();
        }

        public void Simplify()
        {
            int gcd = FindGreatestCommonDivisor(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator = (int)(Numerator / gcd);
            Denominator = (int)(Denominator / gcd);
        }

        public static Fraction operator + (Fraction a, Fraction b)
        {
            int x = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int y = a.Denominator * b.Denominator;
            return new Fraction(x, y);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int x = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int y = a.Denominator * b.Denominator;
            return new Fraction(x, y);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int x = a.Numerator * b.Numerator;
            int y = a.Denominator * b.Denominator;
            return new Fraction(x, y);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            int x = a.Numerator * b.Denominator;
            int y = a.Denominator * b.Numerator;
            return new Fraction(x, y);
        }


        public string ToFormattedString()
        {
            int absNum = Math.Abs(Numerator);
            int absDen = Math.Abs(Denominator);
            string prefix = "-";
            if (Numerator > 0 && Denominator > 0 || Numerator < 0 && Denominator < 0)
            {
                prefix = string.Empty;
            }

            if (absNum > absDen)
            {
                int littleNumerator = absNum % absDen;
                if (littleNumerator == 0)
                {
                    return $"{prefix}{absNum / absDen}";
                }
                else
                {
                    int gcd = FindGreatestCommonDivisor(littleNumerator, absDen);
                    int remainingNumerator = (int)(littleNumerator / gcd);
                    int remainingDenominator = (int)(absDen / gcd);
                    int wholeNumber = (int)((absNum - littleNumerator) / remainingDenominator);
                    return $"{prefix}{wholeNumber}_{remainingNumerator}/{remainingDenominator}";
                }
            }
            return ToString();
        }

        public override string ToString()
        {
            int absNum = Math.Abs(Numerator);
            int absDen = Math.Abs(Denominator);
            string prefix = "-";
            if (Numerator > 0 && Denominator > 0 || Numerator < 0 && Denominator < 0)
            {
                prefix = string.Empty;
            }
            if (absDen == 1)
                return $"{prefix}{absNum}";
            else
                return $"{prefix}{absNum}/{absDen}";
        }

        private int FindGreatestCommonDivisor(int a, int b)
        {
            if (b == 0) return a;
            return FindGreatestCommonDivisor(b, a % b);
        }
    }
}
