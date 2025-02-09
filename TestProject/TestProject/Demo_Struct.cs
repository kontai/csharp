using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Demo_Struct
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            Point p2 = default; // 建立 Point 結構的實例，使用預設值
            Console.WriteLine($"x: {p.x}, y: {p.y}");
            Console.WriteLine($"x: {p2.x}, y: {p2.y}");

            Point2 p3 = default;    // 建立 Point3 結構的實例，使用預設值
            Console.WriteLine($"p3:x: {p3.x}, y: {p3.y}");

            //var pp = new Point[10]; //ref struct 不能用 new 來建立(不能在堆上建立)

        }
    }

    public ref struct Point
    {
        public int x = 1;
        public int y;

        public Point() => y = 3;
    }

    public readonly struct Point2(int x, int y)
    {
        public readonly int x = x;
        public readonly int y = y;
    }
}
