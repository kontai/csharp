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


            //dynamic -高精度的變量,常用於貨幣的計算
            dynamic a = 23.1;   //dunamic俢鉓的變量，於編譯期間不衱解析，運行時才會檢查。
            bool b1 = a is char;
            Console.WriteLine(b1);

            Nullable<int> nullable = new Nullable<int>();
            a = null;
            a = 23;

            Test();
        }

        //dynamic 動態類型-在編譯期間不檢查,在執行期間檢查 (類似於python)
    public static void Test()
    {
        dynamic a;
        a = 20;
        Console.WriteLine(a);

        a="hello";
        Console.WriteLine(a);

        a = 2.34f;
        Console.WriteLine(a);

    }
    }

    class Foo
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}

