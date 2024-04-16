using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7.分部類和分部方法
{

    partial class MyClass
    {
        partial void PrintSum(int x, int y)     //實現分部方法
        {
            Console.WriteLine("Sum is {0}", x + y);     //實現部分
        }
    }
}
