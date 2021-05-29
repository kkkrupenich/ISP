using System;

namespace Cars
{
    abstract class Car : TransportFacility, IComparable<Car>
    {
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
        public virtual void ShortInfo()
        {
            Console.WriteLine("Авто: {0} {1}\n" +
                "Максимальная скорость: {2} км/ч\n" +
                "Кол-во лошадиных сил: {3}\n", Brand, Model, MaxSpeed, HorsePower);
        }

        
        public delegate void notify(string message);
        public event notify Notify;
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
            Notify?.Invoke("Information about Lamborghini");
        }
        public int CompareTo(Car other)
        {
            if(MaxSpeed == other.MaxSpeed)
            {
                if(HorsePower > other.HorsePower) return 1;
                else if(HorsePower < other.HorsePower) return -1;
                return 0;
            }
            return MaxSpeed - other.MaxSpeed;
        }
    }
}