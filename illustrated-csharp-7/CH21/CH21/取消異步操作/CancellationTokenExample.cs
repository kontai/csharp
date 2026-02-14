using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH21.取消異步操作
{
    internal class CancellationTokenExample
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            MyClass mc = new MyClass();
            Task t = mc.RunAsync(token);
            Task t2 = mc.RunAsync(token);

            Console.WriteLine("Back to Main method");
            Thread.Sleep(3000);   //等待任務
            cts.Cancel();   //取消任務

            Console.WriteLine($"Was Cancelled: {token.IsCancellationRequested}");
        }
    }

    internal class MyClass
    {
        public async Task RunAsync(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;
            await Task.Run(() => CycleMethod(ct), ct);
        }

        void CycleMethod(CancellationToken ct)
        {
            Console.WriteLine("Starting CycleMethod");
            int max = 5;
            for (int i = 0; i < max; i++)
            {
                if (ct.IsCancellationRequested)
                    return;
                Thread.Sleep(1000);
                Console.WriteLine($"{i + 1} of {max} iterations completed");
            }
        }
    }
}