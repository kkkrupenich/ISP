using System;

namespace Cars
{
    abstract class TransportFacility
    {
        protected int Weight { get; set; }
        protected int PassengerSeats { get; set; }
        protected int MaxSpeed { get; set; }
        protected double MaxDistance { get; set; }
    }
    abstract class Car : TransportFacility
    {

        protected UInt64 VIN { get; set; }
        protected string Model { get; set; }
        protected string Brand { get; set; }

        protected double Fuel { get; set; }
        protected int TankCapacity { get; set; }
        protected double FuelFlow { get; set; }
        protected int HorsePower { get; set; }

        public Car() { }
        public Car(int weight, int passengerSeats, int tankCapacity, double fuelFlow, int maxSpeed, int horsePower)
        {
            Weight = weight;
            PassengerSeats = passengerSeats;
            TankCapacity = tankCapacity;
            FuelFlow = fuelFlow;
            MaxSpeed = maxSpeed;
            HorsePower = horsePower;

            Fuel = 0;
            MaxDistance = tankCapacity * fuelFlow;
        }

        public virtual void FillUpTank(double fuel)
        {
            if (fuel <= 0)
                return;

            if(Fuel + fuel > TankCapacity)
            {
                Console.WriteLine("Бак полностью заправлен");
                Fuel = TankCapacity;
                return;
            }
            else
            {
                Fuel += fuel;
                Console.WriteLine("В баке {0} л. топлива", Fuel);    
            }
        }

        public virtual void Move(double distance)
        {
            if(distance * FuelFlow / 100 > Fuel)
            {
                Console.WriteLine("Недостаточно топлива");
                return;
            }
            Fuel -= distance * FuelFlow / 100;
            Console.WriteLine("Вы проехали {0} км, остаток топлива: {1} л", distance, Fuel);
        }

        public virtual void Strada(){}
        public virtual void Sport(){}
        public virtual void Corsa(){}
        public virtual void DriftON(){}
        public virtual void DriftOFF(){}
        public virtual void ShowInfo()
        {
            Console.WriteLine("Авто: {7} {8}\n" +
                "Объем бака : {0} л.\n" +
                "Объем залитого топлива : {1} л.\n" +
                "Расход топлива : {2} л. на 100 км.\n" +
                "Масса автомобиля : {3} т.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n" +
                "Кол-во лошадиных сил: {6}\n", TankCapacity, Fuel, FuelFlow, Weight / 1000.0, MaxSpeed, PassengerSeats, HorsePower, Brand, Model);
        }
    }
    sealed class Lamborghini : Car
    {
        enum Mode {Strada, Sport, Corsa}
        private Mode mode;
        public override void Strada()
        {
            if (mode == Mode.Sport)
            {
                MaxSpeed = (int)(MaxSpeed / 1.1);
                HorsePower = (int)(HorsePower / 1.1);
                FuelFlow = (int)(FuelFlow / 1.1);
                mode = Mode.Strada;
                Console.WriteLine("Strada is ON");
            }
            else if (mode == Mode.Corsa)
            {
                MaxSpeed = (int)(MaxSpeed / 1.21);
                HorsePower = (int)(HorsePower / 1.21);
                FuelFlow = (int)(FuelFlow / 1.21);
                mode = Mode.Strada;
                Console.WriteLine("Strada is ON");
            }
            else
                Console.WriteLine("Strada is alrady ON!");
        }
        public override void Sport()
        {
            if (mode == Mode.Strada)
            {
                MaxSpeed = (int)(MaxSpeed * 1.1);
                HorsePower = (int)(HorsePower * 1.1);
                FuelFlow = (int)(FuelFlow * 1.1);
                mode = Mode.Sport;
                Console.WriteLine("Sport is ON");
            }
            else if (mode == Mode.Corsa)
            {
                MaxSpeed = (int)(MaxSpeed / 1.1);
                HorsePower = (int)(HorsePower / 1.1);
                FuelFlow = (int)(FuelFlow / 1.1);
                mode = Mode.Sport;
                Console.WriteLine("Sport is ON");
            }
            else
                Console.WriteLine("Sport is alrady ON!");
        }
        public override void Corsa()
        {
            if (mode == Mode.Strada)
            {
                MaxSpeed = (int)(MaxSpeed * 1.21);
                HorsePower = (int)(HorsePower * 1.21);
                FuelFlow = (int)(FuelFlow * 1.21);
                mode = Mode.Corsa;
                Console.WriteLine("Corsa is ON");
            }
            else if (mode == Mode.Sport)
            {
                MaxSpeed = (int)(MaxSpeed * 1.1);
                HorsePower = (int)(HorsePower * 1.1);
                FuelFlow = (int)(FuelFlow * 1.1);
                mode = Mode.Corsa;
                Console.WriteLine("Corsa is ON");
            }
            else
                Console.WriteLine("Corsa is alrady ON!");
        }
        public Lamborghini(string CarModel, int Weight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed, int HorsePower) : 
            base(Weight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed, HorsePower)
        {
            Brand = "Lamborgini";
            Model = CarModel;
            mode = Mode.Strada;
        }
    }
    sealed class Tesla : Car
    {
        public Tesla(string CarModel, int Weight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed, int HorsePower) :
            base(Weight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed, HorsePower)
        {
            Brand = "Tesla";
            Model = CarModel;
        }

        public override void FillUpTank(double fuel)
        {
            if (fuel <= 0)
                return;

            if(Fuel + fuel >= TankCapacity)
            {
                Console.WriteLine("Батарея заряжена на 100 процентов");
                Fuel = TankCapacity;
                return;
            }
            else
            {
                Fuel += fuel;
                Console.WriteLine("Батарея заряжен на {0} процентов", Fuel / TankCapacity * 100);    
            }
        }
        public override void Move(double distance)
        {
            if(distance * FuelFlow / 100 > Fuel)
            {
                Console.WriteLine("Недостаточно заряда батареи");
                return;
            }
            Fuel -= distance * FuelFlow / 10;
            Console.WriteLine("Вы проехали {0} км, остаток заряда батареи {1}%", distance, Fuel/TankCapacity*100);
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Авто: {7} {8}\n" +
                "Объем батареи : {0} kW.\n" +
                "Остаток батареи : {1} процентов.\n" +
                "Расход батареи : {2} kW/h. на 100 км.\n" +
                "Масса автомобиля : {3} т.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n" +
                "Кол-во лошадиных сил: {6}\n", TankCapacity, Fuel / TankCapacity * 100, FuelFlow, Weight / 1000.0, MaxSpeed, PassengerSeats, HorsePower, Brand, Model);
        }
    }
    sealed class Ferrari : Car
    {
        enum Mode {RWD, FourWD}
        private Mode WheelDrive;
        public override void DriftON()
        {
            if (WheelDrive == Mode.FourWD)
            {
                Console.WriteLine("Now u can drift");
                WheelDrive = Mode.RWD;
            }
            else
                Console.WriteLine("Drift mode is alrady ON!");
        }
        public override void DriftOFF()
        {
            if (WheelDrive == Mode.RWD)
            {
                Console.WriteLine("Stop drifting");
                WheelDrive = Mode.FourWD;
            }
            else
                Console.WriteLine("Drift mode is alrady OFF!");
        }   
        public Ferrari(string CarModel, int Weight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed, int HorsePower) :
            base(Weight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed, HorsePower)
        {
            Brand = "Ferrari";
            Model = CarModel;
        }
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
            string tmp;
            Cars cars = new Cars(3);
            cars[0] = new Lamborghini("Huracan EVO", 1422, 2, 80, 14, 270, 520);
            cars[1] = new Tesla("Model X", 2400, 5, 100, 2, 250, 770);
            cars [2] = new Ferrari("488 Pista", 1350, 2, 80, 12, 340, 720);

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
        }
    }
}
