using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH27
{
    internal class Demo02_NullCondicionalOperator
    {
        static void Main(string[] args)
        {
            int[] fruits = null;
            int? fruitConunt = 20;

            if (fruits != null)
                fruitConunt = fruits.Length;
            Console.WriteLine($"fruitCount: {fruitConunt}");

            fruitConunt = fruits?.Length;
            Console.WriteLine($"fruitCount: {fruitConunt}");

            /*
            int i = 20;
            var s = i?.ToString();  //錯誤:空條件運算符號不能用於非空類型
            */

        }
    }
}
