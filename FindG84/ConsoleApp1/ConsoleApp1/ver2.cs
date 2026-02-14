using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    internal class ver2
    {
        private static readonly string OutputFilePath = @"d:\G85finder.txt";
        
        private static int totalFiles = 0;
        private static int totalMatches = 0;
        private static int scannedFiles = 0;

        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\workspace\Qt\";
                
                Console.WriteLine("開始掃描目錄: " + path);
                Console.WriteLine("輸出檔案: " + OutputFilePath);
                Console.WriteLine("========================================");

                // 使用 StreamWriter 保持輸出檔案開啟,提升效能
                using (StreamWriter outputWriter = new StreamWriter(OutputFilePath, false, Encoding.UTF8))
                {
                    outputWriter.WriteLine($"掃描目錄: {path}");
                    outputWriter.WriteLine($"掃描時間: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    outputWriter.WriteLine("========================================");
                    outputWriter.WriteLine();

                    // 列出根目錄下的所有檔案
                    DirectoryInfo rootDir = new DirectoryInfo(path);
                    if (!rootDir.Exists)
                    {
                        Console.WriteLine($"錯誤: 目錄不存在 [{path}]");
                        return;
                    }

                    FileInfo[] files = rootDir.GetFiles();
                    foreach (var fileInfo in files)
                    {
                        ReadFile(fileInfo, outputWriter);
                    }

                    // 遞迴處理所有子目錄
                    DirectoryInfo[] dirs = rootDir.GetDirectories();
                    RecursionDir(dirs, outputWriter);

                    // 寫入統計資訊
                    outputWriter.WriteLine();
                    outputWriter.WriteLine("========================================");
                    outputWriter.WriteLine($"掃描完成時間: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    outputWriter.WriteLine($"掃描檔案總數: {scannedFiles}");
                    outputWriter.WriteLine($"找到匹配的檔案: {totalFiles}");
                    outputWriter.WriteLine($"匹配行數總計: {totalMatches}");
                }

                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine($"掃描完成!");
                Console.WriteLine($"掃描檔案總數: {scannedFiles}");
                Console.WriteLine($"找到匹配的檔案: {totalFiles}");
                Console.WriteLine($"匹配行數總計: {totalMatches}");
                Console.WriteLine($"結果已儲存至: {OutputFilePath}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"存取被拒絕: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發生錯誤: {ex.Message}");
                Console.WriteLine($"堆疊追蹤: {ex.StackTrace}");
            }

            Console.WriteLine();
            Console.WriteLine("按任意鍵結束...");
            Console.ReadKey();
        }

        static void RecursionDir(DirectoryInfo[] directories, StreamWriter outputWriter)
        {
            foreach (var directoryInfo in directories)
            {
                Console.WriteLine($"掃描目錄: {directoryInfo.FullName}");

                try
                {
                    // 先處理子目錄
                    DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();
                    if (subdirectories.Length > 0)
                    {
                        RecursionDir(subdirectories, outputWriter);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"  [跳過] 無權限存取目錄: {directoryInfo.FullName}");
                    outputWriter.WriteLine($"[跳過目錄] {directoryInfo.FullName} - 無權限");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  [錯誤] 存取目錄失敗: {directoryInfo.FullName} - {ex.Message}");
                }

                try
                {
                    // 處理目錄中的檔案
                    FileInfo[] filesInfo = directoryInfo.GetFiles();
                    foreach (var fileInfo in filesInfo)
                    {
                        ReadFile(fileInfo, outputWriter);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"  [跳過] 無權限讀取目錄檔案: {directoryInfo.FullName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  [錯誤] 讀取目錄檔案失敗: {directoryInfo.FullName} - {ex.Message}");
                }
            }
        }

        static void ReadFile(FileInfo fileInfo, StreamWriter outputWriter)
        {
            scannedFiles++;

            try
            {
                // 使用 UTF-8 編碼,並啟用自動偵測
                // detectEncodingFromByteOrderMarks: true 可自動偵測 BOM
                using (StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.UTF8, true))
                {
                    int lineNum = 0;
                    bool fileHeaderWritten = false;
                    int fileMatchCount = 0;

                    while (!sr.EndOfStream)
                    {
                        lineNum++;
                        string content = sr.ReadLine();

                        // 使用 StartsWith 取代正則表達式,效能更好
                        if (!string.IsNullOrEmpty(content) && content.TrimStart().StartsWith("G85"))
                        {
                            // 第一次找到匹配時,寫入檔案標題
                            if (!fileHeaderWritten)
                            {
                                string header = $"檔案: [{fileInfo.FullName}]";
                                Console.WriteLine(header);
                                outputWriter.WriteLine(header);
                                fileHeaderWritten = true;
                                totalFiles++;
                            }

                            string result = $"  於 #{lineNum} 行: {content.Trim()}";
                            Console.WriteLine(result);
                            outputWriter.WriteLine(result);
                            fileMatchCount++;
                            totalMatches++;
                        }
                    }

                    // 如果找到匹配,寫入分隔線和統計
                    if (fileHeaderWritten)
                    {
                        string summary = $"  小計: {fileMatchCount} 個匹配";
                        Console.WriteLine(summary);
                        Console.WriteLine("========================================");
                        outputWriter.WriteLine(summary);
                        outputWriter.WriteLine("========================================");
                        outputWriter.WriteLine();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"  [跳過] 無法存取檔案: {fileInfo.FullName}");
                outputWriter.WriteLine($"[跳過檔案] {fileInfo.FullName} - 無權限");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"  [跳過] 檔案讀取失敗 [{fileInfo.FullName}]: {ex.Message}");
                outputWriter.WriteLine($"[跳過檔案] {fileInfo.FullName} - IO錯誤");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  [錯誤] 讀取檔案失敗 [{fileInfo.FullName}]: {ex.Message}");
                outputWriter.WriteLine($"[錯誤] {fileInfo.FullName} - {ex.Message}");
            }
        }
    }
}