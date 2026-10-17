using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace DataParallelismWithForEach;

public partial class MainWindow : Window
{
    private CancellationTokenSource _cancelToken = new CancellationTokenSource();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void cmdCancel_Click(object sender, EventArgs e)
    {
        _cancelToken.Cancel();
    }

    private void cmdProcess_Click(object sender, EventArgs e)
    {
        this.Title = $"Starting...";
        Task.Factory.StartNew(ProcessFiles);
        this.Title = "Processing Complete";
    }

    private void ProcessFiles()
    {
        // 載入所有 *.jpg 檔，並為修改後的資料
        //   建立一個新資料夾。
        // 取得程式目前執行所在的目錄路徑
        // 用 VS 2022 偵錯時，目前目錄會是 <專案目錄>\bin\debug\net6.0-windows
        // 用 VS Code 或「dotnet run」時，目前目錄會是 <專案目錄>
        var basePath = Directory.GetCurrentDirectory();
        var pictureDirectory = Path.Combine(basePath, "TestPictures");
        var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
        // 清掉任何已存在的檔案
        if (Directory.Exists(outputDirectory))
        {
            Directory.Delete(outputDirectory, true);
        }
        Directory.CreateDirectory(outputDirectory);
        string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);
        // 以「阻塞（blocking）」方式處理圖片資料。

        ParallelOptions options = new ParallelOptions();
        options.CancellationToken = _cancelToken.Token;
        options.MaxDegreeOfParallelism = Environment.ProcessorCount; // 設定並行處理的數量
        try
        {
            Parallel.ForEach(
                files,
                options,
                currentFile =>
                {
                    options.CancellationToken.ThrowIfCancellationRequested(); // 取消時會拋出例外
                    string filename = Path.GetFileName(currentFile);
                    // 印出正在處理目前這張圖片的執行緒 ID。
                    Dispatcher.Invoke(() =>
                        this.Title =
                            $"Processing {filename} on thread {Environment.CurrentManagedThreadId}"
                    );
                    //Console.WriteLine("current file name:{0}", currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(outputDirectory, filename));
                    }
                }
            );
            Dispatcher.Invoke(() => this.Title = "Processing Complete");
        }
        catch (OperationCanceledException e)
        {
            Dispatcher.Invoke(() => this.Title = "Processing Canceled");
        }
    }
}
