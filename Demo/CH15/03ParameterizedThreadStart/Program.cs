using System.Runtime.InteropServices;
using AddWithThreads;

// 🌟 1. 建立一個靜態的 AutoResetEvent (初始狀態設為 false：未收到訊號)
AutoResetEvent _waithandle = new AutoResetEvent(false);

Console.WriteLine("***** 透過 Thread 物件相加 *****");
Console.WriteLine("Main() 方法內的執行緒 ID: {0}", Environment.CurrentManagedThreadId);
Thread mainThread = Thread.CurrentThread;
mainThread.Name = "Main Thread";

// 🌟 1. 建立要傳遞給次要執行緒的資料包裹
AddParams ap = new AddParams(10, 10);

// 🌟 2. 建立執行緒，並指派 ParameterizedThreadStart 委派
Thread t = new Thread(new ParameterizedThreadStart(Add));

// 🌟 3. 呼叫 Start 時，把包裹(ap)塞進去！
t.Start(ap);

// 💀 糟糕的示範：強迫等待其他執行緒完成
//Thread.Sleep(5);

// 🌟 2. 廠長(主執行緒)走到這裡會被「卡住 (Block)」，直到收到通知為止！
_waithandle.WaitOne();

Console.WriteLine("{0} is finished.", mainThread.Name);

void Add(object data)
{
    // 🌟 防呆與轉型：確保傳進來的真的是 AddParams 包裹
    if (data is AddParams ap)
    {
        Console.WriteLine("Add() 方法內的執行緒 ID: {0}", Environment.CurrentManagedThreadId);

        // 執行我們想要的運算
        Console.WriteLine("{0} + {1} 等於 {2}", ap.a, ap.b, ap.a + ap.b);
        Thread.Sleep(2000);
    }

    // 🌟 3. 工人做完事了，按下對講機呼叫廠長：「我們做完了！」
    _waithandle.Set();
}
