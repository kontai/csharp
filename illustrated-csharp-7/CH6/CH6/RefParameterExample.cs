using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class RefParameterExample
    {
        public static void Main()
        {
            MyClass a1 = new MyClass();
            int a2 = 10;
            MyMethod(a1, ref a2);
            Console.WriteLine($"a1.val: {a1.val}, a2: {a2}");

        }

        static void MyMethod(MyClass f1, ref int f2)
        {
            f1.val = f1.val + 5;
            f2 = f2 + 5;
            Console.WriteLine($"f1.val: {f1.val}, f2: {f2}");
        }
    }
    class MyClass
    {
        public int val = 20;
    }
}
