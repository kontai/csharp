using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        private static readonly Regex G85Regex = new Regex("^G85.*$", RegexOptions.Compiled);
        private static readonly string OutputFilePath = @"d:\G85finder.txt";

        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\workspace\Qt\";
                
                // 清空輸出檔案（只做一次）
                File.WriteAllText(OutputFilePath, "");

                // 列出根目錄下的所有檔案
                FileInfo[] files = new DirectoryInfo(path).GetFiles();
                foreach (var fileInfo in files)
                {
                    ReadFile(fileInfo);
                }

                // 獲取所有子目錄並進行遞迴
                DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();
                RecursionDir(dirs);

                Console.WriteLine("掃描完成");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"存取被拒絕: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發生錯誤: {ex.Message}");
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

                try
                {
                    FileInfo[] filesInfo = directoryInfo.GetFiles();
                    foreach (var fileInfo in filesInfo)
                    {
                        ReadFile(fileInfo);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // 略過無權限存取的檔案
                }
            }
        }

        static void ReadFile(FileInfo fileInfo)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.Default))
                {
                    int lineNum = 0;
                    bool fileHeaderWritten = false;

                    while (!sr.EndOfStream)
                    {
                        lineNum++;
                        string content = sr.ReadLine();

                        if (content != null && G85Regex.IsMatch(content))
                        {
                            // 第一次找到匹配時，寫入檔案名
                            if (!fileHeaderWritten)
                            {
                                Console.WriteLine($"檔案: [{fileInfo.FullName}]");
                                AppendToFile($"檔案: [{fileInfo.FullName}]{Environment.NewLine}");
                                fileHeaderWritten = true;
                            }

                            string result = $"於#{lineNum}行: {content}";
                            Console.WriteLine(result);
                            AppendToFile(result + Environment.NewLine);
                        }
                    }

                    if (fileHeaderWritten)
                    {
                        Console.WriteLine("#################################");
                        AppendToFile("#################################" + Environment.NewLine);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"無法存取檔案: {fileInfo.FullName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"讀取檔案失敗 [{fileInfo.FullName}]: {ex.Message}");
            }
        }

        static void AppendToFile(string content)
        {
            try
            {
                File.AppendAllText(OutputFilePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"寫入檔案失敗: {ex.Message}");
            }
        }
    }
}