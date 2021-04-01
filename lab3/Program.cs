using System;

namespace Cars
{
    class TransportFacility
    {
        protected int Weight, MaxWeight;
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

        protected int height, length, width;

        public Car() { }
        public Car(int Weight, int MaxWeight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed)
        {
            this.Weight = Weight;
            this.MaxWeight = MaxWeight;
            this.PassengerSeats = PassengerSeats;
            this.TankCapacity = TankCapacity;
            this.FuelFlow = FuelFlow;
            this.MaxSpeed = MaxSpeed;

            Fuel = 0;
            MaxDistance = TankCapacity * FuelFlow;
        }

        public void FillUpTank(double Fuel)
        {
            if (Fuel <= 0)
                return;

            if (this.Fuel + Fuel >= TankCapacity)
            {
                this.Fuel = TankCapacity;
                if (TankCapacity - this.Fuel - Fuel < 0)
                    Console.WriteLine("Бак полон, остаток бензина : {0} л.", Fuel + this.Fuel - TankCapacity);
                else
                    Console.WriteLine("Бак полон");
                this.Fuel = TankCapacity;
            }
            else
            {
                this.Fuel += Fuel;
                Console.WriteLine("В баке {0} л. топлива", this.Fuel);
            }
        }

        public void Move(double distance)
        {
            if(distance * FuelFlow > Fuel)
            {
                Console.WriteLine("Недостаточно топлива");
                return;
            }

            Fuel -= distance * FuelFlow;
        }

        public double CurrentFuelVolume() { return Fuel; }

        public void ShowInfo()
        {
            Console.WriteLine("Объем бака : {0}\n" +
                "Расход топлива : {1} л. на 100 км.\n" +
                "Масса автомобиля : {2} т.\n" +
                "Грузоподъемность : {3} кг.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n", TankCapacity, FuelFlow, Weight / 1000.0, MaxWeight - Weight, MaxSpeed, PassengerSeats);
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
            int Weight, MaxWeight;
            int PassengerSeats;
            int TankCapacity;
            double FuelFlow;
            int MaxSpeed;
            string tmp;
            do
            {
                Console.WriteLine("Введите вес автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out Weight));

            do
            {
                Console.WriteLine("Введите грузоподъемность автомобиля : ");
                tmp = Console.ReadLine();
            } while (!int.TryParse(tmp, out MaxWeight));

            MaxWeight += Weight;

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

            Car MyCar = new Car(Weight, MaxWeight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed);

            int request = 1;

            while(request > 0)
            {
                Console.WriteLine("1 - Информация про автомобиль\n" +
                    "2 - Текущий запас топлива\n" +
                    "3 - Переехать\n" +
                    "4 - Заправить автомобиль\n");
                tmp = Console.ReadLine();
                int.TryParse(tmp, out request);

                double x;
                switch (request)
                {
                    case 1:
                        MyCar.ShowInfo();
                        break;
                    case 2:
                        Console.WriteLine(MyCar.CurrentFuelVolume());
                        break;
                    case 3:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.Move(x);
                        break;
                    case 4:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        MyCar.FillUpTank(x);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}