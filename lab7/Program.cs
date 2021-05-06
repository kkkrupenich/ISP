using System;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber n1 = new RationalNumber(5, 7);
            RationalNumber n2 = new RationalNumber(5, 2);
            RationalNumber n = n1 + n2;
            Console.WriteLine($"{n1} + {n2} = " + n);
            n = n1 - n2;
            Console.WriteLine($"{n1} - {n2} = " + n.ToString("."));
            n = n1 * n2;
            Console.WriteLine($"{n1} * {n2} = " + n);
            n = n1 / n2;
            Console.WriteLine($"{n1} / {n2} = " + n);
            Console.WriteLine($"{n1} > {n2} - " + (n1 > n2));
            Console.WriteLine($"{n1} < {n2} - " + (n1 < n2));
            Console.WriteLine($"{n1} == {n2} - " + (n1 == n2));
            Console.WriteLine($"{n1} != {n2} - " + (n1 != n2));
            Console.WriteLine("parse -1.5 " + RationalNumber.Parse("-1.5"));
            Console.WriteLine("parse -1/3 " + RationalNumber.Parse("-1/3"));
            n.Reduce();
            Console.WriteLine("reduce 10/35 " + n);
            Console.WriteLine($"(int){n} " + (int)n);
            Console.WriteLine($"(double){n} " + (double)n);
        }
    }
}