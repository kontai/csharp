using System.Diagnostics;

namespace CH21.等待任務TaskWait.延遲;

class Simple
{
    Stopwatch sw = new Stopwatch();

    public void DoRun()
    {
        Console.WriteLine("Caller: Before call");
        ShowDelayAsync();
        Console.WriteLine("Caller: After call");
    }

    async void ShowDelayAsync()
    {
        sw.Start();
        Console.WriteLine($"  Before Delay: {sw.ElapsedMilliseconds}");
        await Task.Delay(1000);
        Console.WriteLine($"After Delay: {sw.ElapsedMilliseconds}");
    }
}
public class TaskDelayExample
{
    public static void Main(string[] args)
    {
        Simple ds = new Simple();
        ds.DoRun();

        Console.WriteLine("按下Enter結束");
        Console.Read();
    }
}