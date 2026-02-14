using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 獲取當前目錄下所件檔案
            DirectoryInfo[] dirs = new DirectoryInfo(@"c:\").GetDirectories();
            foreach (var directoryInfo in dirs)
            {
                Console.WriteLine(directoryInfo);
            }
        }
    }
}
