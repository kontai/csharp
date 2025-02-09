MyReporter r = new MyReporter { Prefix = "%Complete: " };
ProgressReporter p = r.ReportProgress;
p(99);
Console.WriteLine(p.Target);
Console.WriteLine(p.Method);
r.Prefix = "";
p(99);

public delegate void ProgressReporter(int percentComplete);

class MyReporter
{
    public string Prefix = "";
    public void ReportProgress(int percentComplete) => Console.WriteLine($"{Prefix} {percentComplete}");

}