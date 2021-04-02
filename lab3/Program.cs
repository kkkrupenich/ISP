using System;

namespace Cars
{
    class TransportFacility
    {
        protected int Weight;
        protected int PassengerSeats;
        protected int MaxSpeed;
        protected double MaxDistance;
    }
    class Car : TransportFacility
    {
        protected int WheelAxle, Wheels;

        protected UInt64 IdentificationNumber;
        protected string Number;
        protected string Model, Brand;

        protected double Fuel;
        protected int TankCapacity;
        protected double FuelFlow;
        protected int HorsePower;

        protected int height, length, width;

        public Car() { }
        public Car(int Weight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed, int HorsePower)
        {
            this.Weight = Weight;
            this.PassengerSeats = PassengerSeats;
            this.TankCapacity = TankCapacity;
            this.FuelFlow = FuelFlow;
            this.MaxSpeed = MaxSpeed;
            this.HorsePower = HorsePower;

            Fuel = 0;
            MaxDistance = TankCapacity * FuelFlow;
        }

        public void FillUpTank(double Fuel)
        {
            if (Fuel <= 0)
                return;

            if(this.Fuel + Fuel > TankCapacity)
            {
                Console.WriteLine("Вы льете слишком много");
                return;
            }
            else
            {
                this.Fuel += Fuel;
                Console.WriteLine("В баке {0} л. топлива", this.Fuel);    
            }
        }

        public void Move(double distance)
        {
            if(distance * FuelFlow / 100 > this.Fuel)
            {
                Console.WriteLine("Недостаточно топлива");
                return;
            }
            this.Fuel -= distance * FuelFlow / 100;
        }

        public void Upgrade()
        {
            string tmp;
            int money;
            do
            {
                Console.WriteLine("Платите баксы : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out money));
            Random rand = new Random();
            int newHP = rand.Next(0, money/100 + 1);
            this.HorsePower += newHP;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Объем бака : {0} л.\n" +
                "Объем залитого топлива : {1} л.\n" +
                "Расход топлива : {2} л. на 100 км.\n" +
                "Масса автомобиля : {3} т.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n" +
                "Кол-во лошадиных сил: {6}\n", TankCapacity, Fuel, FuelFlow, Weight / 1000.0, MaxSpeed, PassengerSeats, HorsePower);
        }
    }
    class Lamborgini : Car
    {

    }
    class Tesla : Car
    {

    }
    class McLaren : Car
    {

    }

    class Cars
    {
        Car[] arr;
        public Cars(int size) { arr = new Car[size]; }

        public Car this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int Weight;
            int PassengerSeats;
            int TankCapacity;
            double FuelFlow;
            int MaxSpeed;
            int HorsePower;
            string tmp;
            do
            {
                Console.WriteLine("Введите вес автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out Weight));

            do
            {
                Console.WriteLine("Введите кол-во пассажирских мест в автомобиле : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out PassengerSeats));

            do
            {
                Console.WriteLine("Введите объем бака автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out TankCapacity));

            do
            {
                Console.WriteLine("Введите расход топлива на 100 километров : ");
                tmp = Console.ReadLine();
            } while (!double.TryParse(tmp, out FuelFlow));

            do
            {
                Console.WriteLine("Введите максимальную скорость автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out MaxSpeed));

            do
            {
                Console.WriteLine("Введите кол-во лошадиных сил автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out HorsePower));

            Car MyCar = new Car(Weight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed, HorsePower);

            int request = 1;

            while(request > 0)
            {
                Console.WriteLine("1 - Информация про автомобиль\n" +
                    "2 - Переехать\n" +
                    "3 - Заправить автомобиль\n" +
                    "4 - Увеличить мощность двигателя\n" +
                    "0 - Выход");
                do
                {
                    Console.Write("Ваш выбор : ");
                    tmp = Console.ReadLine();
                } while (!int.TryParse(tmp, out request) || (request < 0));

                double x;
                switch (request)
                {
                    case 1:
                        MyCar.ShowInfo();
                        break;
                    case 2:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.Move(x);
                        break;
                    case 3:
                        Console.Write("Введите кол-во топлива : ");
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.FillUpTank(x);
                        break;
                    case 4:
                        MyCar.Upgrade();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
