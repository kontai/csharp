using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CH8
{
    internal class BaseRefExample
    {
        public static void Main(string[] args)
        {
            MyDerivedClass derived = new MyDerivedClass();
            MyBaseClass mybc = (MyBaseClass)derived;      //轉成基類

            derived.Print();       //調用子類的Print方法
            mybc.Print();           //調用父類的Print方法

            //mybc.var1 = 5;        //錯誤，基類沒有該成員

        }
    }

    class MyBaseClass
    {
        public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        public int var1;

        public new void Print()
        {
            Console.WriteLine("This is the derived class.");
        }
    }
}
