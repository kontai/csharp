using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH27
{
    internal class Demo03_embedClass
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();
            sc.PrintOut();
            foreach (var se in args)
            {
                Console.WriteLine($"{se}");
            }
        }

        class SomeClass
        {
            private int field1 = 10, field2 = 15;
            private readonly MyClass? _mc = null;

            public SomeClass()
            {
                _mc = new MyClass();
            }

            public void PrintOut()
            {
                _mc.PrintOut(this);
            }

            class MyClass
            {
                public void PrintOut(SomeClass sc)
                {
                    Console.WriteLine($"field1: {sc.field1}, field2: {sc.field2}");
                }
            }
        }
    }
}