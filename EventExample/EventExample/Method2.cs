using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    //新增委托
    internal class Method2
    {
        public delegate int Add(int x, int y);
        public static void Main()
        {


            int AddMethod(int x, int y)
            {
                return x + y;
            }

            int SubMethod(int x, int y)
            {
                return (x - y);
            }


                       
        }
    }
}
