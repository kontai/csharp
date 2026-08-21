using System.Diagnostics;
using SimpleThreadDemo;

Thread currentThread = Thread.CurrentThread;
currentThread.Name = "Main Thread";
Console.Write("選擇執行緒數量[1] or [2]?： ");
string? choose = Console.ReadLine();

Print p = new Print();
Console.WriteLine("** 現在的執行緒: {0}", currentThread);
//


switch (choose)
{
    case "2":
        //Thread t = new Thread(() => p.LazyFunc());    //Lambda+匿名方法
        Thread t = new Thread(new ThreadStart(p.LazyFunc));

        t.Start();
        break;

    case "1":
    default:
        p.LazyFunc();
        break;
}
Console.WriteLine("*** 執行緒 {0} 已經結束 ***", currentThread.Name);
