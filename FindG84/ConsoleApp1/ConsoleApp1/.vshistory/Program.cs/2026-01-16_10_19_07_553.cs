using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 獲取 C 磁碟根目錄下的所有子目錄
            try
            {
                string path = @"D:\workspace\Qt\";
                try
                {
                    // 列出根目錄下的所有檔案
                    FileInfo[] files = new DirectoryInfo(path).GetFiles();
                    if (files.Length > 0)
                    {
                        foreach (var fileInfo in files)
                        {
                            //Console.WriteLine("  ---> " + fileInfo.Name);
                            readFile(fileInfo);
                        }
                    }

                    // 獲取所有子目錄, 並進行遞迴,列出所有子目錄及其檔案
                    DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();
                    RecursionDir(dirs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
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
                }
                catch (UnauthorizedAccessException)
                {
                    // 略過無權限存取的目錄
                }

                FileInfo[] filesInfo = directoryInfo.GetFiles();
                foreach (var fileInfo in filesInfo)
                {
                    //Console.WriteLine("  ---> " + fileInfo.Name);
                    readFile(fileInfo);
                }
            }
        }

        static void readFile(FileInfo fileInfo)
        {
            using (StreamWriter sw = new StreamWriter(@"d:\G85finder.txt"))
            {

                Regex reg = new Regex("^G85.*$");
                string content = "";
                using (StreamReader sr = new StreamReader(fileInfo.FullName))
                {
                    int lineNum = 0;
                    int flag = 0;
                    // 讀取檔案內容
                    while (!sr.EndOfStream)
                    {
                        lineNum++;
                        content = sr.ReadLine();
                        if (reg.IsMatch(content))
                        {
                            if (flag == 0)
                            {
                                Console.WriteLine($"[{fileInfo.FullName}]");
                                sw.Write($"[{fileInfo.FullName}]");

                                flag = 1;
                            }

                            Console.WriteLine($"\t\t--#{lineNum} {content}");
                            sw.Write($"\t\t--#{lineNum} {content}");
                        }
                    }

                    if (flag == 1)
                    {
                        Console.WriteLine("#################################");
                    }
                }
            }
        }
    }
}