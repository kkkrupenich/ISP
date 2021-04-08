using System;
using System.Runtime.InteropServices;

namespace MyDLLImport
{
    class Program
    {
        [DllImport("DefaultMath.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Summ(int a, int b);

        [DllImport("DefaultMath.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Minus(int a, int b);

        [DllImport("DefaultMath.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multi(int a, int b);

        [DllImport("DefaultMath.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int Div(int a, int b);


        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Введите первое число");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Некорректный ввод.");
            }

            Console.WriteLine("Введите целое второе число");
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Некорректный ввод.");
            }
            Console.WriteLine("Сумма чисел: {0}", Summ(a, b));
            Console.WriteLine("Разница чисел: {0}", Minus(a, b));
            Console.WriteLine("Произведение чисел: {0}", Multi(a, b));
            Console.WriteLine("Частное чисел: {0}", Div(a, b));
            Console.ReadKey();
        }
    }
}