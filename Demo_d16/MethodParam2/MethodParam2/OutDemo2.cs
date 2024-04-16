using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodParam2
{
    internal class OutDemo2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Pleae input first number=>");
            string arg1 = Console.ReadLine();
            double x = 0;
            bool b1 = DoubleParser.MyTryParse(arg1, out x);
            if (!b1)
            {
                Console.WriteLine("Number error!");
                return;
            }

            Console.WriteLine("Pleae input second number=>");
            string arg2 = Console.ReadLine();
            double y = 0;
            bool b2 = DoubleParser.MyTryParse(arg2, out y);
            if (!b2)
            {
                Console.WriteLine("Number error!");
                return;
            }

            Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
        }
    }

    class DoubleParser
    {
        public static bool MyTryParse(string? str, out double result)
        {
            try
            {
                result = double.Parse(str);
            }
            catch
            {
                Console.WriteLine();
                result = 0;
                return false;
            }
            return true;
        }
    }
}
