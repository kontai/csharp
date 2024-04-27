using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CH10
{
    internal class ForLoopExample
    {
        public static void Main()
        {
            for (int i = 0; i < 10; i++)        //變量i是局部的，仅在for迴圈內有效
            {
                Console.WriteLine(i);
            }
            for (int i = 10; i > 0; i--)
            {

            }
        }
    }
}