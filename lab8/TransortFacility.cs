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
}