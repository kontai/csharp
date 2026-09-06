using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

//FlipImage();
FlipImageWithParallelFor();

static void FlipImage()
{
    //search all directories and subdirectories for jpg files
    string[] jpgFiles = Directory.GetFiles(
        @"D:\w11Home\Pictures\wallpaper",
        "*.jpg",
        SearchOption.AllDirectories
    );

    Stopwatch sw = Stopwatch.StartNew();

    //show images
    foreach (var (index, item) in ((Enumerable.Range(0, jpgFiles.Length).Zip(jpgFiles))))
    {
        Console.WriteLine("Current Thead ID: {0}", Environment.CurrentManagedThreadId);
        string filename = Path.GetFileName(item);

        Bitmap bitmap = new Bitmap(item);
        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
        bitmap.Save(Path.Combine(@"D:\w11Home\Pictures\TestOutput", filename));
    }

    sw.Stop();
    Console.WriteLine("總共運行時間: {0}ms", sw.ElapsedMilliseconds);
}

static void FlipImageWithParallelFor()
{
    //search all directories and subdirectories for jpg files
    string[] jpgFiles = Directory.GetFiles(
        @"D:\w11Home\Pictures\wallpaper",
        "*.jpg",
        SearchOption.AllDirectories
    );

    Stopwatch sw = Stopwatch.StartNew();

    //show images
    Parallel.ForEach(
        Enumerable.Range(0, jpgFiles.Length).Zip(jpgFiles),
        (tupleParam) =>
        {
            var (num, currentFile) = tupleParam;
            //Console.WriteLine("Current Thead ID: {0}", Environment.CurrentManagedThreadId);
            string filename = Path.GetFileName(currentFile);

            Bitmap bitmap = new Bitmap(currentFile);
            Console.WriteLine($"Processing file {num} {filename}");
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);
            bitmap.Save(Path.Combine(@"D:\w11Home\Pictures\TestOutput", filename));
        }
    );

    sw.Stop();
    Console.WriteLine("總共運行時間: {0}ms", sw.ElapsedMilliseconds);
}
