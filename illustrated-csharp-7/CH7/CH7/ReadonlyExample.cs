using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7
{
    internal class ReadonlyExample
    {
        public static void Main(string[] args)
        {
            Shape s1 = new Shape(1, 2);
            Console.WriteLine(s1.shape);

            Shape s2 = new Shape(1, 2, 3);
            Console.WriteLine(s2.shape);
        }
    }

    class Shape
    {
        private readonly double PI = 3.1416;
        private readonly int NumberOfSides;
        public string shape { get; set; }

        public Shape(double side1, double side2)
        {
            NumberOfSides = 4;
            shape = "rectangle";
        }

        public Shape(double side1, double side2, double side3)
        {
            NumberOfSides = 3;
            shape = "triangle";
        }

    }
}
