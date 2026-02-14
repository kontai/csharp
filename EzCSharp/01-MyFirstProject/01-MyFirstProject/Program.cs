using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCal;
using CSharwpCalc;

namespace MyNamespaceA;
class Program
{
    static void Main(string[] args)
    {
        myAdd add = new myAdd();
        Console.WriteLine(add.Add(20, 30));

        //Console.Read();
        CSharwpCalc.Class1 class1 = new Class1();
        Console.WriteLine(class1.Add(3.2, 2.3));
        ;

    }
}

