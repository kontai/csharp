using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 等待直到完成模式
/// </summary>
/// <param name="first">The first.</param>
/// <param name="second">The second.</param>
/// <returns></returns>
delegate long MyDel(int first, int second); //聲明委托變量
public class WaitUntilDone
{
    static long sum(int x, int y)   //聲明異步方法
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

        long result = del.EndInvoke(iar);   //等待對象結束並獲取結果
        Console.WriteLine($"After EndInvoke: {result:N1}");
    }
}