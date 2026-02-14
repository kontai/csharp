using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CH7.Trivial;


namespace CH7
{
    internal class StaticPropertyExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Init Value: {0}", Trivial.MyValue);
            Trivial.MyValue = 10;
            Console.WriteLine("New Value: {0}", Trivial.MyValue);

            MyValue = 20;
            Console.WriteLine($"The Value:{MyValue}");

            Trivial tr = new Trivial();
            tr.PrintValue();
        }
    }
    class Trivial
    {
        public static int MyValue { get; set; }

        public void PrintValue()
        {
            Console.WriteLine("Value from inside: {0}", MyValue);
        }
    }
}
