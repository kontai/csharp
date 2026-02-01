using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 獲取當前目錄下所件檔案
            DirectoryInfo[] dirs = new DirectoryInfo(@"c:\").GetDirectories();

            recurionDir(dirs);

        }

        static void recurionDir(DirectoryInfo[] path)
        {
            foreach (var directoryInfo in path)
            {
                DirectoryInfo[] d=new DirectoryInfo(directoryInfo.Name).GetDirectories();

                if (d.Length>0)
                    recurionDir(d);
                Console.WriteLine(directoryInfo.FullName);
            }

        }
    }
}