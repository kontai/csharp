using System;
using System.Threading;

/// <summary>
/// 輸詢
/// </summary>
/// <param name="first">The first.</param>
/// <param name="second">The second.</param>
/// <returns></returns>

internal delegate long MyDel(int first, int second); //聲明委托變量

public class WaitUntilDone
{
    private static long sum(int x, int y)   //聲明異步方法
    {
        Console.WriteLine("                  Inside Sum");
        Thread.Sleep(500);
        return x + y;
    }

    public static void Main(string[] args)
    {
        MyDel del = new MyDel(sum);
        Console.WriteLine("Before BeginInvoke");
        IAsyncResult iar;
        try
        {
            iar = del.BeginInvoke(3, 5, null, null);
        }
        catch (PlatformNotSupportedException e)
        {
            //net core 不支援BeginInvoke (APM), 應使用Task-base async/await 取代
            Console.WriteLine(e.Message);   // The BeginInvoke method is not supported on this platform.
            return;
        }
        Console.WriteLine("After BeginInvoke");

        Console.WriteLine("Doing stuff");

        while (!iar.IsCompleted)    //
        {
            Console.WriteLine("Not Done");
            for (int i = 0; i < 10_000; i++)
                ;
        }

        Console.WriteLine("Done");
        long result = del.EndInvoke(iar);   //調用EndInvoke方法, 取得IAsyncResult接口並進行清理。

        Console.WriteLine($"Result: {result}");
    }
}