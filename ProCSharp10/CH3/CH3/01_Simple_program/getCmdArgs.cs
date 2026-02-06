using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple_program
{
    internal class getCmdArgs
    {
        static void Main(string[] Args)
        {
            //Method1: Using Environment.GetCommandLineArgs()
            string[] args1 = Environment.GetCommandLineArgs();
            Console.WriteLine("Using Environment.GetCommandLineArgs():");
            foreach (string arg in args1[1..])
            {
                Console.WriteLine(arg);
            }
            Console.WriteLine();

            // Method 2: Using Main method parameters
            Console.WriteLine("Using Main method parameters:");
            MainWithArgs(Args); // Skip the first argument which is the executable path
        }

        private static void MainWithArgs(string[] toArray)
        {
            foreach (var s in toArray)
            {
                Console.WriteLine(s);
            }
        }
    }
}
