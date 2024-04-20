using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CH9
{
    public class MyType
    {
        public int X;

        public MyType(int x)
        {
            X = x;
        }

        public static MyType operator ++(MyType m)
        {
            var a = m.X;
            MyType temp = new MyType(a);
            m.X ++;
            return m;
        }
    }

    internal class SefIncrementOpExample
    {
        private static void Show(string message, MyType tx)
        {
            Console.WriteLine($"message) {tx.X}");
        }

        public static void Main()
        {
            MyType tv = new MyType(10);
            //Console.WriteLine("Pre-increment");
            //Show("Before ", tv);
            //Show("Returned ", ++tv);
            //Show("Afger ", tv);

            tv = new MyType(10);
            Console.WriteLine("Post-increment");
            Show("Before ", tv);
            Show("Returned ", tv++);        //不是10? 因為類是傳遞引用
            Show("Afger ", tv);
        }
    }
}