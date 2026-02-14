using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH8.abstract_keyword
{
    internal abstract class AbstractClassExample2
    {
        public static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.PrintStuff("This is a string.");
            mc.MyInt = 28;
            Console.WriteLine(mc.MyInt);
            Console.WriteLine($"Perimeter: {mc.PerimeterLength()}");
        }
    }

    abstract class MyBase       //抽象和非抽象成員的組合
    {
        public int SideLength = 10;     //數據成員
        private const int TriangleSideCount = 3;    //數據成員

        public abstract void PrintStuff(string s);  //抽象方法

        public abstract int MyInt { get; set; } //抽象屬性

        public int PerimeterLength()
        {
            return TriangleSideCount * SideLength;  //普通的非抽象方法
        }

    }

    class MyClass : MyBase
    {
        public override void PrintStuff(string s)   //覆寫抽象方法
        {
            Console.WriteLine(s);
        }

        private int myInt;

        public override int MyInt   //覆寫抽象屬性
        {
            get { return myInt; }
            set { myInt = value; }
        }
    }
}