void WriteProgressToConsole(int percentComplete)
{
    Console.WriteLine(percentComplete);
}

void WriteProgressToFile(int percentComplete)
{
    Console.WriteLine(percentComplete);
}

ProgressRepoter r = WriteProgressToConsole;
r += WriteProgressToFile;

Util.HardWork(r);


public delegate void ProgressRepoter(int percentComplete);

public class Util
{
    public static void HardWork(ProgressRepoter p)
    {
        for (int i = 0; i < 10; i++)
        {
            p(i * 10);
            Thread.Sleep(100);
        }
    }
}