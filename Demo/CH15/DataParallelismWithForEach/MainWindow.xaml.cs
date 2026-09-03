using System.Diagnostics;
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

//using System.Windows.Shapes;

namespace DataParallelismWithForEach;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CancellationTokenSource _cancelToken = new CancellationTokenSource();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void cmdCancel_Click(object sender, EventArgs e)
    {
        // This will be updated shortly
        _cancelToken.Cancel();
    }

    private void cmdProcess_Click(object sender, RoutedEventArgs e)
    {
        this.Title = "Starting...";
        Task.Factory.StartNew(ProcessFiles)
            .ContinueWith(
                t =>
                {
                    if (t.IsFaulted)
                        this.Title = $"Error: {t.Exception?.InnerException?.Message}";
                },
                TaskScheduler.FromCurrentSynchronizationContext()
            );
    }

    private void ProcessFiles()
    {
        //search all directories and subdirectories for jpg files
        string baseDIR = @"D:\w11Home\Pictures\wallpaper";
        string[] jpgFiles = Directory.GetFiles(baseDIR, "*.jpg", SearchOption.AllDirectories);

        string ouputDIR = Path.Combine(baseDIR, "ModifiedPictures");
        Directory.CreateDirectory(ouputDIR);

        Stopwatch sw = Stopwatch.StartNew();

        //show images
        foreach (var item in jpgFiles)
        {
            Console.WriteLine("Current Thead ID: {0}", Environment.CurrentManagedThreadId);
            Dispatcher?.Invoke(() =>
                this.Title = $"Current Thread ID: {Environment.CurrentManagedThreadId}"
            );
            string filename = Path.GetFileName(item);

            using var bitmap = new Bitmap(item);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            bitmap.Save(Path.Combine(ouputDIR, filename));
        }

        sw.Stop();
        Dispatcher?.Invoke(() => this.Title = $"總共運行時間: {sw.ElapsedMilliseconds}ms");
        Console.WriteLine("總共運行時間: {0}ms", sw.ElapsedMilliseconds);
    }

    //private void cmdProcess_Click(object sender, RoutedEventArgs e) { }
}
