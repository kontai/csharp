using _01sealed;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01sealed
{
    internal class Car
    {
        private int _currSpeed;
        public readonly int MaxSpeed;
        public Car()
        {
            MaxSpeed = 100;
        }

        public Car(int maxSpeed)
        {
            MaxSpeed = maxSpeed; ;
        }
        public int Speed
        {
            get { return _currSpeed; }
            set { _currSpeed = value > 100 ? 100 : value; }
        }
    }
}

sealed class MiniVan : Car { }
