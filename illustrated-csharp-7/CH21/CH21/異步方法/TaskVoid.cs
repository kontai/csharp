using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH21.異步方法
{
    internal class TaskVoid
    {
        public static void Main(string[] args)
        {
            Task someTask = DoAsyncStuff.CalculateSumAsunc(5, 6);
            someTask.Wait();
            Console.WriteLine("Async stuff is done");
        }
    }

    internal static class DoAsyncStuff
    {
        public static async Task CalculateSumAsunc(int i1, int i2)
        {
            int value = await Task.Run(() => GetSum(i1, i2));
            Console.WriteLine("Value: {0}", value);
        }

        private static int GetSum(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}