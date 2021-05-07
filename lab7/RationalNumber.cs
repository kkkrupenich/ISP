using System;

namespace lab7
{
    class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { set; get; }
        public int Denominator { set; get; }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        private static int GCD(int a, int b)
        {
            int temp;

            if(a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            else if(a == b)
            {
                return a;
            }

            while(b > 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private static int LCM(int num, int den)
        {
            return num * den / GCD(num, den);
        } 
        public static RationalNumber operator +(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return new RationalNumber(n1.Numerator * lcm / n1.Denominator + n2.Numerator * lcm / n2.Denominator, lcm);
        }

        public static RationalNumber operator -(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return new RationalNumber(n1.Numerator * lcm / n1.Denominator - n2.Numerator * lcm / n2.Denominator, lcm);
        }

        public static RationalNumber operator *(RationalNumber n1, RationalNumber n2)
        {
            return new RationalNumber(n1.Numerator * n2.Numerator, n1.Denominator * n2.Denominator);
        }

        public static RationalNumber operator /(RationalNumber n1, RationalNumber n2)
        {
            if ((n1.Numerator > 0 && n2.Numerator > 0) || (n1.Numerator < 0 && n2.Numerator < 0))
            {
                return new RationalNumber(Math.Abs(n1.Numerator * n2.Denominator), Math.Abs(n1.Denominator * n2.Numerator));
            }
            else
            {
                return new RationalNumber(-Math.Abs(n1.Numerator * n2.Denominator), Math.Abs(n1.Denominator * n2.Numerator));
            }
        }

        public static bool operator >(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return n1.Numerator * lcm / n1.Denominator > n2.Numerator * lcm / n2.Denominator;
        }

        public static bool operator <(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return n1.Numerator * lcm / n1.Denominator < n2.Numerator * lcm / n2.Denominator;
        }

        public static bool operator ==(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return n1.Numerator * lcm / n1.Denominator == n2.Numerator * lcm / n2.Denominator;
        }

        public static bool operator !=(RationalNumber n1, RationalNumber n2)
        {
            int lcm = LCM(n1.Denominator, n2.Denominator);
            return n1.Numerator * lcm / n1.Denominator != n2.Numerator * lcm / n2.Denominator;
        }

        public override string ToString() => Numerator.ToString() + "/" + Denominator.ToString();

        public string ToString(string format) => format == "." ? ((double)Numerator / Denominator).ToString() : "";

        public static RationalNumber Parse(string str)
        {
            if(str.Contains('/'))
            {
                string[] split = str.Split('/');
                return new RationalNumber(int.Parse(split[0]), int.Parse(split[1]));
            }
            else if(str.Contains('.'))
            {
                string[] split = str.Split('.');
                return new RationalNumber(int.Parse(split[0] + split[1]), (int)Math.Pow(10, split[1].Length));
            }
            else
            { 
                return new RationalNumber(0, 1);
            }
        }

        public void Reduce()
        {
            int gcd = GCD(Math.Abs(Numerator), Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public static implicit operator short(RationalNumber n) => (short)(n.Numerator / n.Denominator);

        public static implicit operator int(RationalNumber n) => n.Numerator / n.Denominator;

        public static implicit operator long(RationalNumber n) => n.Numerator / n.Denominator;

        public static implicit operator float(RationalNumber n) => (float)n.Numerator / n.Denominator;

        public static implicit operator double(RationalNumber n) => (double)n.Numerator / n.Denominator;
        
        public int CompareTo(RationalNumber other) => this == other ? 0 : (this > other ? 1 : -1);
    }
}
