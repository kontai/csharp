using System.Net;

namespace CH21.等待任務.同步等待;

static class MyDownloadString
{
    public static void DoRun()
    {
        Task<int> t = CountCharacterAsync("http://www.illustratedcsharp.com");

        //t.Wait();   //等待任務
        Console.WriteLine($"The task has finished, returning value {t.Result}");

        Console.Write("press any key to exit.....");
        Console.Read();
    }
    private static async Task<int> CountCharacterAsync(string site)
    {
        string result = await new WebClient().DownloadStringTaskAsync(site);
        Console.WriteLine("processing result, this may take a while...");
        return result.Length;
    }
}

public class WaitExample
{
    public static void Main(string[] args)
    {
        MyDownloadString.DoRun();
    }
}