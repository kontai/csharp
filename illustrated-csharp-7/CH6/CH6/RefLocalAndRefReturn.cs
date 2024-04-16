using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CH6
{
    internal class RefLocalAndRefReturn
    {
        public static void Main()
        {
            //ref局部变量y是x的別名
            //int x = 0;
            //ref int y = ref x;
            //y = 20;
            //Console.WriteLine($"x:{x},y:{y}");

            int v1 = 10;
            int v2 = 20;
            Console.WriteLine("Start");
            Console.WriteLine($"v1:{v1}, v2:{v2}");

            ref int max = ref Max(ref v1, ref v2);
            Console.WriteLine("After assigment");
            Console.WriteLine($"max: {max}");

            max++;
            Console.WriteLine("After increment");
            Console.WriteLine($"max: {max}, v1:{v1}, v2:{v2}");
        }

        static ref int Max(ref int p1, ref int p2)
        {
            if (p1 > p2)
            {
                return ref p1;
            }
            else
            {
                return ref p2;
            }
        }
    }
}
