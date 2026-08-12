using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;

FunWithThreads();

static void FunWithThreads()
{
    var process = from ps in Process.GetProcesses() orderby ps.Id select ps;
    foreach (var item in process)
    {
        Console.WriteLine("{0}\t{1}", item.Id, item.ProcessName);
    }
    bool sucess = false;
    string? res = "";
    while (true)
    {
        Console.Write("select ID?(q to quit): ");
        res = Console.ReadLine();
        sucess = int.TryParse(res, out int ids);
        if (sucess)
        {
            Console.WriteLine("************************************");
            EnumThreadsForPid(ids);   //🌟 列出指定處理序中的每個執行緒統計資訊
            //EnumModsForPid(ids);    //🌟 取得該處理序掛載的所有模組
        }
        if (res == "q" || res == "Q") break;
    }
}

[SupportedOSPlatform("windows")]
#pragma warning disable CS8321 // 目前未呼叫，保留備用
static void EnumThreadsForPid(int pID)
{
    Process? theProc = null;
    try
    {
        theProc = Process.GetProcessById(pID);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return; // 找不到就直接結束
    }

    // 🌟 列出指定處理序中的每個執行緒統計資訊
    Console.WriteLine($"以下是 {theProc!.ProcessName} 正在使用的執行緒：");

    // 取得該處理序的所有執行緒 (ProcessThreadCollection)
    ProcessThreadCollection? theThreads = null;
    try
    {
        theThreads = theProc.Threads;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }

    var chuckThread = (from ProcessThread s in theThreads orderby s.Id select s).Chunk(5);

    string info = "";
    int page = 0;
    foreach (ProcessThread[] pts in chuckThread)
    {
        Console.WriteLine($"*** 第 {++page} 頁 ***");
        foreach (ProcessThread pt in pts)
        {
            // 印出執行緒 ID、啟動時間與優先權
            try
            {
                info = $"-> Thread ID: {pt.Id}\t啟動時間: {pt.StartTime.ToShortTimeString()}\t優先權: {pt.PriorityLevel}";
                Console.WriteLine(info);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        Console.ReadLine();
    }
    Console.WriteLine("************************************\n");
}
#pragma warning restore CS8321

static void EnumModsForPid(int pID)
{
    Process? theProc = null;
    try
    {
        theProc = Process.GetProcessById(pID);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }

    try
    {
        Console.WriteLine($"以下是 {theProc.ProcessName} 載入的模組 (DLL)：");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return;
    }
    // 🌟 取得該處理序掛載的所有模組
    try
    {
        ProcessModuleCollection theMods = theProc.Modules;

        foreach (ProcessModule pm in theMods)
        {
            string info = $"-> 模組名稱: {pm.ModuleName}";
            Console.WriteLine(info);
        }
        Console.WriteLine("************************************\n");
    }
    catch (Win32Exception e)
    {
        Console.WriteLine(e.Message);
    }
}