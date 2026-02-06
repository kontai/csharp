using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class Program {

    public static void Main(string[] args)
    {
        //func();

        LinqQueryOverInts();
        void func()
        {
            //var myLocalVal; //需要給值
            //var myLocalVal = null;  //不可為空

            var fp = new SportCar();
            fp = null;  //參考類型，可為null
        }

        static int retInt()
        {
            var value = 20;
            var aFunc = new SportCar();
            return value;
        }

        void func2()
        {
            var s = "this is a string!";
            //s = 20;
        }

        void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            IEnumerable<int> res = from v in numbers where v < 10 select v;
            foreach (int re in res)
            {
                Console.Write($"{re} ");
            }

            Console.WriteLine();

            Console.WriteLine(numbers.GetType().Name);  //Int32[]
            Console.WriteLine(numbers.GetType().Namespace); //System
        }
    }
}

internal class SportCar {
}

internal class ThiswillNeverComplile {
    //var 不可使用於成員參數
    //private var myInt = 0;

    //public var myFunc(var a, var b);
}