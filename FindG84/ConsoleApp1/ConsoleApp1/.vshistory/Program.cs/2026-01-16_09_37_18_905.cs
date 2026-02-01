using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 獲取 C 磁碟根目錄下的所有子目錄
            try
            {
                DirectoryInfo[] dirs = new DirectoryInfo(@"D:\workspace\Qt\").GetDirectories();
                RecursionDir(dirs);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"存取被拒絕: {ex.Message}");
            }
        }

        static void RecursionDir(DirectoryInfo[] path)
        {
            foreach (var directoryInfo in path)
            {
                Console.WriteLine(directoryInfo.FullName);

                try
                {
                    DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();

                    if (subdirectories.Length > 0)
                    {
                        RecursionDir(subdirectories);
                    }

                    FileInfo[] filesInfo = directoryInfo.GetFiles();
                    Console.WriteLine(filesInfo);
                }
                catch (UnauthorizedAccessException)
                {
                    // 略過無權限存取的目錄
                }
            }
        }
    }
}