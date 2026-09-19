using SimpleThreadDemo;

Thread mainThread = Thread.CurrentThread;
Console.WriteLine("main thread id= {0}", mainThread.ManagedThreadId);
Console.WriteLine("How many thread you want to create?[1],[2]: ");
string? count = Console.ReadLine();
Print print = new Print();

if (int.TryParse(count, out int i))
{
    switch (i)
    {
        case 1:
            print.LazyFunc();
            break;
        case 2:
            Thread th2 = new Thread(new ThreadStart(print.LazyFunc));
            th2.Start();
            th2.IsBackground = true;    //設置為背景執行緒
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

Console.WriteLine("main thread end");