using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(@"\\NAS_tai\home\Music");
                await RecursionDirAsync(rootDir);
                Console.WriteLine("掃描完成");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"存取被拒絕: {ex.Message}");
            }
        }

        static async Task RecursionDirAsync(DirectoryInfo path)
        {
            Console.WriteLine(path.FullName);

            try
            {
                DirectoryInfo[] subdirectories = path.GetDirectories();

                if (subdirectories.Length > 0)
                {
                    // 使用 Task.WhenAll 並行處理多個子目錄
                    List<Task> tasks = new List<Task>();

                    foreach (var subdir in subdirectories)
                    {
                        tasks.Add(RecursionDirAsync(subdir));
                    }

                    await Task.WhenAll(tasks);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 略過無權限存取的目錄
            }
        }
    }
}