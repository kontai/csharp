
using System.Runtime.InteropServices.Marshalling;
using static System.Console;
using static System.Math;
using static CH7.D;

namespace CH7
{
    internal class StaticFieldExample
    {
        static void Main(string[] args)
        {
            D d1 = new D();
            D d2 = new D();

            d1.memA = 10;
            d2.memA = 20;

            Console.WriteLine($"d1.memA: {d1.memA}\nd2.memAA: {d2.memA}");


            //method 1
            D.memB = 30;

            //method 2
            //using static CH7.D;
            memB = 23;


        }

    }

    class D
    {
        public int memA;
        public static int memB;
    }
}
