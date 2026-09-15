using SimpleThreadDemo;
// Thread mainThread = Thread.CurrentThread;
Console.WriteLine("Main Thread ID: {0}",Environment.CurrentManagedThreadId);
RunMultiThreads();
Console.WriteLine("Main Thread End");


void RunMultiThreads()
{
    Print print = new Print();
    Thread[] ths=new Thread[10];
    for (int i = 0; i < 10; i++)
    {
        ths[i] = new Thread(new ThreadStart(print.LazyFunc));
        ths[i].Name="thread "+i;
    }
    for (int i = 0; i < 10; i++)
    {
        ths[i].Start();
    }
}