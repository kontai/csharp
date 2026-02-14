using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class OptionalParameterExample
    {
        public static void Main(string[] args)
        {
            OptionalParameterExample mc = new OptionalParameterExample();
            int r0 = mc.Calc(5, 6, 7);      //使用所有的显式值
            int r1 = mc.Calc(5, 6);         //为使用默认值
            int r2 = mc.Calc(5);            //为b和c使用默认值
            int r3 = mc.Calc();             //使用所有的默认值

            Console.WriteLine($"{r0}, {r1}, {r2}, {r3}");

        }
        public int Calc(int a = 2, int b = 3, int c = 4)
        {
            return (a + b) * c;
        }

    }
}
