using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** My First C# App *****");
            Console.WriteLine("Hellow World!");
            Console.WriteLine();
            //Process any incoming args
            //for(int i=0;i<args.Length; i++)
            //{
            //    Console.WriteLine("Arg[{0}] = {1}", i, args[i]);
            //}
            showArgs();
        }

        static void showArgs()
        {
            Console.WriteLine("showArgs is called.");
            string[] theArgs=Environment.GetCommandLineArgs();
                    foreach (var theArg in theArgs)
                    {
                        Console.WriteLine(theArg);
                
            }
        }
    }
}
