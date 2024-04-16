using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class Demo
    {
        public static void Main()
        {
            BigInteger res = foo(10);
            Console.WriteLine(res);
        }

        static BigInteger foo(int x)
        {
            if (x == 1)
            {
                return x;
            }

            return x * foo(x - 1);
        }
    }


}
