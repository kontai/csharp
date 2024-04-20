using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH9
{
    internal class LimitedInt
    {
        private const int MaxValue = 100;
        private const int MinValue = 0;

        public static LimitedInt operator -(LimitedInt x)
        {

            LimitedInt li = new LimitedInt();
            li.theValue = 0;
            return li;
        }

        public static LimitedInt operator +(LimitedInt x, double y)
        {
            LimitedInt li = new LimitedInt();
            li.theValue = x.theValue + (int)y;
            return li;
        }

        public static LimitedInt operator -(LimitedInt x, LimitedInt y)
        {
            LimitedInt li = new LimitedInt();
            li.theValue = x.theValue - y.TheValue;
            return li;
        }
        private int theValue = 0;

        public int TheValue
        {
            get { return theValue; }
            set
            {
                if (value < MinValue)
                {
                    theValue = 0;
                }
                else
                {
                    theValue = value > MaxValue
                        ? MaxValue
                        : value;
                }
            }
        }
    }

    internal class OperatorOverloadExample
    {
        public static void Main()
        {
            LimitedInt li1 = new LimitedInt();
            LimitedInt li2 = new LimitedInt();
            LimitedInt li3 = new LimitedInt();
            li1.TheValue = 10; li2.TheValue = 26;
            Console.WriteLine($"li1={li1.TheValue}, li2={li2.TheValue}");

            li3 = -li3;
            Console.WriteLine($"-{li1.TheValue}={li3.TheValue}");

            li3 = li2 - li1;
            Console.WriteLine($"{li2.TheValue}-{li1.TheValue} = {li3.TheValue}");

            li3 = li1 - li2;
            Console.WriteLine($"{li2.TheValue}-{li1.TheValue} = {li3.TheValue}");
        }
    }
}