namespace CH21.等待任務TaskWait.異步等待;

class MyDownloadString
{
    public void DoRun()
    {
        Task<int> t = CountCharacterAsync("http://www.microsoft.com", "http://www.illustratedcsharp.com");
        Console.WriteLine("DoRun: Task: {0}Finished", t.IsCompleted ? "" : "Not");
        Console.WriteLine("DoRun: Result = {0}", t.Result);
    }

    async Task<int> CountCharacterAsync(string site1, string site2)
    {
        HttpClient hc1 = new HttpClient();
        HttpClient hc2 = new HttpClient();
        Task<string> t1 = hc1.GetStringAsync(site1);
        Task<string> t2 = hc2.GetStringAsync(site2);

        List<Task<string>> tasks = new List<Task<string>>();
        tasks.Add(t1);
        tasks.Add(t2);

        //await Task.WhenAll(tasks);  //異步等待
        await Task.WhenAny(tasks);

        Console.WriteLine("  CCA: T1 {0}Finished", t1.IsCompleted ? " " : "Not ");
        Console.WriteLine("  CCA: T2 {0}Finished", t2.IsCompleted ? " " : "Not ");

        return t1.IsCompleted ? t1.Result.Length : t2.Result.Length;
    }
}
public class WhenAllAnyExample
{
    public static void MainWhen(string[] args)
    {
        MyDownloadString ds = new MyDownloadString();
        ds.DoRun();
    }
}