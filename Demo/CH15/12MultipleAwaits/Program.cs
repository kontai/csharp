await MultiAwait().ConfigureAwait(false);
Console.WriteLine("Done with all tasks!");

static async Task MultiAwait()
{
    var t1= Task.Run(() => Thread.Sleep(2000));
    //Console.WriteLine("Done with first task!");
    var t2= Task.Run(() => Thread.Sleep(2000));
    //Console.WriteLine("Done with second task!");
    var t3= Task.Run(() => Thread.Sleep(2000));
    //Console.WriteLine("Done with third task!");
    await Task.WhenAll(t1, t2, t3);

}