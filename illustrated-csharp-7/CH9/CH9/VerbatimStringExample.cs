using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CH9
{
    internal class VerbatimStringExample
    {
        public static void Main(string[] args)
        {
            string rst1 = "Hi there!";
            string vst1 = @"Hi there!";

            string rst2 = "It started, \"Four score and seven...\"";
            string vst2 = @"It started, ""Four score and seven...""";

            string rst3 = "Value 1 \t 5, vall2 \t ";
            string vst3 = @"Value 1 \t 5, vall2 \t ";

            string rst4 = "C:\\Program Files\\Microsoft\\";
            string vst4 = @"C:\Program Files\Microsoft\";

            string rst5 = " Print \x000A Multiple \u000a Lines";
            string vst5 = @" Print
Multiple
Lines";

            List<string> list = new List<string>();
            list.Add(rst1);
            list.Add(vst1);
            list.Add(rst2);
            list.Add(vst2);
            list.Add(rst3);
            list.Add(vst3);
            list.Add(rst4);
            list.Add(vst4);
            list.Add(rst5);
            list.Add(vst5);

            foreach (var str in list)
            {
                Console.WriteLine(str);
            }

        }

    }
}

