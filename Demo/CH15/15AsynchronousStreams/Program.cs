// await foreach (var number in GetNumbersAsync())
// {
//     System.Console.WriteLine(number);
// }

var t1 = Task.Run(async () =>
{
    await foreach (var number in GetNumbersAsync())
    {
        System.Console.WriteLine(number);
    }
}
);

var t2 = Task.Run(async () =>
{
    await foreach (var number in GetNumbersAsync())
    {
        System.Console.WriteLine(number);
    }
}
);


var t3 = Task.Run(async () =>
{
    await foreach (var number in GetNumbersAsync())
    {
        System.Console.WriteLine(number);
    }
}
);

await Task.WhenAll(t1, t2, t3);
// Parallel.ForEach(new[] { t1, t2, t3 }, t => t.Wait());





static async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}