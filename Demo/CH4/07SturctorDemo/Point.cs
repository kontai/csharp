using System;
using System.Collections.Generic;
using System.Text;

namespace _07SturctorDemo
{
    struct Point
    {
        private int x = 5;
        private int y = 10;

        public Point(int _x, int _y)
        {
            Console.WriteLine("In construcor , x= {0},y= {1}", x, y);
            this.x = _x;
            this.y = _y;
        }

        public void Display()
        {
            Console.WriteLine("x= {0},y= {1}", x, y);
        }

        public void Increment()
        {
            x++;
            y++;
        }

        public void Decrement()
        {
            x--;
            y--;
        }
    }

    readonly struct ReadOnlyPoint
    {
        public int X { get; }
        public int Y { get; }

        public ReadOnlyPoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public void Display()
        {
            Console.WriteLine("x= {0},y= {1}", X, Y);
        }
    }

    ref struct disposePoint
    {
        public int X;
        public readonly int Y;

        public readonly void Display()
        {
            Console.WriteLine($"x= {X},y= {Y}");
        }

        //A custom constructor.
        public disposePoint(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public void Dispose()
        {
            //cleann up any resources here
            Console.WriteLine("Disposed!");
        }
    }
}