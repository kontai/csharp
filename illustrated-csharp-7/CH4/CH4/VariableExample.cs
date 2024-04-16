using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CH4
{
    internal class VariableExample
    {
        public static void Main()
        {
            int x, y;   //區域變量，未初始化，其值不


            //Console.WriteLine(x);
            //Console.WriteLine(y);

            Foo foo = new Foo();
            Console.WriteLine($"{foo.X} {foo.Y}");


            //dynamic
            dynamic a = 23.1;   //dunamic俢鉓的變量，於編譯期間不衱解析，運行時才會檢查。
            bool b1 = a is char;
            Console.WriteLine(b1);

            Nullable<int> a = new Nullable<int>();
            a = null;
            a = 23;
        }
    }

    class Foo
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
