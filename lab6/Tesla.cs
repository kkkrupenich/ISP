using System;

namespace Cars
{
    sealed class Tesla : Car, IPrintable
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
}