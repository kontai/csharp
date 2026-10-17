using IssueOfConcurency;

Printer p = new Printer();
Thread[] th = new Thread[10];
Thread.CurrentThread.Name = "Main";
Lock _lock=new Lock();
for (int i = 0; i < 10; i++)
{
 th[i] = new Thread(new ThreadStart(() => p.LazyPrinter()));
    th[i].Name = $"Thread{i}";
}
for (int i = 0; i < 10; i++)
{
    th[i].Start();
}

Console.WriteLine("Thread {0} done!",Thread.CurrentThread.Name);
