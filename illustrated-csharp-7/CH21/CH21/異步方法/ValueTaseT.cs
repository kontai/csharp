using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH21.異步方法
{
    internal class ValueTaseT
    {
        public static void Main(string[] args)
        {
            ValueTask<int> vt = DoAsyncStuff.CalculateSumAsunc(0, 6);
            Console.WriteLine($"Value: {vt.Result}");
            vt = DoAsyncStuff.CalculateSumAsunc(5, 6);
            Console.WriteLine($"Value: {vt.Result}");

        }

    }

    static class DoAsyncStuff
    {
        public static async ValueTask<int> CalculateSumAsunc(int i1, int i2)
        {
            if (i1 == 0)    //如i1==0,則可以避免執行長時間運行的任務
            {
                return i2;
            }
            int sum = await Task<int>.Run(() => i1 + i2);
            return sum;
        }
    }
}
