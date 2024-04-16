using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH6
{
    internal class NamedParameterExample
    {
        public static void Main()
        {
            MyClass mc = new MyClass();

            //位置參數與名稱參數同時使用時，位置參數必須放在名稱參數前面
            int result = mc.Calc(c: 2, b: 3, a: 4);
            Console.WriteLine("{0}", result);

            //名稱參數,冒號左邊是行參名,冒號右邊是實際參數值或表達式
            int ro = mc.Calc(4, 3, 2);
            int r1 = mc.Calc(4, b: 3, c: 2);
            int r2 = mc.Calc(4, c: 2, b: 3);
            int r3 = mc.Calc(c: 2, b: 3, a: 4);
            int r4 = mc.Calc(c: 2, b: 1 + 2, a: 3 + 1);
            Console.WriteLine($"{ro}, {r1}, {r2}, {r3}, {r4}");
        }

    }

    class MyClass
    {
        public int Calc(int a, int b, int c)
        {
            return (a + b) * c;
        }
    }
}
