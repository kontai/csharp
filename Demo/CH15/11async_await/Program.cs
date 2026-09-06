using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Fun with Async ====>");
Console.WriteLine("current id: {0}", Environment.CurrentManagedThreadId);
var task = DoWorkAsync(); //不阻塞，立刻往下走
Console.WriteLine("等待时可以做别的事...");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"主线程还活着: {i}");
    await Task.Delay(1000);
}
string word = await task;

//同步阻塞版本 vs异步版本的对照）。
//Console.WriteLine(DoWork());
Console.WriteLine(word);

Console.WriteLine("Completed");

string DoWork()
{
    Thread.Sleep(5_000);
    return "Done with work!";
}

static async Task<string> DoWorkAsync()
{
    //await Task.Delay(5_000);
    return await Task.Run(() =>
    {
        Console.WriteLine("current id: {0}", Environment.CurrentManagedThreadId);
        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine($"Doing work: {i}/15");
            //int[] largeInt = Enumerable.Range(0, 500_000_000).ToArray();
            Thread.Sleep(500);
        }

        return "Done with work!";
    });
}
