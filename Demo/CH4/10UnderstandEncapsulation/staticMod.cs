using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static System.DateTime;

namespace staticModNS
{
    internal class staticMod
    {
        public static void PrintDate()
        {
            WriteLine($"Today is {Today.ToShortDateString()}");
        }
        public static void PrintTime()
        {
            WriteLine($"Now is {Now.ToShortTimeString()},{Now.Minute}");
        }

    }
}
