using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CH12
{
    internal enum Point : ulong       //將底層整數類型畋為ulong
    {
        Green,                  //預設為0
        Yellow = 20,
        Red,                    //無設正值，預設為上一個值加1 (20+1)=21
    }

    internal class EnumSimpleExample
    {
        public static void Main()
        {
            Point p1 = Point.Green;
            Point p2 = Point.Yellow;
            Point p3 = Point.Red;

            Console.WriteLine($"{p1}\t{(int)p1}");
            Console.WriteLine($"{p2}\t{(int)p2}");
            Console.WriteLine($"{p3}\t{(int)p3}");
        }
    }
}