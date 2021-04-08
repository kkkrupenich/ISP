using System;
using System.Runtime.InteropServices;

namespace MusicPlayer
{
    class Program
    {
        [DllImport("winmm.dll")]
        static extern bool PlaySound(string sound, IntPtr hmod, int flags = 0x0001);
        static void Main(string[] args)
        {
            Console.WriteLine("Choose which one u want to listen Bounce(1) or folva(2)?");
            string music = Console.ReadLine();
            while (true)
            {
                switch (music)
                {
                    case "1":
                        Console.WriteLine("Playing 'IHAVEONECHANCE & Hies - Bounce'");
                        PlaySound("../4.1/phonk1.wav", IntPtr.Zero);
                        break;
                    case "2":
                        Console.WriteLine("Playing 'Eddie - folva'");
                        PlaySound("../4.1/phonk2.wav", IntPtr.Zero);
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Try again.");
                        break;
                }
                Console.WriteLine("S - stop playing music and choose next one, E - exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "S":
                        Console.WriteLine("Stop playing");
                        PlaySound(" ", IntPtr.Zero);
                        Console.WriteLine("Choose the next one:");
                        music = Console.ReadLine();
                        break;
                    case "E":
                        Console.WriteLine("Good bye!");
                        return;
                    default:
                        Console.WriteLine("Incorrect input. Try again.");
                        break;
                }
            }
        }
    }
}