using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class ParamsArraysEzample
    {
        public static void Main()
        {
            int[] arrs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, };

            //method I
            Foo(1, 2, 3, 4, 5);

            //method II
            Foo(23, arrs);

        }

        //聲明一個參數數組，可以傳入多個參數,在變量前使用params闗鍵字修鉓。
        //只允許一個參數數組，並且位於參數列表最尾部。
        static void Foo(int x, params int[] inVals)
        {
            if ((inVals != null) && (inVals.Length > 0))
            {
                foreach (int val in inVals)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
