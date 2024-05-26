using System.Diagnostics;

namespace CH21.等待任務.同步等待;

internal class MyDownloadString
{
    private Stopwatch sw = new Stopwatch();

    public void DoRun()
    {
        sw.Start();
        Task<int> t1 = CountCharacterAsync(1, "http://www.microsoft.com");
        Task<int> t2 = CountCharacterAsync(2, "http://www.illustratedcsharp.com");

        //Task.WaitAll(t1, t2);   //等待全部任務完成
        //Task.WaitAny(t1, t2);   //等待任一個任務完成
        t1.Wait(10000); //只等待10000ms,超過時間就不等了。


        Console.WriteLine("Task 1: {0}Finished", t1.IsCompleted ? "" : "Not ");
        Console.WriteLine("Task 2: {0}Finished", t2.IsCompleted ? "" : "Not ");
        //Console.Write("Press any key to exit...");
        Console.Read();

    }

    private async Task<int> CountCharacterAsync(int id, string site)
    {
        HttpClient hc = new HttpClient();
        string result = await hc.GetStringAsync(site);
        Console.WriteLine("  Call {0} completed:    {1,4:N} ms", id, sw.Elapsed.TotalMilliseconds);
        return result.Length;
    }
}

public class WaitLLAnyExample
{
    public static void Main2(string[] args)
    {
        MyDownloadString ds = new MyDownloadString();
        ds.DoRun();
    }
}