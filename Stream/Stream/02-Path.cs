using System.Diagnostics;

//獲取「當前工作目錄」
// Method 1
string currentDirectory = Directory.GetCurrentDirectory();

// Method 2
string dirCurrentDir = Directory.GetCurrentDirectory();
Console.WriteLine($"當前目錄: {dirCurrentDir}");


// 獲取「應用程式啟動目錄」
// Method 1 
string currentDIR = AppDomain.CurrentDomain.BaseDirectory;
Console.WriteLine(currentDIR);
string fullPath = Path.Combine(currentDIR, "test.txt");

Console.WriteLine(fullPath);
Console.WriteLine(File.Exists(fullPath));

// Method 2
string baseDirectory = AppContext.BaseDirectory;
Console.WriteLine(baseDirectory);

// 獲取「臨時目錄」或「特殊目錄」
string tempPath = Path.GetTempPath();
Console.WriteLine(tempPath);

// 獲取「系統目錄」
string systemDirectory = Environment.SystemDirectory;
Console.WriteLine(systemDirectory);

// 獲取「桌面目錄」
string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
Console.WriteLine(desktopDirectory);

// 獲取「我的文件目錄」
string myDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine(myDocumentsDirectory);

// 獲取「執行中進程的路徑」
string currentProcessPath = Process.GetCurrentProcess().MainModule.FileName;
Console.WriteLine($"當前進程目錄: {currentProcessPath}");

// 獲取「執行中進程的父目錄」
DirectoryInfo? rootPath = Directory.GetParent(currentProcessPath);
Console.WriteLine(rootPath);