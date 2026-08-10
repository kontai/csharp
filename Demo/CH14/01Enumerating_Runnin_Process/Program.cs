using System.ComponentModel;
using System.Diagnostics;

GetProcess();
//GetProcessById(7499);

static void GetProcess()
{
    var process = from pros in Process.GetProcesses() orderby pros.Id select pros;
    foreach (var p in process)
    {
        Console.WriteLine($"-> PID: {p.Id}\tName: {p.ProcessName}");
    }
    if (process.TryGetNonEnumeratedCount(out int count))
    {
        Console.WriteLine("-> Total Process: " + count);
    }
}

static void GetProcessById(int id)
{
    Process process = null;

    try
    {
        process = Process.GetProcessById(id);
        Console.WriteLine("Process Name: {0}", process?.ProcessName);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine("找不到PID為 ({0}) 的程序，錯誤信息為: {1}", id, e.Message);
    }
}