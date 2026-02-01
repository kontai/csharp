using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static readonly string OutputFilePath = @"d:\G85finder.txt";
        
        private static int totalFiles = 0;
        private static int totalMatches = 0;
        private static int scannedFiles = 0;
        private static int skippedFiles = 0;
        private static int largeFilesProcessed = 0;
        private static readonly object lockObj = new object();
        
        // 使用緩衝區來批次寫入,減少 I/O 次數
        private static readonly ConcurrentQueue<string> writeBuffer = new ConcurrentQueue<string>();
        private static readonly int bufferFlushSize = 100; // 每累積100行就寫入一次
        
        // 大型檔案閾值設定
        private static readonly long LargeFileThreshold = 100 * 1024 * 1024; // 10 MB
        private static readonly long MaxFileSize = 1000 * 1024 * 1024; // 500 MB

        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\workspace\Qt\";
                
                Console.WriteLine("開始掃描目錄: " + path);
                Console.WriteLine("輸出檔案: " + OutputFilePath);
                Console.WriteLine("========================================");

                var startTime = DateTime.Now;

                // 使用 StreamWriter 保持輸出檔案開啟,提升效能
                using (StreamWriter outputWriter = new StreamWriter(OutputFilePath, false, Encoding.UTF8, 65536)) // 使用較大的緩衝區
                {
                    WriteToBuffer($"掃描目錄: {path}");
                    WriteToBuffer($"掃描時間: {startTime:yyyy-MM-dd HH:mm:ss}");
                    WriteToBuffer("========================================");
                    WriteToBuffer("");

                    // 檢查目錄是否存在
                    DirectoryInfo rootDir = new DirectoryInfo(path);
                    if (!rootDir.Exists)
                    {
                        Console.WriteLine($"錯誤: 目錄不存在 [{path}]");
                        return;
                    }

                    // 使用並行處理來加快掃描速度
                    ProcessDirectoryParallel(rootDir, outputWriter);

                    // 寫入剩餘的緩衝內容
                    FlushBuffer(outputWriter, true);

                    var endTime = DateTime.Now;
                    var duration = endTime - startTime;

                    // 寫入統計資訊
                    outputWriter.WriteLine();
                    outputWriter.WriteLine("========================================");
                    outputWriter.WriteLine($"掃描完成時間: {endTime:yyyy-MM-dd HH:mm:ss}");
                    outputWriter.WriteLine($"耗時: {duration.TotalSeconds:F2} 秒");
                    outputWriter.WriteLine($"掃描檔案總數: {scannedFiles}");
                    outputWriter.WriteLine($"跳過檔案數: {skippedFiles}");
                    outputWriter.WriteLine($"大型檔案處理數: {largeFilesProcessed}");
                    outputWriter.WriteLine($"找到匹配的檔案: {totalFiles}");
                    outputWriter.WriteLine($"匹配行數總計: {totalMatches}");
                }

                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine($"掃描完成!");
                Console.WriteLine($"耗時: {(DateTime.Now - startTime).TotalSeconds:F2} 秒");
                Console.WriteLine($"掃描檔案總數: {scannedFiles}");
                Console.WriteLine($"跳過檔案數: {skippedFiles}");
                Console.WriteLine($"大型檔案處理數: {largeFilesProcessed}");
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

        static void ProcessDirectoryParallel(DirectoryInfo rootDir, StreamWriter outputWriter)
        {
            // 收集所有需要處理的檔案
            var allFiles = new List<FileInfo>();
            CollectFiles(rootDir, allFiles);

            Console.WriteLine($"共找到 {allFiles.Count} 個檔案,開始處理...");

            // 使用 Parallel.ForEach 並行處理檔案
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount // 使用所有可用的 CPU 核心
            };

            Parallel.ForEach(allFiles, parallelOptions, fileInfo =>
            {
                ReadFileOptimized(fileInfo);
                
                // 定期刷新緩衝區
                if (writeBuffer.Count >= bufferFlushSize)
                {
                    lock (lockObj)
                    {
                        FlushBuffer(outputWriter, false);
                    }
                }
            });
        }

        static void CollectFiles(DirectoryInfo directory, List<FileInfo> allFiles)
        {
            try
            {
                // 收集當前目錄的檔案
                allFiles.AddRange(directory.GetFiles());

                // 遞迴收集子目錄的檔案
                foreach (var subDir in directory.GetDirectories())
                {
                    CollectFiles(subDir, allFiles);
                }
            }
            catch (UnauthorizedAccessException)
            {
                lock (lockObj)
                {
                    skippedFiles++;
                }
            }
            catch (Exception)
            {
                // 忽略其他錯誤,繼續處理
            }
        }

        static void ReadFileOptimized(FileInfo fileInfo)
        {
            lock (lockObj)
            {
                scannedFiles++;
                if (scannedFiles % 1000 == 0)
                {
                    Console.WriteLine($"已掃描 {scannedFiles} 個檔案...");
                }
            }

            try
            {
                // 檢查檔案大小,跳過過大的檔案
                if (fileInfo.Length > MaxFileSize)
                {
                    lock (lockObj)
                    {
                        skippedFiles++;
                    }
                    WriteToBuffer($"[跳過] 檔案過大 (>{MaxFileSize / (1024 * 1024)}MB): {fileInfo.FullName}");
                    return;
                }

                // 根據檔案大小選擇不同的處理策略
                if (fileInfo.Length > LargeFileThreshold)
                {
                    ProcessLargeFile(fileInfo);
                }
                else
                {
                    ProcessSmallFile(fileInfo);
                }
            }
            catch (UnauthorizedAccessException)
            {
                lock (lockObj)
                {
                    skippedFiles++;
                }
            }
            catch (IOException)
            {
                lock (lockObj)
                {
                    skippedFiles++;
                }
            }
            catch (Exception)
            {
                lock (lockObj)
                {
                    skippedFiles++;
                }
            }
        }

        // 小檔案策略:一次性讀取所有內容到記憶體
        static void ProcessSmallFile(FileInfo fileInfo)
        {
            using (StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.UTF8, true, 65536))
            {
                int lineNum = 0;
                bool fileHeaderWritten = false;
                int fileMatchCount = 0;
                var matchedLines = new List<string>();

                string content;
                while ((content = sr.ReadLine()) != null)
                {
                    lineNum++;

                    if (content.Length > 0 && 
                        (content.StartsWith("G85") || 
                         (content.TrimStart().StartsWith("G85") && content.TrimStart().Length > 0)))
                    {
                        if (!fileHeaderWritten)
                        {
                            matchedLines.Add($"檔案: [{fileInfo.FullName}] (大小: {fileInfo.Length / 1024.0:F2} KB)");
                            fileHeaderWritten = true;
                            
                            lock (lockObj)
                            {
                                totalFiles++;
                            }
                        }

                        matchedLines.Add($"  於 #{lineNum} 行: {content.Trim()}");
                        fileMatchCount++;
                        
                        lock (lockObj)
                        {
                            totalMatches++;
                        }
                    }
                }

                if (fileHeaderWritten)
                {
                    matchedLines.Add($"  小計: {fileMatchCount} 個匹配");
                    matchedLines.Add("========================================");
                    matchedLines.Add("");

                    foreach (var line in matchedLines)
                    {
                        WriteToBuffer(line);
                    }
                }
            }
        }

        // 大型檔案策略:使用流式處理,逐塊讀取,找到匹配後立即寫入
        static void ProcessLargeFile(FileInfo fileInfo)
        {
            lock (lockObj)
            {
                largeFilesProcessed++;
                Console.WriteLine($"[大型檔案] 處理中: {fileInfo.FullName} ({fileInfo.Length / (1024.0 * 1024.0):F2} MB)");
            }

            // 使用更大的緩衝區處理大型檔案
            using (StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.UTF8, true, 262144)) // 256KB 緩衝區
            {
                int lineNum = 0;
                bool fileHeaderWritten = false;
                int fileMatchCount = 0;
                int processedLines = 0;
                const int progressInterval = 100000; // 每處理 10 萬行顯示進度

                string content;
                while ((content = sr.ReadLine()) != null)
                {
                    lineNum++;
                    processedLines++;

                    // 顯示處理進度
                    if (processedLines % progressInterval == 0)
                    {
                        lock (lockObj)
                        {
                            Console.WriteLine($"  [進度] 已處理 {processedLines / 10000}萬行...");
                        }
                    }

                    if (content.Length > 0 && 
                        (content.StartsWith("G85") || 
                         (content.TrimStart().StartsWith("G85") && content.TrimStart().Length > 0)))
                    {
                        if (!fileHeaderWritten)
                        {
                            WriteToBuffer($"檔案: [{fileInfo.FullName}] (大小: {fileInfo.Length / (1024.0 * 1024.0):F2} MB) [大型檔案]");
                            fileHeaderWritten = true;
                            
                            lock (lockObj)
                            {
                                totalFiles++;
                            }
                        }

                        // 大型檔案找到匹配後立即寫入,不累積在記憶體中
                        WriteToBuffer($"  於 #{lineNum} 行: {content.Trim()}");
                        fileMatchCount++;
                        
                        lock (lockObj)
                        {
                            totalMatches++;
                        }

                        // 每找到 50 個匹配就強制刷新一次,避免記憶體累積
                        if (fileMatchCount % 50 == 0)
                        {
                            lock (lockObj)
                            {
                                FlushBuffer(null, true);
                            }
                        }
                    }
                }

                if (fileHeaderWritten)
                {
                    WriteToBuffer($"  小計: {fileMatchCount} 個匹配 (共掃描 {lineNum} 行)");
                    WriteToBuffer("========================================");
                    WriteToBuffer("");
                    
                    lock (lockObj)
                    {
                        Console.WriteLine($"[完成] 大型檔案處理完畢: {fileInfo.Name}");
                    }
                }
            }
        }

        static void WriteToBuffer(string content)
        {
            writeBuffer.Enqueue(content);
        }

        static void FlushBuffer(StreamWriter writer, bool force)
        {
            if (!force && writeBuffer.Count < bufferFlushSize)
            {
                return;
            }

            // 如果 writer 為 null,需要開啟檔案寫入(用於大型檔案的中途刷新)
            bool needClose = false;
            if (writer == null)
            {
                writer = new StreamWriter(OutputFilePath, true, Encoding.UTF8, 65536);
                needClose = true;
            }

            while (writeBuffer.TryDequeue(out string line))
            {
                writer.WriteLine(line);
            }
            
            writer.Flush(); // 確保資料寫入磁碟

            if (needClose)
            {
                writer.Close();
            }
        }
    }
}