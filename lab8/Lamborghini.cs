using System;

namespace Cars
{
    sealed class Lamborghini : Car, IPrintable
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
}