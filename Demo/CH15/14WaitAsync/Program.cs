
CancellationTokenSource _cancelToken = new CancellationTokenSource();

try
{
    await WorkFunc().WaitAsync(TimeSpan.FromSeconds(5), _cancelToken.Token);   // 5秒内完成，否则取消
    System.Console.WriteLine("Main thread is done");
}
catch (TimeoutException e)
{
    System.Console.WriteLine(e.Message);
    CancelFun();
}

void CancelFun()
{
    System.Console.WriteLine("CancelFunc is called");
    _cancelToken.Cancel();
}

async Task WorkFunc()
{
    try
    {
        if (_cancelToken.IsCancellationRequested)
        {
            return;
        }
        await Task.Delay(20000, _cancelToken.Token);
        Console.WriteLine("WorkFunc is done");

    }
    catch (OperationCanceledException e)
    {
        System.Console.WriteLine(e.Message);
        Console.WriteLine("WorkFunc is cancelled.");
    }
}
