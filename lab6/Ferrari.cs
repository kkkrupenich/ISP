using System;

namespace Cars
{
        sealed class Ferrari : Car, IPrintable
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
}