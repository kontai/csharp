using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class OverloadingExampl
    {
        public static void Main()
        {

        }

        class A
        {

            long AddValues(int a, int b)
            {
                return a + b;
            }

            long AddValues(int a, int b, int c)
            {
                return a + b + c;
            }

            long AddValues(float f, float g)
            {
                return (long)(f + g);
            }

            long AddValues(long h, long m)
            {
                return h + m;
            }
        }
    }
}
