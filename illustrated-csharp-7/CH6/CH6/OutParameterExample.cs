using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class OutParameterExample
    {
        static void Main(string[] args)
        {
            //c#7.0之前,out方法調用之前要先聲明變量
            //MyClass a1 = null;
            //int a2;
            //MyMethod(out a1, out a2);

            //c#7.0 , 可以在調用方法時,於參數列表中聲明變量.變量於方法返回後仍可使用。
            MyMethod(out MyClass a1, out int a2);
            Console.WriteLine($"a1: {a1.val}, a2: {a2}");
        }


        static void MyMethod(out MyClass f1, out int f2)
        {
            f1 = new MyClass();
            f1.val = 25;
            f2 = 15;
        }
    }
    class MyClass
    {
        public int val = 20;
    }
}
