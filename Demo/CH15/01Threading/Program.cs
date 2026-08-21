using System;
using System.Threading;

ExtractExecutingThread();
static void ExtractExecutingThread()
{
    Console.WriteLine("***** 主執行緒狀態 (Primary Thread stats) *****\n");

    // 🌟 1. 取得目前正在執行此方法的執行緒
    Thread primaryThread = Thread.CurrentThread;

    // 🌟 2. 你可以幫執行緒「命名」！(這在複雜系統除錯時極度好用)
    primaryThread.Name = "ThePrimaryThread";

    // 🌟 3. 印出這個工人的詳細履歷
    Console.WriteLine("當前執行緒 ID (ManagedThreadId): {0}", primaryThread.ManagedThreadId);
    Console.WriteLine("執行緒名稱 (Thread Name): {0}", primaryThread.Name);
    Console.WriteLine("執行緒是否活著? (IsAlive): {0}", primaryThread.IsAlive);
    Console.WriteLine("優先權等級 (Priority): {0}", primaryThread.Priority);
    Console.WriteLine("執行緒狀態 (Thread State): {0}", primaryThread.ThreadState);
}
