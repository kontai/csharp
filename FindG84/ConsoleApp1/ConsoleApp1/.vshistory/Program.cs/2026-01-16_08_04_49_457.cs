using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetDirectoryName(@"c:\bin");
            Console.WriteLine(rootPath);
            DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

        }
    }
}
