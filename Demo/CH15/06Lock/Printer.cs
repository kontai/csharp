using System;
using System.Collections.Generic;
using System.Text;

namespace MultsiThreadedPrinting;

internal class Printer
{
    // 🌟 最佳實踐：宣告一個私有且專屬的「鎖定權杖 (鑰匙)」
    private Object _lock = new Object();

    public void PrintNumbers()
    {
        // 🌟 進入防護區！請求取得鑰匙！
        // 如果鑰匙被別人拿走了，目前的工人就會在這裡「乖乖排隊」！
        lock (_lock)
        {
            // 進入了 lock 區塊，這裡面的程式碼保證是「執行緒安全 (Thread Safe)」的！
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
        // 🌟 離開大括號的瞬間，工人會自動把鑰匙掛回牆上！
    }

    //lock實際上在編譯時，編譯器將會自動將這段程式碼轉換成以下形式：
    public void RealLock()
    {
        try
        {
            Monitor.Enter(_lock);
            // 進入了 lock 區塊，這裡面的程式碼保證是「執行緒安全 (Thread Safe)」的！
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
}
