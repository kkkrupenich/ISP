using System;
using System.Collections.Generic;

namespace Cars
{
    
    class Program
    {
        static Cars cars = new Cars(3);
        public delegate void KeyHandler(ConsoleKeyInfo key);
        static public void KeyInput(ConsoleKeyInfo key)
        {
            if(key.Key != ConsoleKey.L || key.Key != ConsoleKey.T || key.Key != ConsoleKey.F) Console.Clear();
            if(key.Key == ConsoleKey.L) cars[0].ShowInfo();
            if(key.Key == ConsoleKey.T) cars[1].ShowInfo();
            if(key.Key == ConsoleKey.F) cars[2].ShowInfo(); 
            if(key.Key == ConsoleKey.Escape) Environment.Exit(0);   
        }
        static public void ChooseColor(ConsoleKeyInfo key)
        {
            if(key.Key == ConsoleKey.G) Console.ResetColor();
            if(key.Key == ConsoleKey.B) Console.ForegroundColor = ConsoleColor.Black;
            if(key.Key == ConsoleKey.R) Console.ForegroundColor = ConsoleColor.Red;
            if(key.Key == ConsoleKey.W) Console.ForegroundColor = ConsoleColor.White;
        }
        static public void RunInputLoop(KeyHandler keyHandler)
        {
            while(true)
            {
                Console.WriteLine("L - Lamborghini, T - Tesla, F - Ferrari, Esc - Exit");
                Console.WriteLine("R - Red, B - Black, W - White, G - Gray");
                Console.WriteLine("Your choice?");
                keyHandler?.Invoke(Console.ReadKey());
            }
        }
        static void Main(string[] args)
        {
            Car lamba = new Lamborghini("Aventador SVJ", 1575, 2, 80, 16, 300, 570);
            Car ferra = new Ferrari("F12 berlinetta", 1350, 2, 80, 12, 280, 720);
            Car tesla = new Tesla("Model X", 2400, 5, 100, 2, 250, 770);

            List<Car> arr = new List<Car>(){lamba, ferra, tesla};
            
            Console.WriteLine("Before sorting:");
            foreach(Car i in arr) //before Lamborghini Ferrari Tesla
            {
                i.ShortInfo();
            }
            arr.Sort();
            Console.WriteLine("After sorting:");
            foreach(Car i in arr) //after Tesla Ferrari Lamborghini
            {
                i.ShortInfo();
            }
            
            cars[0] = new Lamborghini("Huracan EVO", 1422, 2, 80, 14, 270, 520);
            cars[1] = new Tesla("Model X", 2400, 5, 100, 2, 250, 770);
            cars[2] = new Ferrari("488 Pista", 1350, 2, 80, 12, 340, 720);

            string tmp;
            int car = 1;
            double x;
            
            while(car >= 1 && car <= 3)
            {
                Console.WriteLine("1 - Lamborghini\n" +
                    "2 - Tesla\n" +
                    "3 - Ferrari\n" +
                    "0 - Exit");
                do
                {
                    Console.Write("Ваш выбор: ");
                    tmp = Console.ReadLine();
                } while (!int.TryParse(tmp, out car) || (car < 0) || (car > 3));
                int request = 1;
                switch(car)
                {
                    case 1:
                        while(request > 0)
                        {
                            Console.WriteLine("1 - Информация про Lamborghini\n" +
                                "2 - Погнали\n" +
                                "3 - Заправить автомобиль\n" +
                                "4 - Режим Strada\n" +
                                "5 - Режим Sport\n" +
                                "6 - Режим Corsa\n" +
                                "0 - Выбрать другой автомобиль");
                            do
                            {
                                Console.Write("Ваш выбор : ");
                                tmp = Console.ReadLine();
                            } while (!int.TryParse(tmp, out request) || (request < 0));
                            switch(request) 
                            {
                                case 1:
                                    cars[0].Notify += message =>
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(message);
                                        Console.ResetColor();
                                    };
                                    cars[car-1].ShowInfo();
                                    break;
                                case 2:
                                    Console.Write("Введите расстояние в километрах:");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].Move(x);
                                    break;
                                case 3:
                                    Console.Write("Введите кол-во топлива : ");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].FillUpTank(x);
                                    break;
                                case 4:
                                    cars[car-1].Strada();
                                    break;
                                case 5:
                                    cars[car-1].Sport();
                                    break;
                                case 6:
                                    cars[car-1].Corsa();
                                    break;
                                default:
                                    break;
                            }   
                        }
                        break;
                    case 2:
                        while(request > 0)
                        {
                            Console.WriteLine("1 - Информация про Tesla\n" +
                                "2 - Погнали\n" +
                                "3 - Заправить автомобиль\n" +
                                "0 - Выбрать другой автомобиль");
                            do
                            {
                                Console.Write("Ваш выбор : ");
                                tmp = Console.ReadLine();
                            } while (!int.TryParse(tmp, out request) || (request < 0));
                            switch(request) 
                            {
                                case 1:
                                    cars[car-1].ShowInfo();
                                    break;
                                case 2:
                                    Console.Write("Введите расстояние в километрах:");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].Move(x);
                                    break;
                                case 3:
                                    Console.Write("Введите кол-во kW: ");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].FillUpTank(x);
                                    break;
                                default:
                                    break;
                            }   
                        }
                        break;
                    case 3:
                        while(request > 0)
                        {
                            Console.WriteLine("1 - Информация про Ferrari\n" +
                                "2 - Погнали\n" +
                                "3 - Заправить автомобиль\n" +
                                "4 - Включить drift mode (RWD)\n" +
                                "5 - Выключить drift mode (4WD)\n" +
                                "0 - Выбрать другой автомобиль");
                            do
                            {
                                Console.Write("Ваш выбор : ");
                                tmp = Console.ReadLine();
                            } while (!int.TryParse(tmp, out request) || (request < 0));
                            switch(request) 
                            {
                                case 1:
                                    cars[car-1].ShowInfo();
                                    break;
                                case 2:
                                    Console.Write("Введите расстояние в километрах:");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].Move(x);
                                    break;
                                case 3:
                                    Console.Write("Введите кол-во топлива : ");
                                    tmp = Console.ReadLine();
                                    double.TryParse(tmp, out x);
                                    cars[car-1].FillUpTank(x);
                                    break;
                                case 4:
                                    cars[car-1].DriftON();
                                    break;
                                case 5:
                                    cars[car-1].DriftOFF();
                                    break;
                                default:
                                    break;
                            }   
                        }
                        break;
                    default:
                        break;
                }
            }
            KeyHandler keyHandler = KeyInput;
            keyHandler += ChooseColor;
            RunInputLoop(keyHandler);
        }
    }
}