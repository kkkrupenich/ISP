using System;

namespace numbers
{
  class Program
  {
    private static UInt64 CalculatePower(UInt64 a)
    {
      UInt64 power = 0;
      while (a > 0)
      {
        a /= 2;
        power += a;
      }
      return power;
    }
    
    public static int Main(string[] args)
    {
      UInt64 a = 0, b = 0;
      bool error = false;   
      do
      {
        Console.Write("Enter positive a (a > 0): ");
        string strA = Console.ReadLine();
        error = !UInt64.TryParse(strA, out a) || (a <= 0);
      } while (error);     
      do
      {
        Console.Write("Enter positive b (b > a): ");
        string strB = Console.ReadLine();
        error = !UInt64.TryParse(strB, out b) || (b <= a);
      } while (error);

      Console.WriteLine("a = " + a + ", b = " + b);      
      UInt64 powerA = CalculatePower(a - 1);
      UInt64 powerB = CalculatePower(b);
      Console.WriteLine("The power of two is: 2^" + (powerB - powerA));
      return 0;
    }
  }
}