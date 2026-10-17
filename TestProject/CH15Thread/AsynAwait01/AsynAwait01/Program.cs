var someString = DoWorkAsync();
Console.WriteLine("main");
try
{
    await DoWork();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
// Console.WriteLine("主程序 等待中");
// Thread.Sleep(5_000);
// Console.WriteLine(someString.Result);
Console.ReadLine();

static async Task DoWork()
{
    // Thread.Sleep(5_000);
     await Task.Run(async () =>
    {
        // await Task.Delay(5_000);
        Thread.Sleep(5_000);
        throw new Exception("Something bad happened");

    });
    Console.WriteLine("DoWork Done");
}

static async Task<string> DoWorkAsync()
{
    // Thread.Sleep(5_000);
    return await Task.Run(async () =>
    {
        await Task.Delay(5_000);
        return "Done Work";
    });
}