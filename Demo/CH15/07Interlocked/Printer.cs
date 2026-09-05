using System;
using System.Collections.Generic;
using System.Text;

namespace MultsiThreadedPrinting;

internal class Printer
{
    // 🌟 最佳實踐：宣告一個私有且專屬的「鎖定權杖 (鑰匙)」
    private Object _lock = new Object();
    public static int count = 0;

    public void PrintNumbers()
    {
        // 🌟 進入防護區！請求取得鑰匙！
        // 如果鑰匙被別人拿走了，目前的工人就會在這裡「乖乖排隊」！
        // 進入了 lock 區塊，這裡面的程式碼保證是「執行緒安全 (Thread Safe)」的！
        try
        {
            Monitor.Enter(_lock);
            Console.WriteLine(
                "*** Worker Number #{0} is executing PrintNumber()",
                Thread.CurrentThread.Name
            );

            foreach (short number in Enumerable.Range(1, 10))
            {
                Random r = new Random();
                //💤隨機等待0~4秒
                Thread.Sleep(1000 * r.Next(5));
                Console.Write($"{number},");
            }
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }

    public void InterLockedPrintNumber()
    {
        Console.WriteLine(
            "*** Worker Number #{0} is executing PrintNumber()",
            Thread.CurrentThread.Name
        );
        for (int i = 0; i < 100000; i++)
        {
            //count += 1;
            Interlocked.Increment(ref count);
        }
        //如果只是單純作加、減法或賦值，可以使用 Interlocked，效率也會提高好幾倍🆙
    }
}
