using System;

namespace _10Enum_Flags
{
    [Flags]
    internal enum FilePermissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        Delete = 8
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // 初始化為空
            FilePermissions permissions = FilePermissions.None;

            // 新增權限
            permissions |= FilePermissions.Read;
            permissions |= FilePermissions.Write;
            Console.WriteLine(permissions); // 輸出: Read, Write

            // 移除權限
            permissions &= ~FilePermissions.Write;
            Console.WriteLine(permissions); // 輸出: Read

            // 檢查權限
            bool canRead = (permissions & FilePermissions.Read) == FilePermissions.Read; // true
            bool canWrite = (permissions & FilePermissions.Write) == FilePermissions.Write; // false

            Console.WriteLine($"can read? {canRead}");
            Console.WriteLine($"can write? {canWrite}");
        }
    }
}