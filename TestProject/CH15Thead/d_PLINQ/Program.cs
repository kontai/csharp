using CancellationTokenSource cts = new CancellationTokenSource();
do
{
    Console.WriteLine("Stat any key to porcessing:");
    Console.ReadLine();
    Console.WriteLine("Processing...");
    Task myTask = Task.Factory.StartNew(ProcessMethod);
    Console.WriteLine("Press \"Q\" to quit:");
    string? key = Console.ReadLine();
    if (key.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        cts.Cancel();
        myTask.Wait();
        break;
    }
} while (true);

void ProcessMethod()
{
    int[] largeArray = Enumerable.Range(1, 10_000_000).ToArray();
    int[] modThreeIsZero = null;

    try
    {
        Thread.Sleep(3_000);
        modThreeIsZero = largeArray.AsParallel().WithCancellation(cts.Token).Where(i => i % 3 == 0).ToArray();
        var take10 = modThreeIsZero.Take(10).ToArray();
        foreach (var i in modThreeIsZero.Take(10))
        {
            Console.WriteLine(i);
        }
    }
    catch (OperationCanceledException e)
    {
        Console.WriteLine(e.Message);
        throw;
    }
}