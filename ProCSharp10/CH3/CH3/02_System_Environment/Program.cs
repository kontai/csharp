ShowEnvironmentDetails();

CSharp10Environment();

static void ShowEnvironmentDetails()
{
    //Print out the drivers ont this machine
    foreach (var drive in Environment.GetLogicalDrives())
    {
        Console.WriteLine("Drive: {0}", drive);
    }
    Console.WriteLine("=================");

    //Print out the OS version
    Console.WriteLine("OS: {0}", Environment.OSVersion);
    Console.WriteLine("=================");

    //Print out the Processor Count
    Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
    Console.WriteLine("=================");

    //Print out the .NET version
    Console.WriteLine(".NET Core Version: {0}", Environment.Version);

    //Print out executable path
    Console.WriteLine("Process Path: {0}", Environment.ProcessPath);
}

static void CSharp10Environment()
{
    // 使用 System.Environment 獲取環境資訊
    Console.WriteLine("--- 環境資訊查詢 ---");

    // 獲取作業系統位元數與電腦名稱
    Console.WriteLine("是否為 64 位元系統: {0}", Environment.Is64BitOperatingSystem);
    Console.WriteLine("電腦名稱: {0}", Environment.MachineName);

    // C# 10 新功能：獲取處理程序 PID 與 路徑
    Console.WriteLine("目前的 Process ID: {0}", Environment.ProcessId);
    Console.WriteLine("程式執行檔路徑: {0}", Environment.ProcessPath);

    // 獲取當前 .NET 版本
    Console.WriteLine(".NET 版本: {0}", Environment.Version);

    // 使用特定的換行符號
    Console.Write($"這是第一行{Environment.NewLine}這是第二行");
}