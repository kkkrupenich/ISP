using System;
using System.Text;

namespace text
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            Console.WriteLine("Enter your string:");
            str.Append(Console.ReadLine());
            int i;
            char temp = '\n';
            if (str.Length > 0)
                temp = str[0];
            for (i = 1; i < str.Length; i++)
            {
                if(temp <'a' || temp > 'z')
                {
                    Console.WriteLine("Wrong input");
                    break;
                }
                if (temp == 'a' || temp == 'e' || temp == 'i' || temp == 'o' || temp == 'u')
                {
                    temp = str[i];
                    str[i] = Convert.ToChar((Convert.ToInt32(str[i]) + 1 - 'a') % 26 + 'a');
                }
                else
                    temp = str[i];
            }
            Console.WriteLine(str);
        }
    }
}