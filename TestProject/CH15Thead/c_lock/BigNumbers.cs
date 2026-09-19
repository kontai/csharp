namespace c_lock;

public class BigNumbers
{
    private static  readonly object _lock = new object();
    // private static int[] _numbers = Enumerable.Range(1, 100000).ToArray();
    public static int Number = 0;
    public void PrintNumbers()
    {
            for (int i = 0; i < 100000000; i++)
            {
                lock (_lock)
                {
                    Number++;
                }
            }
            Console.WriteLine($"{Number} {Thread.GetCurrentProcessorId()}");
    }

    public void InterLockPrintNumber(int _)
    {
        for (int i = 0; i < 100000000; i++)
        {
            Interlocked.Increment(ref Number);
        }
        Console.WriteLine($"{Number} {Thread.GetCurrentProcessorId()}");
    }
}