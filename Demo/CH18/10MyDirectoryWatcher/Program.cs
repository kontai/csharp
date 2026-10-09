using System.Threading.Channels;

Console.WriteLine("***** The Amazing File Watcher App *****\n");

// 建立要監看之目錄的路徑。
using var watcher = new FileSystemWatcher();
try
{
    // 錯誤示範：watcher.Path = @".";
    // "." 是相對路徑，實際指向哪個資料夾取決於目前工作目錄（依啟動方式而異，例如
    // VS 偵錯跟 dotnet run 的工作目錄常常不同），監看目錄跟下方的檔案操作目錄可能對不起來。
    // 應固定用 AppContext.BaseDirectory，不管怎麼啟動都指向同一個資料夾。
    watcher.Path = AppContext.BaseDirectory;
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}

//設定要候留意的項目
watcher.NotifyFilter =
    NotifyFilters.LastAccess
    | NotifyFilters.LastWrite
    | NotifyFilters.FileName;

//設定要監看的檔案類型
watcher.Filter = "*.txt";

//加入事件處理器
//Change,Create,Deleted,Renamed
watcher.Changed += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
watcher.Created += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
watcher.Deleted += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

//指定當前檔案衱重新命名要作什麼
watcher.Renamed += (s, e) => Console.WriteLine($"File: {e.OldName} Rename to {e.FullPath}");

//Error事仲:
//在極短時間內有大量檔案異動（例如一次複製上千個檔案到被監看的目錄），緩衝區可能溢位，導致部分事件被丟棄，並觸發 Error 事件
watcher.Error += (s, e) =>
{
    Console.WriteLine($"Error: {e.GetException()}");
    // TODO: 可視需求重新掃描目錄來補齊遺漏的事件
};

//設定內部緩衝區大小,預設為8192
watcher.InternalBufferSize = 1024 * 16;

//啟動監看
watcher.EnableRaisingEvents = true;

string testFilePath = Path.Combine(AppContext.BaseDirectory, "test.txt");
string renamedFilePath = Path.Combine(AppContext.BaseDirectory, "test2.txt");

await using (var f = File.CreateText(testFilePath))
{
    await f.WriteAsync("This is some text");
}
File.Move(testFilePath, renamedFilePath);
File.Delete(renamedFilePath);
while (Console.Read() != 'q')
    ;
