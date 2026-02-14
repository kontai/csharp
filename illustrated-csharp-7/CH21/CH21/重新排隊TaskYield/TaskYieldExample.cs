namespace CH21.重新排隊TaskYield;

internal static class DoStuff
{
    public static async Task<int> FindSeriesSum(int i1)
    {
        int sum = 0;
        for (int i = 0; i < i1; i++)
        {
            sum += i;
            if (i % 1000 == 0)
                await Task.Yield();
        }



        return sum;
    }
}

public class TaskYieldExample
{
    public static void Main(string[] args)
    {
        Task<int> value = DoStuff.FindSeriesSum(1000000);
        Console.WriteLine("back to main thread");
        CountingBig(10);
        CountingBig(10);
        CountingBig(10);
        CountingBig(100000);
        CountingBig(100000);
        CountingBig(100000);
        Console.WriteLine($"Sum:{value.Result}");
    }

    private static void CountingBig(int p)
    {
        for (int i = 0; i < p; i++)
        {
            ;
        }

        Console.WriteLine("CountingBig Finiched {0}", Thread.CurrentThread.ManagedThreadId);
    }
}