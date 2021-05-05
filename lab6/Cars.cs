using System;

namespace Cars
{
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
}