using System;

namespace Panel_Script
{
    public struct Point_XY_
    {
        private double x;
        private double y;
        public double X
        {
            get => x;
            set => x = Math.Round(value,6);
        }
        public double Y
        {
            get => y;
            set => y = Math.Round(value,6);
        }

        double dist()=> Math.Sqrt(X * X + Y * Y);

    }
}