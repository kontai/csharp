using System.Threading.Channels;

namespace CH21.異步方法.自定義await;

internal static class MyClass
{
    public static async Task DoWorkAsync()
    {
        await Task.Run(() => Console.WriteLine((5.ToString())));    //Action

        Console.WriteLine((await Task.Run(() => 6)).ToString());    //TResult Func()

        await Task.Run(() => Task.Run(() => Console.WriteLine((7.ToString()))));    //Task Func()

        int value = await Task.Run(() => Task.Run(() => 8));    //Task<TResult> Func()
        Console.WriteLine(value.ToString());
    }
}

public class TaskRun4TypeDeleg
{
    public static void Main(string[] args)
    {
        Task t = MyClass.DoWorkAsync();
        t.Wait();
        Console.WriteLine("Press Enter key to exit");
    }
}