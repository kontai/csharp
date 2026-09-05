using System.Reflection;
using MultsiThreadedPrinting;

Printer p = new Printer();

Thread[] threads = new Thread[5];

for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(new ThreadStart(p.InterLockedPrintNumber));
    threads[i].Name = $"Worker thread #{i}";
}

foreach (var worker in threads)
{
    worker.Start(); // 全部先啟動,讓 5
    //個執行緒同時併發跑
}

foreach (var worker in threads)
{
    worker.Join(); //
    //全部啟動之後,才依序等待每個執行緒結束
}

Console.WriteLine($"最終結果: {Printer.count}");
