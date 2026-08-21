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

        //🏉設定為背景執行緒, 當主執行緒結束後, 背景執行緒會自動結束
        t.IsBackground = true;

        t.Start();
        break;

    case "1":
    default:
        p.LazyFunc();
        break;
}
Console.WriteLine("*** 執行緒 {0} 已經結束 ***", currentThread.Name);
Console.WriteLine("*** 程式結束(因設置背景，主執行緒結束，背景執行緒就結束) ***");
