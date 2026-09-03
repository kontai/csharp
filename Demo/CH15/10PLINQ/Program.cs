using CancellationTokenSource _cancelToken = new();

do
{
    Console.WriteLine("Start any key to start processing:");
    Console.ReadKey();
    Console.WriteLine("Processing...");
    Task myTask = Task.Factory.StartNew(ProcessIntData);
    Console.WriteLine("Enter Q to quit: ");
    string? answer = Console.ReadLine();
    //Does user want to quit?
    if (string.Equals(answer, "Q", StringComparison.OrdinalIgnoreCase))
    {
        _cancelToken.Cancel();
        myTask.Wait();
        break;
    }
} while (true);

//ProcessIntData();

void ProcessIntData()
{
    int[] largeArray = Enumerable.Range(0, 10_000_000).ToArray();
    int[] modThreeIsZero = null;

    //using Linq query  values are divided by 3
    //int[] res = (
    //    from num in largeArray
    //    where num % 3 == 0
    //    orderby num descending
    //    select num
    //).ToArray();
    //Console.WriteLine($"找到{res.Count()}個數字，並且是3的倍數");

    //using PLINQ
    try
    {
        Thread.Sleep(3000);
        modThreeIsZero = (
            from n in largeArray.AsParallel().WithCancellation(_cancelToken.Token)
            where n % 3 == 0
            orderby n descending
            select n
        ).ToArray();

        var take10Res = modThreeIsZero.Take(10).ToArray();

        foreach (var item in take10Res)
        {
            Console.WriteLine(item);
        }
    }
    catch (OperationCanceledException e)
    {
        Console.WriteLine(e.Message);
    }
}
