﻿using System;
using System.Globalization;

namespace Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultures = null;
            while (cultures == null)
            {
                try
                {
                    Console.WriteLine("Enter the language (e.g. ru, fr, lt):");
                    cultures = CultureInfo.GetCultureInfo(Console.ReadLine());
                }
                catch (CultureNotFoundException)
                {
                    Console.WriteLine("Your input is incorrect. Please try again.");
                }
            }
            CultureInfo.CurrentCulture = cultures;

            DateTime date = new DateTime(2021, 1, 1);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(date.AddMonths(i).ToString("MMMM"));
            }
        }
    }
}
